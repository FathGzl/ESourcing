using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.Repositories.Base;
using Ordering.Domain.Repositories;
using Ordering.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Repositories.Base;
using Ordering.Infrastructure.Repositories;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
                                                ServiceLifetime.Singleton,
                                                ServiceLifetime.Singleton);


            //Add Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
