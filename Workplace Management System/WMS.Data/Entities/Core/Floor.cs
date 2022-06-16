namespace WMS.Data.Entities.Core
{
    public class Floor : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public Guid SiteId { get; set; }
        public Site Site { get; set; } = new();

        public List<Workplace> Workplaces { get; set; } = new();
    }
}
