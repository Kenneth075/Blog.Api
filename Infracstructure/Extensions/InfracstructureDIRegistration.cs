using Application.Interfaces;
using Infracstructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Extensions
{
    public static class InfracstructureDIRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("dkk"), x => x.EnableRetryOnFailure());
            });

            services.AddScoped(typeof(IRepository<>), typeof(BlogRepository<>));

            return services;
        }
    }
}
