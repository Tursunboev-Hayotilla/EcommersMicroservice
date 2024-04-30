using Discount.Application.Abstractions;
using Discount.Infractructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infractructure
{
    public static class DiscountInfrastructureDependencyInjection
    {
        public static IServiceCollection AddDIscountInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDiscountDbContext,DiscountDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ECommerceLessonDiscountConnectionString"));
            });

            return services;
        }
    }
}
