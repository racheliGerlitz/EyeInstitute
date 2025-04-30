using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IAddress 
    {
        int Create(Address item);
        List<Address> Read();
        void Delete(Address item);
        void UpDate(Address item);
    }
}
