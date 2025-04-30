using BL.Api;
using BL.Models;
using BL.Service;
using Dal.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dal.Models;
using Dal.Models;
using Dal.Services;


namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLController : ControllerBase
    {
        IBlClient ClientsActions;
        IBlDoctor DoctorsActions;
        IBlAppointment AppointmentsActions;


        public BLController(IblMANanager iblMANanager)
        {
            this.ClientsActions = iblMANanager.BlClients;
            this.DoctorsActions = iblMANanager.BlDoctors;
            this.AppointmentsActions = iblMANanager.BlAppointment;
        }

        [HttpPost]

        public ActionResult<Client> Create([FromBody] Client emp)
        {
            ClientsActions.Create(emp);
            return emp;
        }
        [HttpGet]
        public ActionResult<List<EmpForPhone>> GetPhoneList()
        {
            return ClientsActions.GetPhoneList();

        }


    }
}

