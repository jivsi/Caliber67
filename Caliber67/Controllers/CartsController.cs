using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Caliber67.Services;
using Microsoft.AspNetCore.Identity;
using Caliber67.Models.Identity;
using Caliber67.Models.ShoppingCart;

namespace Caliber67.Controllers
{
    [Authorize]
    public class CartsController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartsController(IShoppingCartService shoppingCartService, UserManager<ApplicationUser> userManager)
        {
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            var cart = await _shoppingCartService.GetUserCartAsync();
            return View(cart);
        }

        // POST: Carts/AddToCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            try
            {
                if (quantity <= 0)
                {
                    TempData["Error"] = "Quantity must be at least 1";
                    return RedirectToAction("Index", "Products");
                }

                await _shoppingCartService.AddToCartAsync(productId, quantity);
                TempData["Success"] = "Product added to cart successfully!";
            }
            catch (UnauthorizedAccessException)
            {
                TempData["Error"] = "You must be logged in to add items to your cart.";
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while adding the product to your cart. Please try again.";
                // Log the exception here if you have logging configured
            }

            return RedirectToAction("Index", "Products");
        }

        // POST: Carts/RemoveFromCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            try
            {
                await _shoppingCartService.RemoveFromCartAsync(cartItemId);
                TempData["Success"] = "Item removed from cart.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error removing item from cart: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Carts/UpdateQuantity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
        {
            try
            {
                await _shoppingCartService.UpdateCartItemQuantityAsync(cartItemId, quantity);
                TempData["Success"] = "Cart updated successfully.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error updating cart: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Carts/Checkout
        public async Task<IActionResult> Checkout()
        {
            var cart = await _shoppingCartService.GetUserCartAsync();
            if (cart == null || !cart.CartItems.Any())
            {
                TempData["Error"] = "Your cart is empty";
                return RedirectToAction(nameof(Index));
            }

            // Check if all items are still in stock
            foreach (var item in cart.CartItems)
            {
                if (item.Quantity > item.Product.StockQuantity)
                {
                    TempData["Error"] = $"Sorry, we only have {item.Product.StockQuantity} of {item.Product.Name} in stock. Please update your cart.";
                    return RedirectToAction(nameof(Index));
                }
            }

            return RedirectToAction("Create", "Orders");
        }

        // POST: Carts/ClearCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearCart()
        {
            try
            {
                await _shoppingCartService.ClearCartAsync();
                TempData["Success"] = "Cart cleared successfully.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error clearing cart: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Carts/GetCartCount (for AJAX requests)
        [HttpGet]
        public async Task<JsonResult> GetCartCount()
        {
            var count = await _shoppingCartService.GetCartItemCountAsync();
            return Json(new { count });
        }
    }
}