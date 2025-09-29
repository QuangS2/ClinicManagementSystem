using Clinic.Application.DTOs;
using Clinic.Application.Interfaces.Service;
using Clinic.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        //user manager and role manager
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public AuthController(IAuthService authService, IUserService userService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _authService = authService;
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
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
        //assign role to user
        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole(string userId, string roleName)
        {
            //find user by id by user manager
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            //check if role exists by role manager
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                return NotFound("Role not found.");
            }
            //assign role to user by user manager
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok("Role assigned successfully.");
            }
            return BadRequest("Role assignment failed.");

        }
    }
}
