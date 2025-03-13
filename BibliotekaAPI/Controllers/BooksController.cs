using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //private readonly FakeDB _db;
        private readonly NotFakeDB context;

        public BooksController()
        {
            context=NotFakeDB.Instance;
        }

        // Получить список всех книг
        [HttpGet("GetBooks")]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await context.Books.ToListAsync();
            return Ok(books);
        }

        // Получить книгу по ID
        [HttpGet("GetBookById/{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var result = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if(result==null) return NotFound();
            var book = new Book
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Genre = result.Genre,
                PublishDate = result.PublishDate,
                IsPopular = result.IsPopular,
                PageCount = result.PageCount,
                Author = result.Author
            };
            return Ok(book);
        }

        // Добавить новую книгу
        [HttpPost("AddBook")]
        public async Task<ActionResult> AddBook(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            if (await context.Books.ContainsAsync(book)) return Ok();
            else return BadRequest();
        }

        // Удалить книгу по ID
        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book != null) context.Books.Remove(book);
            await context.SaveChangesAsync();
            if (!await context.Books.ContainsAsync(book)) return Ok();
            else return BadRequest();
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
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == updatingBook.Id);
            if (book == null) return NotFound();
            if (book != null)
            {
                book.Title = updatingBook.Title;
                book.Author = updatingBook.Author;
                book.Description = updatingBook.Description;
                book.IsPopular = updatingBook.IsPopular;
                book.PublishDate = updatingBook.PublishDate;
                book.PageCount = updatingBook.PageCount;
                book.Genre = updatingBook.Genre;
            }
            await context.SaveChangesAsync();
            if (await context.Books.ContainsAsync(book)) return Ok();
            else return BadRequest();
        }
    }
}
