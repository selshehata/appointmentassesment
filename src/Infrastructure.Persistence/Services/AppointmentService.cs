using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Interfaces.Application;
using Core.Application.Interfaces.Persistence;
using Core.Domain.Entities;

namespace Infrastructure.Persistence.Services
{
    public class AppointmentService : ServiceBase<Appointment, AppointmentDto>
    {
        public AppointmentService(IUnitOfWork unitOfWork, IMapperContainer mapper)
      : base(unitOfWork, mapper)
        {
        }

        protected override void ValidateDto(AppointmentDto dto)
        {
            if(dto == null)
            {
                throw new NotImplementedException();
            }
            if(dto.AppointmentStatusId == null || dto.AppointmentStatusId==0)
            {
                throw new Exception("StatusId is Requeired");
            }
        }
    }
}
