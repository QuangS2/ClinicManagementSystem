using Clinic.Application.Interfaces;
using Clinic.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Clinic.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {

            services.AddScoped<IPatientService, PatientService>();
            return services;
        }
    }
}
