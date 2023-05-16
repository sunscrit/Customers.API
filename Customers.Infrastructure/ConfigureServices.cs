using Customers.Domain;
using Customers.Domain.Interfaces;
using Customers.Infrastructure.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IDictionary<int, Customer>>(new ConcurrentDictionary<int, Customer>());
        services.AddScoped<IRepository<Customer>, InMemoryCustomerRepository>();
        return services;
    }
}