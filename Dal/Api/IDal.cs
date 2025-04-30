using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api;

public interface IDal
{           
       public Iclient client { get; }
        public Idoctor doctor { get; }
       public IApointment appointment { get; }

    public IAddress address { get; }

}
