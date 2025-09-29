using Clinic.Application.Interfaces.Repository;
using Clinic.Domain.Entities;
using Clinic.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;
        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Invoice> AddAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task DeleteAsync(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await Task.FromResult(_context.Invoices.ToList());
        }

        public async Task<Invoice?> GetByAppointmentIdAsync(int appointmentId)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.AppointmentId == appointmentId);
            return await Task.FromResult(invoice);
        }

        public async Task<Invoice?> GetByIdAsync(int id)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.Id == id);
            return await Task.FromResult(invoice);
        }

        public async Task<IEnumerable<Invoice>> GetByPatientIdAsync(int patientId)
        {
            var invoices = _context.Invoices.Where(i => i.PatientId == patientId).ToList();
            return await Task.FromResult(invoices);
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
        }
    }
}
