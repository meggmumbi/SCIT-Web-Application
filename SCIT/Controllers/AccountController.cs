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

            var result = await _userService.CreateUserAsync(model.Email, model.Password);
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
                var token = await _jwtService.GenerateJwtTokenAsync(model.Email, model.Password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
