using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaAPI.Model;

namespace BibliotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly FakeDB _db;

        public BooksController(FakeDB db)
        {
            _db = db;
        }

        // Получить список всех книг
        [HttpGet("GetBooks")]
        public async Task<ActionResult<List<Book>>> GetBooks() => Ok(await _db.GetBooksAsync());

        // Получить книгу по ID
        [HttpGet("GetBookById/{id}")]
        public async Task<ActionResult<User>> GetBookById(int id)
        {
            var book = await _db.GetBookByIdAsync(id);
            if (book == null) return NotFound("Книга не найдена.");
            return Ok(book);
        }

        // Добавить новую книгу
        [HttpPost("AddBook")]
        public async Task<ActionResult> AddBook(Book book)
        {
            await _db.AddBookAsync(book);
            return Ok("Книга успешно добавлена.");
        }

        // Удалить книгу по ID
        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _db.RemoveBookByIdAsync(id);
            return Ok("Книга успешно удалена.");
        }

        // Привязка книги к пользователю
        [HttpGet("LinkBookToUser/{bookId}/{userId}")]
        public async Task<ActionResult> LinkBookToUser(int bookId, int userId)
        {
            await _db.LinkBookToUserAsync(bookId, userId);
            return Ok($"Книга ID {bookId} привязана к пользователю ID {userId}.");
        }

        // Отвязка книги от пользователя
        [HttpGet("UnlinkBookFromUser/{bookId}")]
        public async Task<ActionResult> UnlinkBookFromUser(int bookId)
        {
            await _db.UnlinkBookFromUserAsync(bookId);
            return Ok("Связь книги с пользователем удалена.");
        }

        //обновление книги
        [HttpPost("UpdateBook")]
        public async Task<ActionResult> UpdateBook(Book book)
        {
            await _db.EditBookAsync(book);
            return Ok();
        }
    }
}
