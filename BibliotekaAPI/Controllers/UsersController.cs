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
        private readonly FakeDB _db;

        public UsersController()
        {
            _db = new FakeDB("UsersTestDB");
        }

        // Получить всех пользователей
        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _db.GetUsersAsync());
        }


        // Получить пользователя по ID
        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var result=await _db.GetUserByIdAsync(id);
            if(result==null) return NotFound("Пользователь не найден");
            else return Ok(result);
        }

        // Добавить нового пользователя
        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser( User user)
        {
            var result= await _db.AddUserAsync(user);
            if(result) return Ok();
            else return BadRequest("Что то пошло не так");
        }

        // Удалить пользователя по ID
        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var result = await _db.RemoveUserByIdAsync(id);
            if (result) return Ok();
            else return BadRequest("Что то пошло не так");
        }

        // Авторизация
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(User user)
        {
            var result = await _db.AuthenticateUserAsync(user);
            if (result==null) return NotFound("Пользователь не найден");
            else return Ok(user);
        }
    }
}

