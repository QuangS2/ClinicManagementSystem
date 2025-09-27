using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    [Table("Users")]
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Role { get; set; } = "User"; // e.g., Admin, Doctor, Receptionist
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = false;

        //doctor have many appointments
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();



    }
}
