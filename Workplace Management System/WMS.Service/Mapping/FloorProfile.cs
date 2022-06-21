using AutoMapper;
using WMS.Data.Entities.Core;
using WMS.Service.Dtos.Floor;

namespace WMS.Service.Mapping
{
    public class FloorProfile : Profile
    {
        public FloorProfile()
        {
            CreateMap<Floor, FloorDto>();

            CreateMap<FloorForCreationDto, Floor>();

            CreateMap<FloorForUpdateDto, Floor>(); //.ReverseMap();
        }
    }
}
