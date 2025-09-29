using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class InvoiceDto
    {
    }
    //create a dto for invoice
    public class CreateInvoiceDto
    {
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? Notes { get; set; }
    }
    //invoice dto for update for amount, duate and notes
    public class UpdateInvoiceDto
    {
        public decimal Amount { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Notes { get; set; }
    }
    //response dto
    public class InvoiceResponseDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Notes { get; set; }
    }
}
