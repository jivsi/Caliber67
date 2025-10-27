using Microsoft.AspNetCore.Identity;
using Caliber67.Models.Identity;

namespace Caliber67.Helpers
{
    public interface IAuthorizationHelper
    {
        Task<bool> IsAdminAsync(string userId);
    }

    public class AuthorizationHelper : IAuthorizationHelper
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorizationHelper(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> IsAdminAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return false;

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            return await _userManager.IsInRoleAsync(user, "Admin");
        }
    }
}