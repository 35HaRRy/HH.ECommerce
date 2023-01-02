using HH.ECommerce.Data;
using HH.ECommerce.Data.Contracts;
using HH.ECommerce.Data.Repositories;
using HH.ECommerce.Entities;
using HH.ECommerce.Services;
using HH.ECommerce.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;

namespace HH.ECommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson();

            services
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<IDiscountService, DiscountService>()
                .AddScoped<IInvoiceService, InvoiceService>()
                .AddScoped<IRepositoryManager, RepositoryManager>()
                .AddDbContext<ApplicationContext>(options => options.UseSqlite(Configuration.GetConnectionString("sqlLiteConnection")))
                .AddAutoMapper(typeof(MappingProfile))
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(
                        "v1",
                        new OpenApiInfo
                        {
                            Title = "HH.ECommerce",
                            Version = "v1"
                        }
                    );
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HH.ECommerce v1"));
            }

            app
                .UseExceptionHandler(appError =>
                {
                    appError.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature != null)
                        {
                            logger.LogError("Something went wrong: {error}", contextFeature.Error);

                            var errorModel = new ErrorModel()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = env.IsDevelopment() ? contextFeature.Error.ToString() : "Internal Server Error."
                            }
                            .ToString();

                            await context.Response.WriteAsync(errorModel);
                        }
                    });
                })
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
