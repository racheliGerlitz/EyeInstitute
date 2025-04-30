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
    public class BlAddressService : IBlAddress
    {
        private readonly IAddress address;

        public BlAddressService(IDal dal)
        {
            address = dal.address;
        }

        public int Create(Address item)
        {
           return address.Create(item);
        }

        public void Delete(Address item)
        {
            address.Delete(item);
        }

        public List<Address> Read()
        {
            return address.Read();
        }

        public void UpDate(Address item)
        {
            address.UpDate(item);
        }
    }
}
