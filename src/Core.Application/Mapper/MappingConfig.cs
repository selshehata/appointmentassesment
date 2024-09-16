using Core.Application.DTOs;
using Core.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Mapper
{
   
    public static class MappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<Appointment, AppointmentDto>.NewConfig();
            TypeAdapterConfig<AppointmentDto, Appointment>.NewConfig();
            TypeAdapterConfig<AppointmentStatus, AppointmentStatusDto>.NewConfig();
            TypeAdapterConfig<AppointmentStatusDto, AppointmentStatus>.NewConfig();
        }
    }
}
