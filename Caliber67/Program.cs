using Caliber67.Data;
using Caliber67.Helpers;
using Caliber67.Models.Identity;
using Caliber67.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Update Identity to include roles
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>() // Add this line
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IAuthorizationHelper, AuthorizationHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Seed admin role and user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedAdminUser(services);
}

app.Run();

// Admin seeding method
async Task SeedAdminUser(IServiceProvider serviceProvider)
{
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    // Create Admin role if it doesn't exist
    string adminRoleName = "Admin";
    if (!await roleManager.RoleExistsAsync(adminRoleName))
    {
        await roleManager.CreateAsync(new IdentityRole(adminRoleName));
    }

    // Create admin user if it doesn't exist
    string adminEmail = "admin@67caliber.com";
    string adminPassword = "Admin123!"; // Change this in production!

    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FirstName = "Admin",
            LastName = "User",
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, adminRoleName);
        }
    }
}