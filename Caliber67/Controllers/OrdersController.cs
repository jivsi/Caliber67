using Caliber67.Data;
using Caliber67.Models.Identity;
using Caliber67.Models.Orders;
using Caliber67.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caliber67.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ILicenseValidationService _licenseValidationService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IShoppingCartService shoppingCartService,
                              UserManager<ApplicationUser> userManager,
                              ApplicationDbContext context,
                              ILicenseValidationService licenseValidationService,
                              ILogger<OrdersController> logger)
        {
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
            _context = context;
            _licenseValidationService = licenseValidationService;
            _logger = logger;
        }

        public async Task<IActionResult> Create()
        {
            // Get current user's cart
            var cart = await _shoppingCartService.GetUserCartAsync();
            
            if (cart == null || !cart.CartItems.Any())
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction("Index", "Carts");
            }

            // Check if cart contains firearms that require license
            var containsFirearms = cart.CartItems.Any(item => 
                item.Product.Category == "Guns");

            if (containsFirearms)
            {
                ViewBag.RequiresLicense = true;
            }

            // Get current user
            var user = await _userManager.GetUserAsync(User);
            
            ViewBag.Cart = cart;
            ViewBag.User = user;
            ViewBag.TotalAmount = cart.TotalAmount;

            var order = new Order
            {
                ShippingEmail = user.Email,
                ShippingFirstName = user.FirstName,
                ShippingLastName = user.LastName
            };

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order, IFormFile licenseFile)
        {
            var cart = await _shoppingCartService.GetUserCartAsync();
            
            if (cart == null || !cart.CartItems.Any())
            {
                TempData["Error"] = "Your cart is empty.";
                return RedirectToAction("Index", "Carts");
            }

            // Check if cart contains firearms that require license
            var containsFirearms = cart.CartItems.Any(item => 
                item.Product.Category == "Guns");

            if (containsFirearms)
            {
                // Validate license upload
                if (licenseFile == null || licenseFile.Length == 0)
                {
                    ModelState.AddModelError("License", "Firearms license is required for purchasing guns.");
                    ViewBag.Cart = cart;
                    ViewBag.User = await _userManager.GetUserAsync(User);
                    ViewBag.TotalAmount = cart.TotalAmount;
                    ViewBag.RequiresLicense = true;
                    return View(order);
                }

                var (isValid, expirationDate, notes, fileUrl) = await _licenseValidationService.ValidateLicenseAsync(licenseFile);
                
                if (!isValid)
                {
                    ModelState.AddModelError("License", $"License validation failed: {notes}");
                    ViewBag.Cart = cart;
                    ViewBag.User = await _userManager.GetUserAsync(User);
                    ViewBag.TotalAmount = cart.TotalAmount;
                    ViewBag.RequiresLicense = true;
                    return View(order);
                }

                order.LicenseValidated = isValid;
                order.LicenseExpirationDate = expirationDate;
                order.LicenseValidationNotes = notes;
                order.LicenseImageUrl = fileUrl;
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                
                // Set order properties
                order.UserId = user.Id;
                order.OrderDate = DateTime.UtcNow;
                order.TotalAmount = cart.TotalAmount;
                order.Status = OrderStatus.Pending;

                // Add order items from cart
                foreach (var cartItem in cart.CartItems)
                {
                    var orderItem = new OrderItem
                    {
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                        UnitPrice = cartItem.UnitPrice
                    };
                    order.OrderItems.Add(orderItem);

                    // Update stock quantity
                    var product = await _context.Products.FindAsync(cartItem.ProductId);
                    if (product != null)
                    {
                        product.StockQuantity -= cartItem.Quantity;
                    }
                }

                // Save order
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                // Clear cart
                await _shoppingCartService.ClearCartAsync();

                TempData["Success"] = "Order placed successfully! Order number: " + order.OrderNumber;
                _logger.LogInformation($"Order {order.OrderNumber} created by user {user.Email}");
                
                return RedirectToAction("Details", new { id = order.Id });
            }

            ViewBag.Cart = cart;
            ViewBag.User = await _userManager.GetUserAsync(User);
            ViewBag.TotalAmount = cart.TotalAmount;
            ViewBag.RequiresLicense = containsFirearms;
            
            return View(order);
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = await _context.Orders
                .Where(o => o.UserId == user.Id)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(orders);
        }
    }
}