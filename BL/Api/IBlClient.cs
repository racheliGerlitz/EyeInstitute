using BL.Models;
using Dal.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlClient
    {

        void Create(Client item);
        List<Client> Read();
        void Delete(Client item);
        void UpDate(Client item);
        Client Login(string id);

        string SignUp(Client client,Address address);

        public List<EmpForPhone> GetPhoneList();
       

    }
}
