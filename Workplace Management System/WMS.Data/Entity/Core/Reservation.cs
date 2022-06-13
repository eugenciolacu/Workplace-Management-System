using System;

namespace WMS.Data.Entity.Core
{
    public class Reservation : BaseEntity
    {
        public DateTime StartTimestamp { get; set; }
        public Nullable<DateTime> EndTimestamp { get; set; }

        public Guid WorkplaceId { get; set; }
        public Workplace Workplace { get; set; } = new();

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = new();
    }
}
