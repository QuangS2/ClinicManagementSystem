using Clinic.Application.Interfaces.Repository;
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
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _db;
        public PatientRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<Patient> AddAsync(Patient patient)
        {
            _db.Patients.Add(patient);
            await _db.SaveChangesAsync();
            return patient;
        }

        public async Task DeleteAsync(Patient patient)
        {
            _db.Patients.Remove(patient);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _db.Patients.ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _db.Patients.FindAsync(id);
        }

        public async Task UpdateAsync(Patient patient)
        {
            _db.Patients.Update(patient);
            await _db.SaveChangesAsync();
        }
    }
}
