using AutoMapper;
using WMS.Data.Entities.Auth;
using WMS.Service.Dtos.User;

namespace WMS.Service.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForCreateDto, User>();
        }
    }
}
