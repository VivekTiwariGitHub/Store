using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Interfaces;
using Store.Domain.Settings;
using Store.Infrastructure.Identity.Services;

namespace Store.Infrastructure.Logic
{
    public static class ServiceRegistration
    {
        public static void AddLogicInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.AddTransient<IStoreService, StoreService>();
        }
    }
}
