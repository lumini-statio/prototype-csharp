using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using prototipo.Database.Models;

namespace prototipo.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}