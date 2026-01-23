using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using prototipo.Common.Helpers;
using prototipo.Common.Interfaces;
using prototipo.Common.Validations;
using prototipo.Database;
using prototipo.Database.Models;

namespace prototipo.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserValidations _validations;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            _validations = new UserValidations(context);
        }


        public async Task<List<IdentityUser>> UserList(QueryObject query)
        {
            var users = _context.Users.AsQueryable();

            // validations
            users = await _validations.UserNameValidation(query, users);
            users = await _validations.EmailValidation(query, users);
            users = await _validations.SortByValidation(query, users);

            // page logic
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await users.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<IdentityUser?> GetById(string id)
        {
            var userId = id.ToString();
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<IdentityUser?> GetByUserName(string username)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}