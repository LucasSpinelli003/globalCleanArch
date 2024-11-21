using GLOBAL.Application.Services;
using GLOBAL.Data.AppData;
using GLOBAL.Data.Repositories;
using GLOBAL.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GLOBAL.IoC
{
    public class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(x => {
                x.UseOracle(configuration["ConnectionStrings:Oracle"]);
            });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserApplicationService, UserApplicationService>();

            services.AddTransient<IUserGroupRepository, UserGroupRepository>();
            services.AddTransient<IUserGroupApplicationService, UserGroupApplicationService>();

            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<IDeviceApplicationService, DeviceApplicationService>();

            services.AddTransient<IDeviceInfoRepository, DeviceInfoRepository>();
            services.AddTransient<IDeviceInfoApplicationService, DeviceInfoApplicationService>();
            
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IAddressApplicationService, AddressApplicationService>();

        }

    }
}
