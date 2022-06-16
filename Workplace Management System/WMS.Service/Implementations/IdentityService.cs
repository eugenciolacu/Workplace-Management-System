using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WMS.Data.Entities;
using WMS.Data.Entities.Auth;
using WMS.Service.Dtos.User;
using WMS.Service.Exceptions;
using WMS.Service.Interfaces;

namespace WMS.Service.Implementations
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;

        public IdentityService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<UserDto> RegisterUser(UserCreateDto userCreateDto)
        {
            var userExists = await _userManager.FindByEmailAsync(userCreateDto.Email);

            if (userExists != null)
            {
                throw new IdentityException(ExceptionsConst.UserAlreadyExists);
            }

            User user = new()
            {
                UserName = userCreateDto.Email,
                Email = userCreateDto.Email
            };

            var result = await _userManager.CreateAsync(user, userCreateDto.Password);

            if (!result.Succeeded)
            {
                throw new IdentityException(ExceptionsConst.UserCreationFailed);
            }

            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                result = await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            else
            {
                var createdUser = await _userManager.FindByEmailAsync(userCreateDto.Email);
                await DeleteUserWhenRoleAssignmentFail(createdUser.Id);
                throw new IdentityException(ExceptionsConst.RoleDoNotExists);
            }

            if (!result.Succeeded)
            {
                var createdUser = await _userManager.FindByEmailAsync(userCreateDto.Email);
                await DeleteUserWhenRoleAssignmentFail(createdUser.Id);
                throw new IdentityException(ExceptionsConst.AssignRoleToUserFailed);
            }

            return new UserDto()
            {
                UserName = user.UserName,
                Email = user.Email
            };
        }

        private async Task DeleteUserWhenRoleAssignmentFail(Guid id)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user);
        }
    }
}
