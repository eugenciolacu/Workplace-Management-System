namespace WMS.Data.Entities.Core
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public List<Reservation> Reservations { get; set; } = null!;
    }
}
