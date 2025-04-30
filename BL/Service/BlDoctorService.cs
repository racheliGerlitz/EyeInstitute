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
    public class BLDoctorService:IBlDoctor
    {
        private readonly Idoctor bldoctor;

        public BLDoctorService(IDal dal)
        {
            bldoctor = dal.doctor;
        }

        public void Create(Doctor item)
        {
            bldoctor.Create(item);
        }

        public void Delete(Doctor item)
        {
            bldoctor.Delete(item);
        }

        public List<Doctor> Read()
        {
            return bldoctor.Read();
        }

        public void UpDate(Doctor item)
        {
            bldoctor.UpDate(item);
        }
    }
}
