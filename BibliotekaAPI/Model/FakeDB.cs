using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaAPI.Model
{
    public class FakeDB
    {
        private readonly NotFakeDB context;

        //private List<User> _users;
        //private List<Book> _books;
        private Dictionary<int, int> _bookUserLinks; // <bookId, userId>

        //private int _userIdCounter = 1;
        //private int _bookIdCounter = 1;

        public FakeDB()
        {
            context = new NotFakeDB("TestDB");
            context.Database.EnsureCreated();
            LoadData();
            //_users = new List<User>()
            //{
            //    new User() { Id = _userIdCounter++, Username = "admin", Password = "1234" }
            //};
            //_books = new List<Book>()
            //{
            //    new Book { Id = _bookIdCounter++, IsPopular=true, Title = "1984", Author = "Джордж Оруэлл", Description = "Антиутопия о тоталитарном обществе." },
            //    new Book { Id = _bookIdCounter++, IsPopular=true, Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Description = "Роман о любви, вере и мистике." },
            //    new Book { Id = _bookIdCounter++, IsPopular=false, Title = "Убийство в Восточном экспрессе", Author = "Агата Кристи", Description = "Детективная история о загадочном убийстве." },
            //    new Book() { Id = _bookIdCounter++, IsPopular=false, Title = "Я Умный", Author = "Самый умный" }
            //};

            //_bookUserLinks = new Dictionary<int, int>(); // Связи книги с пользователем


            //// Пример связи книги с пользователем
            //_bookUserLinks.Add(1, 1); // Книга с Id = 1 закреплена за пользователем с Id = 1
        }

        private async void LoadData()
        {
            context.Books.Add(new Book {IsPopular = true, Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Description = "Роман о любви, вере и мистике." });
            context.Books.Add(new Book { IsPopular = true, Title = "1984", Author = "Джордж Оруэлл", Description = "Антиутопия о тоталитарном обществе." });
            context.Books.Add(new Book { IsPopular = false, Title = "Убийство в Восточном экспрессе", Author = "Агата Кристи", Description = "Детективная история о загадочном убийстве." });
            context.Books.Add(new Book() {IsPopular = false, Title = "Я Умный", Author = "Самый умный" });

            context.Users.Add(new User() { Username = "admin", Password = "1234" });
            await context.SaveChangesAsync();
        }

        //// Получение списка пользователей
        //public async Task<List<User>> GetUsersAsync()
        //{
        //    var result = await context.Users.ToListAsync();
        //    return result;
        //}

        //// Получение пользователя по ID
        //public async Task<User> GetUserByIdAsync(int id)
        //{
        //    var result = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        //    var user = new User {Id=result.Id,Username=result.Username, Password=result.Password };
        //    return user;
        //}

        //// Добавление пользователя
        //public async Task AddUserAsync(User user)
        //{
        //    await context.Users.AddAsync(user);
        //    await context.SaveChangesAsync();
        //}

        // Удаление пользователя по ID
        //public async Task RemoveUserByIdAsync(int id)
        //{
        //    var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        //    if (user != null) context.Users.Remove(user);
        //    await context.SaveChangesAsync();
        //}

        //// Обновление данных пользователя
        //public async Task EditUserAsync(User updatingUser)
        //{
        //    var user = await context.Users.FirstOrDefaultAsync(u => u.Id == updatingUser.Id);
        //    if (user != null)
        //    {
        //        user.Username = updatingUser.Username;
        //        user.Password = updatingUser.Password;
        //    }
        //    await context.SaveChangesAsync();
        //}

        //// Проверка авторизации
        //public async Task<User> AuthenticateUserAsync(string username, string password)
        //{
        //    var result = await context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        //    if (result != null)
        //    {
        //        var user = new User { Username = result.Username, Password = result.Password };
        //        return user;
        //    }
        //    else return null;
        //}

        //// Получение списка книг
        //public async Task<List<Book>> GetBooksAsync()
        //{
        //    var books = await context.Books.ToListAsync();
        //    return books;
        //}

        //// Получение книги по ID
        //public async Task<Book> GetBookByIdAsync(int id)
        //{
        //    var result = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
        //    var book = new Book { Id=result.Id, Title=result.Title, Description=result.Description,Genre=result.Genre, PublishDate=result.PublishDate,
        //        IsPopular=result.IsPopular, PageCount=result.PageCount, Author=result.Author};
        //    return book;
        //}

        //// Добавление книги
        //public async Task AddBookAsync(Book book)
        //{
        //    await context.Books.AddAsync(book);
        //    await context.SaveChangesAsync();
        //}

        //// Удаление книги по ID
        //public async Task RemoveBookByIdAsync(int id)
        //{
        //    var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
        //    if (book != null) context.Books.Remove(book);
        //    await context.SaveChangesAsync();
        //}

        //// Обновление данных книги
        //public async Task EditBookAsync(Book updatingBook)
        //{
        //    var book = await context.Books.FirstOrDefaultAsync(b => b.Id == updatingBook.Id);
        //    if (book != null)
        //    {
        //        book.Title = updatingBook.Title;
        //        book.Author = updatingBook.Author;
        //        book.Description = updatingBook.Description;
        //        book.IsPopular = updatingBook.IsPopular;
        //        book.PublishDate = updatingBook.PublishDate;
        //        book.PageCount = updatingBook.PageCount;
        //        book.Genre= updatingBook.Genre;
        //    }
        //    await context.SaveChangesAsync();
        //}
        //// Проверка связи книги с пользователем
        //public async Task<bool> IsBookLinkedToUserAsync(int bookId)
        //{
        //    return _bookUserLinks.ContainsKey(bookId);
        //}

        //// Добавление связи книги с пользователем
        //public async Task LinkBookToUserAsync(int bookId, int userId)
        //{
        //    if (!_bookUserLinks.ContainsKey(bookId))
        //    {
        //        _bookUserLinks.Add(bookId, userId);
        //    }
        //}

        //// Удаление связи книги с пользователем
        //public async Task UnlinkBookFromUserAsync(int bookId)
        //{
        //    if (_bookUserLinks.ContainsKey(bookId))
        //    {
        //        _bookUserLinks.Remove(bookId);
        //    }
        //}

    }
}
