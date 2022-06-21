namespace WMS.Data.Entities.Core
{
    public class Reservation : BaseEntity
    {
        public DateTime StartTimestamp { get; set; }
        public DateTime? EndTimestamp { get; set; }

        public Guid WorkplaceId { get; set; }
        public Workplace Workplace { get; set; } = null!;

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
