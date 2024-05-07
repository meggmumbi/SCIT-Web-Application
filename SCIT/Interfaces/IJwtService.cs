using SCIT.Entities;

namespace SCIT.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(ApplicationUser user);
        Task<string> GenerateJwtTokenAsync(string email, string password);
    }
}
