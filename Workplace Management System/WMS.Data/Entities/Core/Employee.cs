namespace WMS.Data.Entities.Core
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<Reservation> Reservations { get; set; } = new();
    }
}
