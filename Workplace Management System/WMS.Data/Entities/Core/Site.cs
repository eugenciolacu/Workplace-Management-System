namespace WMS.Data.Entities.Core
{
    public class Site : BaseEntity
    {
        public string Name { get; set; } = null!;

        public List<Floor> Floors { get; set; } = null!;
    }
}
