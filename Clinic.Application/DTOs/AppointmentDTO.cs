using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs
{
    public class AppointmentDto
    {
    }
    //AppointmentRequest
    public class AppointmentRequest
    {
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string PatientId { get; set; } = string.Empty;
        public string DoctorId { get; set; } = string.Empty;
    }
    //AppointmentResponse
    public class AppointmentResponse
    {
        public string Id { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
