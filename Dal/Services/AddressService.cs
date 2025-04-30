using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    internal class AddressService : IAddress
    {
        
        DatabaseManager db;
        public AddressService(DatabaseManager db)
        {
            this.db = db;
        }

        public int Create(Address item)
        {
            var addedAddress = db.Add(item);

            db.SaveChanges();

            return addedAddress.Entity.Id;
        }

        public void Delete(Address item)
        {
            db.Addresses.Remove(item);
            db.SaveChanges();
        }

        public List<Address> Read()
        {
            return db.Addresses.ToList();
        }
        public void UpDate(Address item)
        {
            Address e = db.Addresses.FirstOrDefault(e => e.Id == item.Id);
            if (e == null) return;
            e.HouseNumber = item.HouseNumber;
            e.Street = item.Street;
            e.City = item.City;
            db.SaveChanges(true);
        }
    }
}

