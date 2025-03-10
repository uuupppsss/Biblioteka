using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaAPI.Model;
using Microsoft.AspNetCore.Mvc;


namespace BibliotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FakeDB _db;

        public UsersController(FakeDB db)
        {
            _db = db;
        }

        // Получить всех пользователей
        [HttpGet]
        public async Task<ActionResult> GetUsers() => Ok(await _db.GetUsersAsync());

        // Получить пользователя по ID
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await _db.GetUserByIdAsync(id);
            if (user == null) return NotFound("Пользователь не найден.");
            return Ok(user);
        }

        // Добавить нового пользователя
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] User user)
        {
            await _db.AddUserAsync(user);
            return Ok("Пользователь успешно добавлен.");
        }

        // Удалить пользователя по ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _db.RemoveUserByIdAsync(id);
            return Ok("Пользователь успешно удален.");
        }

        // Авторизация
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] User user)
        {
            var authenticatedUser = await _db.AuthenticateUserAsync(user.Username, user.Password);

            return Ok(authenticatedUser);
        }
    }
}

