using AutoMapper;
using Clinic.Application.DTOs;
using Clinic.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Domain.Entities;

namespace Clinic.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IMapper mapper, IAppointmentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<AppointmentResponse> CreateAsync(AppointmentRequest request)
        {
            var appointment = _mapper.Map<Appointment>(request);
            var createdAppointment = await _repository.AddAsync(appointment);
            return _mapper.Map<AppointmentResponse>(createdAppointment);
        }

        public async Task<List<AppointmentResponse>> GetAllAsync()
        {
            var appointments = await _repository.GetAllAsync();
            return _mapper.Map<List<AppointmentResponse>>(appointments);
        }

        public async Task<AppointmentResponse> GetByIdAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException("Appointment not found");
            }
            return _mapper.Map<AppointmentResponse>(appointment);
        }

        public async Task<AppointmentResponse> UpdateAsync(int id, AppointmentRequest request)
        {
            var appointment = await _repository.GetByIdAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException("Appointment not found");
            }
            _mapper.Map(request, appointment);
            await _repository.UpdateAsync(appointment);
            return _mapper.Map<AppointmentResponse>(appointment);
        }
    }
}
