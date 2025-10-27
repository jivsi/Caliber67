using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Caliber67.Data;
using Caliber67.Models;
using Caliber67.Helpers;

namespace Caliber67.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationHelper _authorizationHelper;

        public ProductsController(ApplicationDbContext context, IAuthorizationHelper authorizationHelper)
        {
            _context = context;
            _authorizationHelper = authorizationHelper;
        }

        // GET: Products - All products
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsAdmin = await _authorizationHelper.IsAdminAsync(userId);

            return View(await _context.Products.ToListAsync());
        }

        // GET: Guns category
        public async Task<IActionResult> Guns()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsAdmin = await _authorizationHelper.IsAdminAsync(userId);
            ViewBag.Category = "Firearms";

            var guns = await _context.Products
                .Where(p => p.Category == "Guns")
                .ToListAsync();

            return View("CategoryIndex", guns);
        }

        // GET: Ammo category
        public async Task<IActionResult> Ammo()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsAdmin = await _authorizationHelper.IsAdminAsync(userId);
            ViewBag.Category = "Ammunition";

            var ammo = await _context.Products
                .Where(p => p.Category == "Ammo")
                .ToListAsync();

            return View("CategoryIndex", ammo);
        }

        // GET: Accessories category
        public async Task<IActionResult> Accessories()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsAdmin = await _authorizationHelper.IsAdminAsync(userId);
            ViewBag.Category = "Accessories";

            var accessories = await _context.Products
                .Where(p => p.Category == "Accessories")
                .ToListAsync();

            return View("CategoryIndex", accessories);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsAdmin = await _authorizationHelper.IsAdminAsync(userId);

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
                product.CreatedDate = DateTime.UtcNow;
                _context.Add(product);
                await _context.SaveChangesAsync();
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

            var product = await _context.Products.FindAsync(id);
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
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        // GET: Products/Search
        public async Task<IActionResult> Search(string searchString)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsAdmin = await _authorizationHelper.IsAdminAsync(userId);

            if (string.IsNullOrEmpty(searchString))
            {
                return View("Index", await _context.Products.ToListAsync());
            }

            var products = await _context.Products
                .Where(p => p.Name.Contains(searchString) ||
                           p.Description.Contains(searchString) ||
                           p.Manufacturer.Contains(searchString) ||
                           p.Caliber.Contains(searchString))
                .ToListAsync();

            ViewBag.SearchString = searchString;
            return View("Index", products);
        }

        // GET: Products/BySubCategory?subCategory=Handgun
        public async Task<IActionResult> BySubCategory(string subCategory)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsAdmin = await _authorizationHelper.IsAdminAsync(userId);
            ViewBag.SubCategory = subCategory;

            var products = await _context.Products
                .Where(p => p.SubCategory == subCategory)
                .ToListAsync();

            return View("SubCategoryIndex", products);
        }

        // GET: Products/ByCaliber?caliber=9mm
        public async Task<IActionResult> ByCaliber(string caliber)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.IsAdmin = await _authorizationHelper.IsAdminAsync(userId);
            ViewBag.Caliber = caliber;

            var products = await _context.Products
                .Where(p => p.Caliber == caliber)
                .ToListAsync();

            return View("CaliberIndex", products);
        }
    }
}