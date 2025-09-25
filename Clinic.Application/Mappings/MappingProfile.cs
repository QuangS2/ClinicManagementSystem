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
            // Entity -> DTO
            CreateMap<Patient, PatientDto>();
        }
    }
}
