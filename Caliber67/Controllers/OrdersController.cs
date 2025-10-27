using Caliber67.Data;
using Caliber67.Models.Identity;
using Caliber67.Models.Orders;
using Caliber67.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Caliber67.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public OrdersController(IShoppingCartService shoppingCartService,
                              UserManager<ApplicationUser> userManager,
                              ApplicationDbContext context)
        {
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Create()
        {
            // This will show the checkout form
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                // Process the order
                // This would typically involve payment processing, etc.
                TempData["Success"] = "Order placed successfully!";
                return RedirectToAction("Index", "Home");
            }
            return View(order);
        }
    }
}