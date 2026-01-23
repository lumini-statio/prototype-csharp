using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using prototipo.Common.Helpers;
using prototipo.Database.Models;

namespace prototipo.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<List<IdentityUser>> UserList(QueryObject query);
        Task<IdentityUser?> GetById(string id);
        Task<IdentityUser?> GetByUserName(string username);
    }
}