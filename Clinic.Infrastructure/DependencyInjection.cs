using Clinic.Application.Interfaces;
using Clinic.Infrastructure.Data;
using Clinic.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClinicDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<ClinicDbContext>(options =>
            //    options.UseInMemoryDatabase("ClinicDb"));
            
            
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
