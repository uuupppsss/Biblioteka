using Microsoft.AspNetCore.Mvc;
using BibliotekaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly FakeDB _db;

        public BooksController()
        {
            
            _db = new FakeDB("BooksTestDB");
        }

        // Получить список всех книг
        [HttpGet("GetBooks")]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(await _db.GetBooksAsync());
        }

        // Получить книгу по ID
        [HttpGet("GetBookById/{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var result= await _db.GetBookByIdAsync(id);
            if(result==null) return NotFound("Книга не найдена");
            else return Ok(result);
        }

        // Добавить новую книгу
        [HttpPost("AddBook")]
        public async Task<ActionResult> AddBook(Book book)
        {
            var result= await _db.AddBookAsync(book);
            if(result) return Ok();
            else return BadRequest("Что то пошло не так");
        }

        // Удалить книгу по ID
        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var result = await _db.RemoveBookByIdAsync(id);
            if (result) return Ok();
            else return BadRequest("Что то пошло не так");
        }

        //// Привязка книги к пользователю
        //[HttpGet("LinkBookToUser/{bookId}/{userId}")]
        //public async Task<ActionResult> LinkBookToUser(int bookId, int userId)
        //{
        //    await _db.LinkBookToUserAsync(bookId, userId);
        //    return Ok($"Книга ID {bookId} привязана к пользователю ID {userId}.");
        //}

        //// Отвязка книги от пользователя
        //[HttpGet("UnlinkBookFromUser/{bookId}")]
        //public async Task<ActionResult> UnlinkBookFromUser(int bookId)
        //{
        //    await _db.UnlinkBookFromUserAsync(bookId);
        //    return Ok("Связь книги с пользователем удалена.");
        //}

        //обновление книги
        [HttpPost("UpdateBook")]
        public async Task<ActionResult> UpdateBook(Book updatingBook)
        {
            var result = await _db.EditBookAsync(updatingBook);
            if (result) return Ok();
            else return BadRequest("Что то пошло не так");
        }
    }
}
