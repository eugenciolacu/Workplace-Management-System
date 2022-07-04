using AutoMapper;
using WMS.Data.Entities.Core;
using WMS.Service.Dtos.User;

namespace WMS.Service.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<UserForCreateDto, Employee>();
        }
    }
}
