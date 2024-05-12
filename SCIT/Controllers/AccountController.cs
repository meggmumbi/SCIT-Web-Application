using Microsoft.AspNetCore.Mvc;
using SCIT.Entities;
using SCIT.Interfaces;
using SCIT.Services;

namespace SCIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AccountController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
        {
            var existingUser = await _userService.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return Conflict("Email already exists");
            }
            if (model.Role == "staff" && string.IsNullOrEmpty(model.StaffId))
            {
                return BadRequest("StaffId is required for staff role");
            }

            var result = await _userService.CreateUserAsync(model.Email, model.Password, model.Role, model.StaffId);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var user = await _userService.FindByEmailAsync(model.Email);
            var token = _jwtService.GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var user = await _userService.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return BadRequest("Invalid email or password");
                }

                var signInResult = await _userService.CheckPasswordSignInAsync(user, model.Password);
                if (!signInResult.Succeeded)
                {
                    return BadRequest("Invalid email or password");
                }

                var token = _jwtService.GenerateJwtToken(user);
                // Return user details along with token
                return Ok(new
                {
                    Token = token,
                    Email = user.Email,
                    Role = user.Role,
                    StaffId = user.StaffId
                    // Add other user details as needed
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
