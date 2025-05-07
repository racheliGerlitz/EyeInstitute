using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

namespace BL.Api
{
    public interface IBlDoctor
    {
        void Create(Doctor item);
        List<Doctor> Read();
        void Delete(Doctor item);
        void UpDate(Doctor item);
        public List<Doctor> ChooseADoctor( string Specialization);
    }
}
