using AutoMapper;
using Clinic.Application.DTOs;
using Clinic.Application.Interfaces.Repository;
using Clinic.Application.Interfaces.Service;
using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        //Imapper
        private readonly IMapper _mapper;
        public async Task<PaymentResponseDto> AddPaymentAsync(int invoiceId, Payment payment)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice == null)
            {
                throw new Exception("Invoice not found");
            }
            // Add payment to invoice
            invoice.Payments.Add(payment);
            invoice.AmountPaid += payment.Amount;
            // Check if invoice is fully paid
            if (invoice.AmountPaid >= invoice.TotalAmount)
            {
                invoice.IsPaid = true;
            }
            await _invoiceRepository.UpdateAsync(invoice);
            return _mapper.Map<PaymentResponseDto>(payment);
        }

        public async Task<InvoiceResponseDto> CreateInvoiceAsync(CreateInvoiceDto createInvoiceDto)
        {
            var invoice = _mapper.Map<Invoice>(createInvoiceDto);
            invoice.IsPaid = false;
            invoice.AmountPaid = 0;
            invoice.Payments = new List<Payment>();
            await _invoiceRepository.AddAsync(invoice);
            return _mapper.Map<InvoiceResponseDto>(invoice);
        }

        public async Task<bool> DeleteInvoiceAsync(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                return false;
            }
            await _invoiceRepository.DeleteAsync(invoice);
            return true;
        }

        public async Task<IEnumerable<InvoiceResponseDto>> GetAllInvoicesAsync()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InvoiceResponseDto>>(invoices);
        }

        public async Task<InvoiceResponseDto> GetInvoiceByIdAsync(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                throw new Exception("Invoice not found");
            }
            return _mapper.Map<InvoiceResponseDto>(invoice);
        }

        public async Task<IEnumerable<InvoiceResponseDto>> GetInvoicesByAppointmentIdAsync(int appointmentId)
        {
            var invoice = await _invoiceRepository.GetByAppointmentIdAsync(appointmentId);
            if (invoice == null)
            {
                throw new Exception("Invoice not found");
            }
            return new List<InvoiceResponseDto> { _mapper.Map<InvoiceResponseDto>(invoice) };
        }

        public async Task<IEnumerable<InvoiceResponseDto>> GetInvoicesByPatientIdAsync(int patientId)
        {
            var invoices = await _invoiceRepository.GetByPatientIdAsync(patientId);
            return _mapper.Map<IEnumerable<InvoiceResponseDto>>(invoices);
        }

        public async Task<IEnumerable<PaymentResponseDto>> GetPaymentsByInvoiceIdAsync(int invoiceId)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice == null)
            {
                throw new Exception("Invoice not found");
            }
            return _mapper.Map<IEnumerable<PaymentResponseDto>>(invoice.Payments);
        }

        public async Task<IEnumerable<InvoiceResponseDto>> GetUnpaidInvoicesAsync()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            var unpaidInvoices = invoices.Where(i => !i.IsPaid);
            return _mapper.Map<IEnumerable<InvoiceResponseDto>>(unpaidInvoices);
        }

        public async Task MarkInvoiceAsPaidAsync(int invoiceId)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice == null)
            {
                throw new Exception("Invoice not found");
            }
            invoice.IsPaid = true;
            invoice.AmountPaid = invoice.TotalAmount;
            await _invoiceRepository.UpdateAsync(invoice);
        }

        public async Task<InvoiceResponseDto> UpdateInvoiceAsync(int id, UpdateInvoiceDto invoiceDto)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
            {
                throw new Exception("Invoice not found");
            }
            // Update fields by mapper
            _mapper.Map(invoiceDto, invoice);
            await _invoiceRepository.UpdateAsync(invoice);
            return _mapper.Map<InvoiceResponseDto>(invoice);
        }
    }
}
