using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interfaces.Persistence;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Interceptors;
using Core.Application.DTOs;
using Infrastructure.Persistence.Services;
using Core.Application.Mapper;

namespace Infrastructure.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    "Server=DESKTOP-8Q8QICI\\SQLEXPRESS; Database=Appointment; Trusted_Connection=True;TrustServerCertificate=True; MultipleActiveResultSets=true",
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
        }

        public static void AddInfrastructurePersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServiceBase<AppointmentDto>, AppointmentService>();
            services.AddAutoMapper(typeof(ApplicationProfile));
        }
    }
}
