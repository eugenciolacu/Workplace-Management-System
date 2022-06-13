using System.Collections.Generic;

namespace WMS.Data.Entity.Core
{
    public class Workplace : BaseEntity
    {
        public string Name { get; set; } = String.Empty;

        public Guid FloorId { get; set; }
        public Floor Floor { get; set; } = new();

        public List<Reservation> Reservations { get; set; } = new();
    }
}
