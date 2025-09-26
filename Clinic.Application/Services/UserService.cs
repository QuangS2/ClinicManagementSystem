using AutoMapper;
using Clinic.Application.DTOs;
using Clinic.Application.Interfaces;
using Clinic.Domain.Entities;
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
        public UserService(IUserRepository userRepository, IAuthService authService, IMapper mapper)
        {
            _userRepository = userRepository;
            _authService = authService;
            _mapper = mapper;
        }
        public async Task<string?> LoginAsync(UserLoginDto loginDto)
        {
            var user = await _userRepository.GetUserByUsernameAsync(loginDto.Username);
            if (user == null || !_authService.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                return null;
            }
            return await _authService.GenerateToken(user);
        }

        public async Task<bool> RegisterAsync(UserRegisterDto registerDto)
        {
            var userExists = await _userRepository.GetUserByUsernameAsync(registerDto.Username);
            if (userExists != null)
            {
                return false;
            }
            var user = _mapper.Map<User>(registerDto);
            user.PasswordHash = _authService.HashPassword(registerDto.Password);
            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;

        }
    }
}
