namespace WMS.Data.Entities.Core
{
    public class Site : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public List<Floor> Floors { get; set; } = new();
    }
}
