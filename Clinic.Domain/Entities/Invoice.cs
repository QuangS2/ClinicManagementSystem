using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }

        //belongs to one patient
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        //belongs to one appointment
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        // total amount
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        // amount paid
        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountPaid { get; set; }
        // is paid
        public bool IsPaid { get; set; }
        //times
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }
        //notes
        public string? Notes { get; set; }

        // have many payments
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    }
}
