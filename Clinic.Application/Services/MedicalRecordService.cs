using AutoMapper;
using Clinic.Application.DTOs;
using Clinic.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _repository;
        private readonly IMapper _mapper;

        public MedicalRecordService(IMedicalRecordRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MedicalRecordDto> CreateMedicalRecordAsync(CreateMedicalRecordRequest dto)
        {
            //map dto to entity
            var medicalRecord = _mapper.Map<Domain.Entities.MedicalRecord>(dto);
            //save to database
            var createdRecord = await _repository.AddAsync(medicalRecord);
            //map entity to dto
            return _mapper.Map<MedicalRecordDto>(createdRecord);
        }

        public async Task DeleteMedicalRecordAsync(int id)
        {
            var record = await _repository.GetByIdAsync(id);
            if (record == null)
            {
                throw new Exception("Medical record not found");
            }
            await _repository.DeleteAsync(record);
        }

        public async Task<MedicalRecordDto> GetMedicalRecordByIdAsync(int id)
        {
            var record = await _repository.GetByIdAsync(id);
            if (record == null)
            {
                throw new Exception("Medical record not found");
            }
            return _mapper.Map<MedicalRecordDto>(record);
        }

        public async Task<List<MedicalRecordDto>> GetMedicalRecordsByPatientIdAsync(int patientId)
        {
            var records = await _repository.GetByPatientIdAsync(patientId);
            return _mapper.Map<List<MedicalRecordDto>>(records);
        }

        public async Task UpdateMedicalRecordAsync(int id, UpdateMedicalRecordRequest dto)
        {
            var record = await _repository.GetByIdAsync(id);
            if (record == null)
            {
                throw new Exception("Medical record not found");
            }
            //map dto to entity
            _mapper.Map(dto, record);
            await _repository.UpdateAsync(record);
        }
    }
}
