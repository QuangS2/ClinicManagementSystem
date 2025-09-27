using Clinic.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces
{
    public interface IAppointmentService
    {
        // Create async return appointmentResponse
        Task<AppointmentResponse> CreateAsync(AppointmentRequest request);
        // Get all async return list of appointmentResponse
        Task<List<AppointmentResponse>> GetAllAsync();
        // Get by id async return appointmentResponse
        Task<AppointmentResponse> GetByIdAsync(int id);
        // Update async return appointmentResponse
        Task<AppointmentResponse> UpdateAsync(int id, AppointmentRequest request);

    }
}
