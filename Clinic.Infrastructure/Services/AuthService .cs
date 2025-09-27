using Clinic.Application.Interfaces;
using Clinic.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Application.DTOs;
using Clinic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;

namespace Clinic.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        
        public AuthService(IConfiguration configuration, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _context = context;
            _userManager = userManager;
        }
        public async Task<string> GenerateToken(ApplicationUser user)
        {
            var claims = new[]
            {

                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("role", user.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: creds);
            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task<AuthResult> LoginAsync(string username, string password)
        {
            // Find user by username by user manager

            var user = await _userManager.FindByNameAsync(username);
            // Check if user exists
            if (user == null)
            {
                return new AuthResult { IsSuccess = false, ErrorMessage = "User not found" };
            }
            // Verify password
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return new AuthResult { IsSuccess = false, ErrorMessage = "Invalid password" };
            }

            // Optionally check if user is active
            var token = await GenerateToken(user);
            return new AuthResult { IsSuccess = true, Token = token };
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
