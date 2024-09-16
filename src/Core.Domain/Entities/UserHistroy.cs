namespace Core.Domain.Entities
{
    public class UserHistroy:EntityBase
    {
        public DateTime DateOfVisit { get; set; }
        public string notes { get; set; }
        public string diagnosis { get; set; }
        public string UserId { get; set; }
    }
}
