using System.Collections.Generic;

namespace WMS.Data.Entity.Core
{
    public class Site : BaseEntity
    {
        public string Name { get; set; } = String.Empty;

        public List<Floor> Floors { get; set; } = new();
    }
}
