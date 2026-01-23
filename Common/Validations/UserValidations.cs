using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using prototipo.Common.Helpers;
using prototipo.Database;

namespace prototipo.Common.Validations
{
    public class UserValidations
    {
        private readonly AppDbContext _context;

        public UserValidations(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IQueryable<IdentityUser>> UserNameValidation(QueryObject query, IQueryable<IdentityUser> users)
        {
            if (!string.IsNullOrWhiteSpace(query.UserName))
            {
                users = users.Where(u => u.UserName.Contains(query.UserName));
            }

            return users;
        }

        public async Task<IQueryable<IdentityUser>> EmailValidation(QueryObject query, IQueryable<IdentityUser> users)
        {
            if (!string.IsNullOrWhiteSpace(query.Email))
            {
                users = users.Where(u => u.Email.Contains(query.Email));
            }

            return users;
        }

        public async Task<IQueryable<IdentityUser>> SortByValidation(QueryObject query, IQueryable<IdentityUser> users)
        {
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    users = query.IsDescending ? users.OrderByDescending(s => s.Id) : users.OrderBy(s => s.Id);
                }
                if (query.SortBy.Equals("UserName", StringComparison.OrdinalIgnoreCase))
                {
                    users = query.IsDescending ? users.OrderByDescending(s => s.UserName) : users.OrderBy(s => s.UserName);
                }
                if (query.SortBy.Equals("Email", StringComparison.OrdinalIgnoreCase))
                {
                    users = query.IsDescending ? users.OrderByDescending(s => s.Email) : users.OrderBy(s => s.Email);
                }
            }

            return users;
        }
    }
}