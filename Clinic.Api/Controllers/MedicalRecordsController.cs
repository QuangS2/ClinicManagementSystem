using Clinic.Application.DTOs;
using Clinic.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        // Iservice 
        private readonly IMedicalRecordService _medicalRecordService;
        public MedicalRecordsController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        // get medical record by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalRecordById(int id)
        {
            var medicalRecord = await _medicalRecordService.GetMedicalRecordByIdAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return Ok(medicalRecord);
        }

        // create medical record
        [HttpPost]
        public async Task<IActionResult> CreateMedicalRecord([FromBody] CreateMedicalRecordRequest dto)
        {
            var medicalRecord = await _medicalRecordService.CreateMedicalRecordAsync(dto);
            return CreatedAtAction(nameof(GetMedicalRecordById), new { id = medicalRecord.Id }, medicalRecord);
        }
        
        // update medical record
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalRecord(int id, [FromBody] UpdateMedicalRecordRequest dto)
        {
            var existingRecord = await _medicalRecordService.GetMedicalRecordByIdAsync(id);
            if (existingRecord == null)
            {
                return NotFound();
            }
            await _medicalRecordService.UpdateMedicalRecordAsync(id, dto);
            return NoContent();
        }
        // delete medical record
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalRecord(int id)
        {
            var existingRecord = await _medicalRecordService.GetMedicalRecordByIdAsync(id);
            if (existingRecord == null)
            {
                return NotFound();
            }
            await _medicalRecordService.DeleteMedicalRecordAsync(id);
            return NoContent();
        }
        // get medical records by patient id
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetMedicalRecordsByPatientId(int patientId)
        {
            var medicalRecords = await _medicalRecordService.GetMedicalRecordsByPatientIdAsync(patientId);
            return Ok(medicalRecords);
        }
    }
}