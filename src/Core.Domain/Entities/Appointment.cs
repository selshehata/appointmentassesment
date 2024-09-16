namespace Core.Domain.Entities
{
    public class Appointment: EntityBase
    {
        public DateTime DateTime { get; set; }
        public int? AppointmentStatusId { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public string CancelReason { get; set; }
        public string UserId { get; set; }

        
    }
}
