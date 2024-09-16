using Core.Application.Extensions;
using Infrastructure.Persistence.Extensions;
using Infrastructure.Identity.Extensions;
using Core.Application.Mapper;
using Core.Application.Interfaces.Application;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Db contexts

            builder.Services.AddAppDbContext(builder.Configuration);

            builder.Services.AddIdentityDbContext(builder.Configuration);

            // Add identity

            builder.Services.AddIdentityAuth();

            // Add services

            builder.Services.AddInfrastructureIdentityServices();

            builder.Services.AddInfrastructurePersistenceServices();

            // Add mapping profiles

            //builder.Services.AddApplicationMappingProfile();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true; // Optional: to include version in response headers
                options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Read version from the URL
            });

            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IMapperContainer, MapperContainer>();
            MappingConfig.Configure(); // Call your mapping configuration
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}