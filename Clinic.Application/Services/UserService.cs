using AutoMapper;
using Clinic.Application.DTOs;
using Clinic.Application.Interfaces;
using Clinic.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        private readonly UserManager<ApplicationUser> _userManager;


        public UserService(IUserRepository userRepository, IAuthService authService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _authService = authService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<string?> LoginAsync(UserLoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            //verify password by user manager
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return null;
            }

            return await _authService.GenerateToken(user);
        }

        public async Task<bool> RegisterAsync(UserRegisterDto registerDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerDto.UserName);
            if (userExists != null)
            {
                return false;
            }
            var user = _mapper.Map<ApplicationUser>(registerDto);
            var result = await _userManager.CreateAsync(user,registerDto.Password);
            if (!result.Succeeded)
            {
                return false;
            }

            return true;

        }
    }
}
