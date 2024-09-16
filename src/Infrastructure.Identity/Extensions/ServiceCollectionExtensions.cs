using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interfaces.Identity;
using Infrastructure.Identity.Services;
using AutoMapper;
using Infrastructure.Identity.Mapper;
using Infrastructure.Identity.Data;
using Core.Application.Interfaces.Application;
using Web.Razor.Services;

namespace Infrastructure.Identity.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    "Server=DESKTOP-8Q8QICI\\SQLEXPRESS; Database=Appointment; Trusted_Connection=True;TrustServerCertificate=True; MultipleActiveResultSets=true",
                    //configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppIdentityDbContext).Assembly.FullName)));
        }

        public static void AddIdentityAuth(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddInfrastructureIdentityServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
        }
    }
}
