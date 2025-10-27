using Microsoft.EntityFrameworkCore;
using Caliber67.Data;
using Caliber67.Models.ShoppingCart;
using Caliber67.Models.Orders;
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
        Task<Order> CreateOrderAsync(Order order);
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
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
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

            var cart = await GetUserCartAsync();
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            var product = await _context.Products.FindAsync(productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
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
            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                if (cartItem.Quantity <= 0)
                {
                    _context.CartItems.Remove(cartItem);
                }
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

        public async Task<Order> CreateOrderAsync(Order order)
        {
            var cart = await GetUserCartAsync();
            if (cart == null || !cart.CartItems.Any())
                throw new InvalidOperationException("Cart is empty");

            // Create order items from cart items
            foreach (var cartItem in cart.CartItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.UnitPrice
                });
            }

            order.TotalAmount = order.OrderItems.Sum(oi => oi.Subtotal);
            _context.Orders.Add(order);

            // Clear the cart
            await ClearCartAsync();

            await _context.SaveChangesAsync();
            return order;
        }
    }
}