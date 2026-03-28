using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Interfaces;

namespace Onion.Infastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MyDb");
        services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}