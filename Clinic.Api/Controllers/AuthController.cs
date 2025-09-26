using Clinic.Application.DTOs;
using Clinic.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
        {
            var result = await _userService.RegisterAsync(registerDto);
            if (result)
            {
                return Ok("User registered successfully.");
            }
            return BadRequest("User registration failed.");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var token = await _userService.LoginAsync(loginDto);
            if (token == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            return Ok(new { Token = token });
        }
    }
}
