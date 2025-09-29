using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Application.DTOs;
using Clinic.Domain.Entities;

namespace Clinic.Application.Interfaces.Service
{
    public interface IInvoiceService
    {
        //curd, add payment
        
        Task<InvoiceResponseDto> CreateInvoiceAsync(CreateInvoiceDto createInvoiceDto);
        Task<InvoiceResponseDto> GetInvoiceByIdAsync(int id);
        Task<IEnumerable<InvoiceResponseDto>> GetAllInvoicesAsync();
        Task<InvoiceResponseDto> UpdateInvoiceAsync(int id, UpdateInvoiceDto invoiceDto);
        Task<bool> DeleteInvoiceAsync(int id);
        Task<PaymentResponseDto> AddPaymentAsync(int invoiceId, Payment payment);
        Task<IEnumerable<InvoiceResponseDto>> GetInvoicesByPatientIdAsync(int patientId);
        Task<IEnumerable<InvoiceResponseDto>> GetUnpaidInvoicesAsync();
        Task MarkInvoiceAsPaidAsync(int invoiceId);
        Task<IEnumerable<InvoiceResponseDto>> GetInvoicesByAppointmentIdAsync(int appointmentId);
        Task<IEnumerable<PaymentResponseDto>> GetPaymentsByInvoiceIdAsync(int invoiceId);

        
    }
}
