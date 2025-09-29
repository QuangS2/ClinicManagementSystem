using Clinic.Application.DTOs;
using Clinic.Application.Interfaces.Service;
using Clinic.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceDto createInvoiceDto)
        {
            var invoice = await _invoiceService.CreateInvoiceAsync(createInvoiceDto);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.Id }, invoice);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await _invoiceService.DeleteInvoiceAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost("{invoiceId}/payments")]
        public async Task<IActionResult> AddPayment(int invoiceId, [FromBody] PaymentCreateDto paymentDto)
        {
            try
            {
                var payment = await _invoiceService.AddPaymentAsync(invoiceId, new Payment
                {
                    Amount = paymentDto.Amount,
                    PaymentDate = paymentDto.PaymentDate,
                    PaymentMethod = paymentDto.PaymentMethod
                });
                return CreatedAtAction(nameof(GetInvoiceById), new { id = invoiceId }, payment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, [FromBody] UpdateInvoiceDto invoiceDto)
        {
            var updatedInvoice = await _invoiceService.UpdateInvoiceAsync(id, invoiceDto);
            if (updatedInvoice == null)
            {
                return NotFound();
            }
            return Ok(updatedInvoice);
        }
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetInvoicesByPatientId(int patientId)
        {
            var invoices = await _invoiceService.GetInvoicesByPatientIdAsync(patientId);
            return Ok(invoices);
        }
        [HttpGet("unpaid")]
        public async Task<IActionResult> GetUnpaidInvoices()
        {
            var invoices = await _invoiceService.GetUnpaidInvoicesAsync();
            return Ok(invoices);
        }
        [HttpPost("{invoiceId}/mark-as-paid")]
        public async Task<IActionResult> MarkInvoiceAsPaid(int invoiceId)
        {
            try
            {
                await _invoiceService.MarkInvoiceAsPaidAsync(invoiceId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("appointment/{appointmentId}")]
        public async Task<IActionResult> GetInvoicesByAppointmentId(int appointmentId)
        {
            var invoices = await _invoiceService.GetInvoicesByAppointmentIdAsync(appointmentId);
            return Ok(invoices);
        }
        [HttpGet("{invoiceId}/payments")]
        public async Task<IActionResult> GetPaymentsByInvoiceId(int invoiceId)
        {
            var payments = await _invoiceService.GetPaymentsByInvoiceIdAsync(invoiceId);
            return Ok(payments);
        }


    }
}
// line add migration 
// dotnet ef migrations add InvoiceAndPaymentTable --project Clinic.Infrastructure --startup-project Clinic.Api
// dotnet ef database update --project Clinic.Infrastructure --startup-project Clinic.Api
//remove 
// dotnet ef migrations remove --project Clinic.Infrastructure --startup-project Clinic.Api