namespace WMS.Service.Dtos.Floor
{
    public class FloorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }

        //public Guid SiteId { get; set; }
    }
}