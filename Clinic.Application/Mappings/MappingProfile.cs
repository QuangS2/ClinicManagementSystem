using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clinic.Application.DTOs;
using Clinic.Domain.Entities;

namespace Clinic.Application.Mappings
{
    public class MappingProfile :  Profile
    {
        public MappingProfile()
        {
            // DTO -> Entity
            CreateMap<PatientUpdateDto, Patient>();
            CreateMap<PatientCreateDto, Patient>();
            CreateMap<UserRegisterDto, ApplicationUser>();
            CreateMap<UserLoginDto, ApplicationUser>();
            CreateMap<UserUpdateDto, ApplicationUser>();
            //request to appointment
            CreateMap<AppointmentRequest, Appointment>();
            //request to medical record
            CreateMap<CreateMedicalRecordRequest, MedicalRecord>();
            //request to update medical record
            CreateMap<UpdateMedicalRecordRequest, MedicalRecord>();




            // Entity -> DTO
            CreateMap<Patient, PatientDto>();
            // appointment to response
            CreateMap<Appointment, AppointmentResponse>();
            // medical record to response
            CreateMap<MedicalRecord, MedicalRecordDto>();
        }
    }
}
