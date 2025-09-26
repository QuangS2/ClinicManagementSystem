using Clinic.Application.DTOs;
using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> GenerateToken(User user);
        Task<AuthResult> LoginAsync(string username, string password);
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
