using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Abstractions;
using Orders.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure
{
    public static class OrdersInfrastructureDependencuInjection
    {
        public static IServiceCollection AddOrdersInfrastructure(this IServiceCollection services,IConfiguration cofiguration)
        {
            services.AddDbContext<IOrdersDbContext, OrderDbContext>(options =>
            {
                options.UseNpgsql(cofiguration.GetConnectionString("ECommerceLessonOrdersConnectionString"));
            });
            return services;
        }
    }
}
