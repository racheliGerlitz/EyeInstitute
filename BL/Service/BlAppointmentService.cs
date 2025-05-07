using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Api;
using Dal.Api;
using Dal.Models;

namespace BL.Service
{
    public class BlAppointmentService:IBlAppointment
    {
        private readonly IApointment apointment;

        public BlAppointmentService(IDal dal)
        {
            apointment = dal.appointment;
        }

        public void Create(Appointment item)
        {
            apointment.Create(item);
        }

        public void Delete(Appointment item)
        {
            apointment.Delete(item);
        }

        public List<Appointment> Read()
        {
            return apointment.Read();
        }

        public void UpDate(Appointment item)
        {
            apointment.UpDate(item);
        }
       public List<Appointment> ChooseAnAppointment(int doctorId)
        {
            var appointmentsByDoctor= Read().FindAll(a => a.DoctorId== doctorId);
            return appointmentsByDoctor.FindAll(a => a.ClientId == null);
        }
    }
}
