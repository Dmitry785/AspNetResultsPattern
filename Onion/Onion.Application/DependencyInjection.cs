using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Services;
using Onion.Application.Services.Interfaces;
using System.Reflection;

namespace Onion.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IScheduleService, ScheduleService>();

        return services;
    }
}
