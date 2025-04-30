using Dal.Api;
using Dal.Models;
using Dal.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dal
{
    public class DalMannager : IDal
    {
        public Iclient client { get; }
        public Idoctor doctor { get; }
        public IApointment appointment { get; }
        public IAddress address { get; }
        public DalMannager()
        {

            ServiceCollection service = new ServiceCollection();
            service.AddSingleton<DatabaseManager>();
            service.AddSingleton<Iclient, ClientService>();
            service.AddSingleton<IApointment, AppointmentsService>();
            service.AddSingleton<Idoctor,DoctorService>();
            service.AddSingleton<IAddress, AddressService>();

            ServiceProvider serviceProvider = service.BuildServiceProvider();

            client = serviceProvider.GetService<Iclient>();
            appointment = serviceProvider.GetService<IApointment>();
            doctor = serviceProvider.GetService<Idoctor>();
            address= serviceProvider.GetService<IAddress>();

        }
    }
}
