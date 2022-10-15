using ApiCompras.Application.Mapper;
using ApiCompras.Application.Service;
using ApiCompras.Application.Service.Interface;
using ApiCompras.Domain.Repository;
using ApiCompras.Infra.Data.Context;
using ApiCompras.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Infra.IoC
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;

        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapper));
            services.AddScoped<IPersonService,PersonService>();
            return services;
        }
    }
}
