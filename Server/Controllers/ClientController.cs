
using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using Dal.Models;
using Dal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Dto;
using System.Collections.Generic;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IBlClient _clientService;

        public ClientController(IblMANanager iblMANanager)
        {
            _clientService = iblMANanager.BlClients;
        }

        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            return _clientService.Read();
        }

        // אם הלקוח קיים כניסה למערכת לפי תעודת זהות.
        [HttpGet("check-client/{id}")]
        public ActionResult Login(string id)
        {
            var existingClient = _clientService.Login(id);
            if (existingClient != null)
            {
                // Return a JSON object with the client's ID
                return Ok(new { id = existingClient });
            }
            return NotFound("Client does not exist.");
        }

        [HttpPost("sign-up")]
        public ActionResult SignUp([FromBody] ClientAddressDto clientAddressDto)
        {
            var newClientId = _clientService.SignUp(clientAddressDto.Client, clientAddressDto.Address);
            if (newClientId != null)
            {
                // Return a JSON object with the new client's ID
                return Ok(new { id = newClientId });
            }
            return BadRequest("Unable to create client.");
        }


        //כניסת לקוח למערכת אם הלקוח לא קיים- יצירת לקוח חדש.
        //[HttpPost]
        //public ActionResult<string> Post([FromBody] ClientAddressDto clientAddressDto)
        //{
        //   return _clientService.SignUp(clientAddressDto.Client, clientAddressDto.Address);
        //}
        

        [HttpPut]
        public ActionResult<Client> Put([FromBody] Client client)
        {
            _clientService.UpDate(client);
            return client;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var client = _clientService.Read().FirstOrDefault(c => c.Id.Equals(id));
            if (client == null)
            {
                return NotFound();
            }

            _clientService.Delete(client);
            return NoContent();
        }
    }
}
