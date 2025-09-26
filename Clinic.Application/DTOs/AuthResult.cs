using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
    }
}
