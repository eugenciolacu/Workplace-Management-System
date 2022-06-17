namespace WMS.Service.Dtos.Floor
{
    public class FloorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public long SiteId { get; set; }
    }
}