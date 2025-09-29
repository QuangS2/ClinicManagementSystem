using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces.Repository
{
    public interface IMedicalRecordRepository
    {
        //create
        Task<MedicalRecord> AddAsync(MedicalRecord medicalRecord);
        //read
        Task<IEnumerable<MedicalRecord>> GetAllAsync();
        //get medical records by patient id
        Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId);
        //update
        Task UpdateAsync(MedicalRecord medicalRecord);
        //delete
        Task DeleteAsync(MedicalRecord medicalRecord);
        //get by id
        Task<MedicalRecord?> GetByIdAsync(int id);

    }
}
