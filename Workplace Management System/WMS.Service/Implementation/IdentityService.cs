﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WMS.Data.Entity;
using WMS.Data.Entity.Auth;
using WMS.Service.Dto.User;
using WMS.Service.Exception;
using WMS.Service.Interface;
using System;

namespace WMS.Service.Implementation
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
            try
            {
                var userExists = await _userManager.FindByEmailAsync(userCreateDto.Email);

                if (userExists != null)
                {
                    throw new IdentityException(Exceptions.UserAlreadyExists);
                }

                User user = new()
                {
                    UserName = userCreateDto.Email,
                    Email = userCreateDto.Email
                };

                var result = await _userManager.CreateAsync(user, userCreateDto.Password);

                if (!result.Succeeded)
                {
                    throw new IdentityException(Exceptions.UserCreationFailed);
                }

                if (await _roleManager.RoleExistsAsync(UserRoles.User))
                {
                    result = await _userManager.AddToRoleAsync(user, UserRoles.User);
                }
                else
                {
                    throw new IdentityException(Exceptions.RoleDoNotExists);
                }

                if (!result.Succeeded)
                {
                    throw new IdentityException(Exceptions.AssignRoleToUserFailed);
                }

                return new UserDto()
                {
                    UserName = user.UserName,
                    Email = user.Email
                };
            }
            catch (IdentityException ex)
            {
                throw ex;
            }
        }
    }
}