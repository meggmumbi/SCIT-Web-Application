namespace SCIT.Entities
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        public string? StaffId { get; set; }
    }
}
