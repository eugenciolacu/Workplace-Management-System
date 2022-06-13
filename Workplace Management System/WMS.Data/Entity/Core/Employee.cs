namespace WMS.Data.Entity.Core
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;

        public List<Reservation> Reservations { get; set; } = new();
    }
}
