using WMS.Service.Dtos.User;

namespace WMS.Service.Interfaces
{
    public interface IIdentityService
    {
        Task<UserDto> RegisterUser(UserCreateDto userCreateDto);
    }
}
