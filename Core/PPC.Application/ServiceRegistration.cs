using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace PPC.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
