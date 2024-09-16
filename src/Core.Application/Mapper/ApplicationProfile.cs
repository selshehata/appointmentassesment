using AutoMapper;
using Core.Application.DTOs;
using Core.Domain.Entities;
using System.Xml;

namespace Core.Application.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentDto, Appointment>();

            CreateMap<AppointmentStatus, AppointmentStatusDto>();
            CreateMap<AppointmentStatusDto, AppointmentStatus>();


        }
    }
}
