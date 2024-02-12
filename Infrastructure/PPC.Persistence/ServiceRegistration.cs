using Microsoft.Extensions.DependencyInjection;
using PPC.Application.Abstractions.Services.Authentications;
using PPC.Application.Abstractions.Services;
using PPC.Domain.Identity;
using PPC.Persistence.Services.AuthServices;
using PPC.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using PPC.Application.Repositories.Link;
using PPC.Persistence.Repositories.Link;
using PPC.Persistence.Services;

namespace PPC.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<PPCDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<PPCDbContext>();

            services.AddScoped<ILinkReadRepository, LinkReadRepository>();
            services.AddScoped<ILinkWriteRepository, LinkWriteRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthentication, AuthService>();
        }
    }
}
