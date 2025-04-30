using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    internal class DoctorService:Idoctor
    {
        
    
        DatabaseManager db;
        public DoctorService(DatabaseManager db)
        {
            this.db = db;
        }

        public void Create(Doctor item)
        {
            db.Add(item);
            db.SaveChanges();
        }

        public void Delete(Doctor item)
        {
            db.Doctors.Remove(item);
            db.SaveChanges();
        }

        public List<Doctor> Read()
        {
            return db.Doctors.ToList();
        }

        

        public void UpDate(Doctor item)
        {
            Doctor e = db.Doctors.FirstOrDefault(e => e.Id == item.Id);
            if (e == null) return;
            e.Id = item.Id;
            e.Name = item.Name;
            e.AddressId = item.AddressId;
            e.Specialization=item.Specialization;
            db.SaveChanges(true);

        }



    }
}

