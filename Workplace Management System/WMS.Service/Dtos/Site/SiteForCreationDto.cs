using WMS.Service.Dtos.Floor;

namespace WMS.Service.Dtos.Site
{
    public class SiteForCreationDto
    {
        public string Name { get; set; } = null!;

        public IEnumerable<FloorForCreationDto> Floors { get; set; } = null!;
    }
}
