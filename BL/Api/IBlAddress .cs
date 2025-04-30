using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

namespace BL.Api
{
    public interface IBlAddress
    {
        int Create(Address item);
        List<Address> Read();
        void Delete(Address item);
        void UpDate(Address item);
    }
}
