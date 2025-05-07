
using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using Dal.Models;
using Dal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IBlAppointment _appointmentService;

        public AppointmentController(IblMANanager iblMANanager)
        {
            _appointmentService = iblMANanager.BlAppointment;
        }

        [HttpGet]
        public ActionResult<List<Appointment>> Get()
        {
            return _appointmentService.Read();
        }

        [HttpPost]
        public ActionResult<Appointment> Post([FromBody] Appointment Appointment)
        {
            _appointmentService.Create(Appointment);
            return CreatedAtAction(nameof(Get), new { id = Appointment.Id }, Appointment);
        }

        [HttpPut]
        public ActionResult<Appointment> Put([FromBody] Appointment Appointment)
        {
            _appointmentService.UpDate(Appointment);
            return Appointment;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var Appointment = _appointmentService.Read().FirstOrDefault(c => c.Id.Equals(id));
            if (Appointment == null)
            {
                return NotFound();
            }

            _appointmentService.Delete(Appointment);
            return NoContent();
        }
        [HttpGet("appointments/{id}")]
        public ActionResult<List<Appointment>> GetAppointments([FromRoute]int id)
        {
            var appointments = _appointmentService.ChooseAnAppointment(id);
            if (appointments == null || appointments.Count == 0)
            {
                return NotFound();
            }
            return Ok(appointments);
        }
    }
}
