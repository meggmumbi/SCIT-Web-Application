using Microsoft.AspNetCore.Identity;
using SCIT.Entities;
using SCIT.Interfaces;

namespace SCIT.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> CreateUserAsync(string email, string password, string role, string? staffId)
        {
            var user = new ApplicationUser { UserName = email, Email = email, Role = role, StaffId = staffId };
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> CheckPasswordSignInAsync(ApplicationUser user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }
    }
}
