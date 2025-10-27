using Microsoft.EntityFrameworkCore;
using Caliber67.Data;
using Caliber67.Models.ShoppingCart;
using Caliber67.Models.Identity;
using System.Security.Claims;

namespace Caliber67.Services
{
    public interface IShoppingCartService
    {
        Task AddToCartAsync(int productId, int quantity = 1);
        Task RemoveFromCartAsync(int cartItemId);
        Task UpdateCartItemQuantityAsync(int cartItemId, int quantity);
        Task<Cart> GetUserCartAsync();
        Task<int> GetCartItemCountAsync();
        Task ClearCartAsync();
    }

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCartService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetUserId()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<Cart> GetUserCartAsync()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId)) return null;

            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task AddToCartAsync(int productId, int quantity = 1)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User must be logged in");

            // Check if product exists and is in stock
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new ArgumentException("Product not found");

            if (product.StockQuantity < quantity)
                throw new InvalidOperationException("Not enough stock available");

            var cart = await GetUserCartAsync();
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (existingItem != null)
            {
                // Update existing item
                existingItem.Quantity += quantity;
                if (existingItem.Quantity > product.StockQuantity)
                    throw new InvalidOperationException("Not enough stock available");
            }
            else
            {
                // Add new item
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    UnitPrice = product.Price
                });
            }

            cart.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(int cartItemId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCartItemQuantityAsync(int cartItemId, int quantity)
        {
            if (quantity <= 0)
            {
                await RemoveFromCartAsync(cartItemId);
                return;
            }

            var cartItem = await _context.CartItems
                .Include(ci => ci.Product)
                .FirstOrDefaultAsync(ci => ci.Id == cartItemId);

            if (cartItem != null)
            {
                if (quantity > cartItem.Product.StockQuantity)
                    throw new InvalidOperationException("Not enough stock available");

                cartItem.Quantity = quantity;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetCartItemCountAsync()
        {
            var cart = await GetUserCartAsync();
            return cart?.CartItems.Sum(ci => ci.Quantity) ?? 0;
        }

        public async Task ClearCartAsync()
        {
            var cart = await GetUserCartAsync();
            if (cart != null)
            {
                _context.CartItems.RemoveRange(cart.CartItems);
                await _context.SaveChangesAsync();
            }
        }
    }
}