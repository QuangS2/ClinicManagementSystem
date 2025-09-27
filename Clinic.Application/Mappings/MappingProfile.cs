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




            // Entity -> DTO
            CreateMap<Patient, PatientDto>();
            // appointment to response
            CreateMap<Appointment, AppointmentResponse>();
            
        }
    }
}
