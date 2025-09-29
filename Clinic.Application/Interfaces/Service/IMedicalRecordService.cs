using Clinic.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces.Service
{
    public interface IMedicalRecordService
    {
        //create medical record with dto
        Task<MedicalRecordDto> CreateMedicalRecordAsync(CreateMedicalRecordRequest dto);
        //get medical record by id
        Task<MedicalRecordDto> GetMedicalRecordByIdAsync(int id);
        //update medical record with dto
        Task UpdateMedicalRecordAsync(int id, UpdateMedicalRecordRequest dto);
        //delete medical record by id
        Task DeleteMedicalRecordAsync(int id);
        // get medical records by patient id
        Task<List<MedicalRecordDto>> GetMedicalRecordsByPatientIdAsync(int patientId);
    }
}
