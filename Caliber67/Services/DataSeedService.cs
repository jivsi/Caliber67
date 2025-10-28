using Caliber67.Data;
using Caliber67.Models;
using System.Text.Json;

namespace Caliber67.Services
{
    public interface IDataSeedService
    {
        Task SeedProductsAsync();
    }

    public class DataSeedService : IDataSeedService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public DataSeedService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task SeedProductsAsync()
        {
            if (_context.Products.Any())
            {
                return; // Database has been seeded
            }

            var jsonPath = Path.Combine(_environment.ContentRootPath, "Data", "SeedData", "products.json");

            if (!File.Exists(jsonPath))
            {
                throw new FileNotFoundException($"Seed data file not found: {jsonPath}");
            }

            var jsonData = await File.ReadAllTextAsync(jsonPath);
            var productsData = JsonSerializer.Deserialize<ProductsSeedData>(jsonData);

            if (productsData?.Products != null)
            {
                foreach (var product in productsData.Products)
                {
                    product.CreatedDate = DateTime.UtcNow;
                    _context.Products.Add(product);
                }

                await _context.SaveChangesAsync();
            }
        }
    }

    public class ProductsSeedData
    {
        public List<Product> Products { get; set; } = new();
    }
}