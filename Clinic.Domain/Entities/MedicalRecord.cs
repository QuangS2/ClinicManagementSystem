using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class MedicalRecord
    {
        //1 patient can have many medical records
        //medical record belongs to one patient
        //medical belongs 1 appointment
        //medical record has 1 prescription,diagnosis,notes, visits date
        public int Id { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; } 

        //1 doctor create many medical
        public string DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; } 


        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }


        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }
        public DateTime VisitDate { get; set; }



    }
}
