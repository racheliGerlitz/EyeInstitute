
using BL.Api;
using BL.Models;
using BL.Service;
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
    public class DoctorController : ControllerBase
    {
        private readonly IBlDoctor _doctorService;

        public DoctorController(IblMANanager iblMANanager)
        {
            _doctorService = iblMANanager.BlDoctors;
        }

        [HttpGet]
        public ActionResult<List<Doctor>> Get()
        {
            return _doctorService.Read();
        }

        [HttpPost]
        public ActionResult<Doctor> Post([FromBody] Doctor doctor)
        {
            _doctorService.Create(doctor);
            return CreatedAtAction(nameof(Get), new { id = doctor.Id }, doctor);
        }

        [HttpPut]
        public ActionResult<Doctor> Put([FromBody] Doctor doctor)
        {
            _doctorService.UpDate(doctor);
            return doctor;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var doctor = _doctorService.Read().FirstOrDefault(c => c.Id.Equals(id));
            if (doctor == null)
            {
                return NotFound();
            }

            _doctorService.Delete(doctor);
            return NoContent();
        }

        [HttpGet("choose-appointment/{specialization}")]
        public ActionResult<List<Doctor>> ChooseADoctor([FromRoute] string specialization)
        {
            return _doctorService.ChooseADoctor(specialization);
        }
    }
}
