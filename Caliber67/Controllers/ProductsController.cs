using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Caliber67.Models;
using Caliber67.Helpers;
using Caliber67.Services;

namespace Caliber67.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAuthorizationHelper _authorizationHelper;

        public ProductsController(IProductService productService, IAuthorizationHelper authorizationHelper)
        {
            _productService = productService;
            _authorizationHelper = authorizationHelper;
        }

        // GET: Products - All products
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsAdmin = await _authorizationHelper.IsAdminAsync(userId);

            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        // GET: Guns category
        public async Task<IActionResult> Guns()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsAdmin = await _authorizationHelper.IsAdminAsync(userId);
            ViewBag.Category = "Firearms";

            var guns = await _productService.GetProductsByCategoryAsync("Guns");
            return View("CategoryIndex", guns);
        }

        // GET: Ammo category
        public async Task<IActionResult> Ammo()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsAdmin = await _authorizationHelper.IsAdminAsync(userId);
            ViewBag.Category = "Ammunition";

            var ammo = await _productService.GetProductsByCategoryAsync("Ammo");
            return View("CategoryIndex", ammo);
        }

        // GET: Accessories category
        public async Task<IActionResult> Accessories()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsAdmin = await _authorizationHelper.IsAdminAsync(userId);
            ViewBag.Category = "Accessories";

            var accessories = await _productService.GetProductsByCategoryAsync("Accessories");
            return View("CategoryIndex", accessories);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Category,SubCategory,Caliber,Manufacturer,StockQuantity,ImageUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Category,SubCategory,Caliber,Manufacturer,StockQuantity,ImageUrl,CreatedDate")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.UpdateProductAsync(product);
                }
                catch
                {
                    if (!await ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductExists(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return product != null;
        }
    }
}