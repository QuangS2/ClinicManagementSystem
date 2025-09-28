using Clinic.Application.Interfaces;
using Clinic.Domain.Entities;
using Clinic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly ApplicationDbContext _db;
        public MedicalRecordRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<MedicalRecord> AddAsync(MedicalRecord medicalRecord)
        {
            _db.MedicalRecords.Add(medicalRecord);
            await _db.SaveChangesAsync();
            return medicalRecord;
        }

        public async Task DeleteAsync(MedicalRecord medicalRecord)
        {
            _db.MedicalRecords.Remove(medicalRecord);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<MedicalRecord>> GetAllAsync()
        {
            return await _db.MedicalRecords.ToListAsync();
        }

        public async Task<MedicalRecord?> GetByIdAsync(int id)
        {
            return await _db.MedicalRecords.FindAsync(id);
        }

        public async Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId)
        {
            return await _db.MedicalRecords
                .Where(mr => mr.PatientId == patientId)
                .ToListAsync();
        }

        public async Task UpdateAsync(MedicalRecord medicalRecord)
        {
            _db.MedicalRecords.Update(medicalRecord);
            await _db.SaveChangesAsync();
        }
    }
}
