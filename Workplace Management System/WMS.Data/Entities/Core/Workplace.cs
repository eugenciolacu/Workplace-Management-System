namespace WMS.Data.Entities.Core
{
    public class Workplace : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public Guid FloorId { get; set; }
        public Floor Floor { get; set; } = new();

        public List<Reservation> Reservations { get; set; } = new();
    }
}
