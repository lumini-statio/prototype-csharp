using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prototipo.Common.Helpers;
using prototipo.Common.Interfaces;
using prototipo.Common.Mappers;
using prototipo.Database;

namespace prototipo.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _repo;
        public UserController(AppDbContext context, IUserRepository repo)
        {
            _context = context;
            _repo = repo;
        }


        [HttpGet("list")]
        [Authorize]
        public async Task<IActionResult> UserList([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var users = await _repo.UserList(query);

            var usersDto = users.Select(u => u.ToUserDto());

            return Ok(usersDto);
        }


        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> Get(
            [FromQuery] string? id,
            [FromQuery] string? username)
        {
            if (id == null && string.IsNullOrWhiteSpace(username))
                return BadRequest("Debe especificar id o username");

            var user = id != null
                ? await _repo.GetById(id)
                : await _repo.GetByUserName(username);

            if (user == null)
                return NotFound();

            return Ok(user.ToUserDto());
        }
    }
}