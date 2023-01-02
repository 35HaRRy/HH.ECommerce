using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using HH.ECommerce.Data;
using HH.ECommerce.Data.Contracts;
using HH.ECommerce.Data.Repositories;
using HH.ECommerce.Services.Contracts;

namespace HH.ECommerce.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            return services;
        }

        public static IServiceCollection ConfigureSqlLite(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlLiteConnection = configuration.GetConnectionString("sqlLiteConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite(sqlLiteConnection));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<ICustomerService>()
                .AddScoped<IDiscountService>()
                .AddScoped<IInvoiceService>();

            return services;
        }
    }
}
