using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public string DoctorId { get; set; } = string.Empty;
        public ApplicationUser Doctor { get; set; }
        public string Reason { get; set; } = string.Empty;
        public AppointmentStatus Notes { get; set; } = AppointmentStatus.Pending;
        //one appointment has one medical record
        public MedicalRecord? MedicalRecord { get; set; }
        //one appointment has one invoice
        public Invoice? Invoice { get; set; }
    }
    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }
}
