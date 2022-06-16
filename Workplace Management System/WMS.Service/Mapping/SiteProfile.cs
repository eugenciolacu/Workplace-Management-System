using AutoMapper;
using WMS.Data.Entities.Core;
using WMS.Service.Dtos.Site;

namespace WMS.Service.Mapping
{
    public class SiteProfile : Profile
    {
        public SiteProfile()
        {
            CreateMap<Site, SiteDto>();
        }
    }
}
