using Clinic.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserRegisterDto registerDto);
        Task<string?> LoginAsync(UserLoginDto loginDto);
    }
}
