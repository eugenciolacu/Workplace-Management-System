using WMS.Service.Dto.User;

namespace WMS.Service.Interface
{
    public interface IIdentityService
    {
        Task<UserDto> RegisterUser(UserCreateDto userCreateDto);
    }
}
