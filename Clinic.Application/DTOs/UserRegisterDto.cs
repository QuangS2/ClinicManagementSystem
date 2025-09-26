using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class UserRegisterDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
    }
}
