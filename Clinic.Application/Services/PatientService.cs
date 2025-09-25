using AutoMapper;
using Clinic.Application.DTOs;
using Clinic.Application.Interfaces;
using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PatientDto> CreatePatientAsync(PatientCreateDto patientCreateDto)
        {
            var patient = _mapper.Map<Patient>(patientCreateDto);
            var createdPatient = await _repository.AddAsync(patient);
            return _mapper.Map<PatientDto>(createdPatient);
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Patient not found");
            await _repository.DeleteAsync(patient);
        }

    public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(p => _mapper.Map<PatientDto>(p));
        }

        public async Task<PatientDto?> GetPatientByIdAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient == null) return null;
            return _mapper.Map<PatientDto>(patient);
        }

        public async Task UpdatePatientAsync(int id, PatientUpdateDto patientUpdateDto)
        {
            var patient = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Patient not found");
            _mapper.Map(patientUpdateDto, patient);
            await _repository.UpdateAsync(patient);
        }
    }
}
