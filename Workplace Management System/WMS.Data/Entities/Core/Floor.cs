namespace WMS.Data.Entities.Core
{
    public class Floor : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }

        public Guid SiteId { get; set; }
        public Site Site { get; set; } = null!;

        public List<Workplace> Workplaces { get; set; } = null!;
    }
}
