using Dal.Api;
using Dal;
using Microsoft.Extensions.DependencyInjection;
using BL.Api;
using BL.Service;

namespace BL
{
    public class BlManager: IblMANanager
    {
        public IBlClient BlClients { get; }
        public IBlAppointment BlAppointment { get; }
        public IBlDoctor BlDoctors { get; }

        public BlManager()
        {
            
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IBlClient, BlClientService>();
            services.AddSingleton<IBlAppointment, BlAppointmentService>();
            services.AddSingleton<IBlDoctor, BLDoctorService>();
            services.AddSingleton<IDal, DalMannager>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            BlClients = serviceProvider.GetService<IBlClient>();
            BlAppointment=serviceProvider.GetService<IBlAppointment>();
            BlDoctors = serviceProvider.GetService<IBlDoctor>();

        }
    }
}
