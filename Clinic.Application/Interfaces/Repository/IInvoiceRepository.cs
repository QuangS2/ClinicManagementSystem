using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces.Repository
{
    public interface IInvoiceRepository
    {
        //create
        Task<Domain.Entities.Invoice> AddAsync(Domain.Entities.Invoice invoice);
        //read
        Task<IEnumerable<Domain.Entities.Invoice>> GetAllAsync();
        //get by patient id
        Task<IEnumerable<Domain.Entities.Invoice>> GetByPatientIdAsync(int patientId);
        //get by appointment id
        Task<Domain.Entities.Invoice?> GetByAppointmentIdAsync(int appointmentId);
        //update
        Task UpdateAsync(Domain.Entities.Invoice invoice);
        //delete
        Task DeleteAsync(Domain.Entities.Invoice invoice);
        //get by id
        Task<Domain.Entities.Invoice?> GetByIdAsync(int id);
    }
}
