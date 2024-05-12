using Microsoft.AspNetCore.Identity;

namespace SCIT.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }

        public string? StaffId { get; set; }
    }
}
