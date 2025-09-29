using Clinic.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clinic.Application.DTOs;
using Clinic.Application.Interfaces.Service;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        //service
        private readonly IAppointmentService _appointmentService;
        //constructor
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        //get appointments by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _appointmentService.GetByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        // Create appointment
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AppointmentRequest request)
        {
            var response = await _appointmentService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
        //get all appointments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _appointmentService.GetAllAsync();
            return Ok(response);
        }


    }
}
