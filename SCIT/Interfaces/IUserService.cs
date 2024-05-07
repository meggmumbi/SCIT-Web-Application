using Microsoft.AspNetCore.Identity;
using SCIT.Entities;

namespace SCIT.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<IdentityResult> CreateUserAsync(string email, string password);
    }
}
