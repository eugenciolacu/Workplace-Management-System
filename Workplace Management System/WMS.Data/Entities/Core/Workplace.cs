namespace WMS.Data.Entities.Core
{
    public class Workplace : BaseEntity
    {
        public string Name { get; set; } = null!;

        public Guid FloorId { get; set; }
        public Floor Floor { get; set; } = null!;

        public List<Reservation> Reservations { get; set; } = null!;
    }
}
