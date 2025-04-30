using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class DataContext
    {
        List<Client> Clients = new List<Client>();
        List<Doctor> Doctors = new List<Doctor>();

        public DataContext() {
            InitData();
        }
        public void InitData() { 
        DatabaseManager db=new DatabaseManager();
            db.Clients.Select(p =>p).ToList();
            db.Doctors.Select(e =>e).ToList();
        }

        
    }
}
