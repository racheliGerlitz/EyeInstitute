using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

namespace BL.Api
{
    public interface IBlAppointment
    {
        void Create(Appointment item);
        List<Appointment> Read();
        void Delete(Appointment item);
        void UpDate(Appointment item);
        List<Appointment> ChooseAnAppointment(int doctorId);
        
    }
}
