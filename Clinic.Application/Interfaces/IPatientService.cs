using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Application.DTOs;
namespace Clinic.Application.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto?> GetPatientByIdAsync(int id);
        Task<PatientDto> CreatePatientAsync(PatientCreateDto patientCreateDto);
        Task UpdatePatientAsync(int id, PatientUpdateDto patientUpdateDto);
        Task DeletePatientAsync(int id);
    }
}
