using Clinic.Application.DTOs;
using Clinic.Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientCreateDto patientDtos)
        {
            var createdPatient = await _patientService.CreatePatientAsync(patientDtos);
            return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.Id }, createdPatient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientUpdateDto patientDto)
        {
            var existingPatient = await _patientService.GetPatientByIdAsync(id);
            if (existingPatient == null)
            {
                return NotFound();
            }
            await _patientService.UpdatePatientAsync(id, patientDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var existingPatient = await _patientService.GetPatientByIdAsync(id);
            if (existingPatient == null)
            {
                return NotFound();
            }
            await _patientService.DeletePatientAsync(id);
            return NoContent();
        }
    }
}
