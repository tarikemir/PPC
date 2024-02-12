using Microsoft.Extensions.DependencyInjection;
using PPC.Application.Abstractions.Token;
using PPC.Infrastructure.Services.Token;

namespace PPC.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
