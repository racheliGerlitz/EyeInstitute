using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IblMANanager
    {
        public IBlClient BlClients { get;}
        public IBlAppointment? BlAppointment { get; }
        public IBlDoctor BlDoctors { get; }
    }
}
