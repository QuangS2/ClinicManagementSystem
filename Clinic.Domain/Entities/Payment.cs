using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        // belongs to one invoice
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        // amount paid
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        // payment method (cash, card, insurance, etc.)
        public string PaymentMethod { get; set; }
        // payment date
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        // reference number (for card payments, insurance claims, etc.)
        public string ReferenceNumber { get; set; }
        // notes
        public string Notes { get; set; }
    }
}
