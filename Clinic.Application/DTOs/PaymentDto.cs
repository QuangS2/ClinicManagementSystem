using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class PaymentDto
    {
    }
    public class PaymentCreateDto
    {
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    }
    //response dto
    public class PaymentResponseDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
