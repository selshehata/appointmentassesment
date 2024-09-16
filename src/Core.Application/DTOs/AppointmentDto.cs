using Core.Application.Interfaces.Persistence;

namespace Core.Application.DTOs
{
    public class AppointmentDto:IIdentifiable
    {
        public DateTime DateTime { get; set; }
        public int? AppointmentStatusId { get; set; }
        public string CancelReason { get; set; }
        public string UserId { get; set; }
        public int Id {  get; set; }
    }
}
