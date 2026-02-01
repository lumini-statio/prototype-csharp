using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using prototipo.Common.Dto;
using prototipo.Common.Dto.Account;
using prototipo.Database.Models;

namespace prototipo.Common.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this IdentityUser userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                UserName = userModel.UserName,
                Email = userModel.Email
            };
        }
        
    }
}