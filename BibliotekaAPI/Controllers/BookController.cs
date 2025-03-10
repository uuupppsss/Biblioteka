﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<ActionResult> GetBooks() => Ok(await _db.GetBooksAsync());

        // Получить книгу по ID
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookById(int id)
        {
            var book = await _db.GetBookByIdAsync(id);
            if (book == null) return NotFound("Книга не найдена.");
            return Ok(book);
        }

        // Добавить новую книгу
        [HttpPost]
        public async Task<ActionResult> AddBook(Books book)
        {
            await _db.AddBookAsync(book);
            return Ok("Книга успешно добавлена.");
        }

        // Удалить книгу по ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _db.RemoveBookByIdAsync(id);
            return Ok("Книга успешно удалена.");
        }

        // Привязка книги к пользователю
        [HttpGet("link/{bookId}/{userId}")]
        public async Task<ActionResult> LinkBookToUser(int bookId, int userId)
        {
            await _db.LinkBookToUserAsync(bookId, userId);
            return Ok($"Книга ID {bookId} привязана к пользователю ID {userId}.");
        }

        // Отвязка книги от пользователя
        [HttpGet("unlink/{bookId}")]
        public async Task<ActionResult> UnlinkBookFromUser(int bookId)
        {
            await _db.UnlinkBookFromUserAsync(bookId);
            return Ok("Связь книги с пользователем удалена.");
        }
    }
}
