using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BibliotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly FakeDB _db;
        private readonly NotFakeDB context;

        public UsersController()
        {
            context = NotFakeDB.Instance;
        }

        // Получить всех пользователей
        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var result = await context.Users.ToListAsync();
            return Ok(result);
        }


        // Получить пользователя по ID
        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var result = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(result==null) return NotFound();
            var user = new User { Id = result.Id, Username = result.Username, Password = result.Password };
            return Ok(user);
        }

        // Добавить нового пользователя
        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser( User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            if(await context.Users.ContainsAsync(user)) return Ok();
            else return BadRequest();
        }

        // Удалить пользователя по ID
        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null) context.Users.Remove(user);
            await context.SaveChangesAsync();
            if (!await context.Users.ContainsAsync(user)) return Ok();
            else return BadRequest();
        }

        // Авторизация
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(User user)
        {
            var result = await context.Users.FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);
            if (result != null)
            {
                var found_user = new User { Id=result.Id, Username = result.Username, Password = result.Password };
                return Ok(found_user);
            }
            else return NotFound();
        }
    }
}

