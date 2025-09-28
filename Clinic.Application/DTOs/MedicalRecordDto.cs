using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class MedicalRecordDto
    {
        //Medical Record DTO for response
        public int Id { get; set; }
        //patient name
        public string PatientName { get; set; } = string.Empty;
        //doctor name
        public string DoctorName { get; set; } = string.Empty;
        public int AppointmentId { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Prescription { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime VisitDate { get; set; }
    }
    public class CreateMedicalRecordRequest
    {
        public int PatientId { get; set; }
        public string DoctorId { get; set; } = string.Empty;
        public int AppointmentId { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Prescription { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime VisitDate { get; set; }
    }
    public class UpdateMedicalRecordRequest
    {
        public string Diagnosis { get; set; } = string.Empty;
        public string Prescription { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime VisitDate { get; set; }
    }
}
