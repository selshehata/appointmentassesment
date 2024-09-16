using Core.Application.Mapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Core.Application.Interfaces.Application;
using Core.Application.DTOs;
using Core.Domain.Entities;

namespace Core.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationMappingProfile(this IServiceCollection services)
        {
           
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationProfile());
            });
            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            services.AddSingleton<IMapperContainer, MapperContainer>(); 
            MappingConfig.Configure(); // Call your mapping configuration

        }
    }
}
