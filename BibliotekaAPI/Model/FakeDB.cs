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
        private Dictionary<int, int> _bookUserLinks; // <bookId, userId>

        //private static FakeDB instance;
        //public static FakeDB Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //            instance = new FakeDB();
        //        return instance;
        //    }
        //}

        public FakeDB(string filename)
        {
            context = new NotFakeDB(filename);
            context.Database.EnsureCreated();
            LoadData();
            _bookUserLinks = new Dictionary<int, int>(); // Связи книги с пользователем
        }

        private async void LoadData()
        {
            context.Books.Add(new Book { IsPopular = true, Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Description = "Роман о любви, вере и мистике." });
            context.Books.Add(new Book { IsPopular = true, Title = "1984", Author = "Джордж Оруэлл", Description = "Антиутопия о тоталитарном обществе." });
            context.Books.Add(new Book { IsPopular = false, Title = "Убийство в Восточном экспрессе", Author = "Агата Кристи", Description = "Детективная история о загадочном убийстве." });
            context.Books.Add(new Book() { IsPopular = false, Title = "Я Умный", Author = "Самый умный" });

            context.Users.Add(new User() { Username = "admin", Password = "1234" });
            await context.SaveChangesAsync();
        }

        // Получение списка пользователей
        public async Task<List<User>> GetUsersAsync()
        {
            var result = await context.Users.ToListAsync();
            return result;
        }

        // Получение пользователя по ID
        public async Task<User> GetUserByIdAsync(int id)
        {
            var result = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (result == null) return null;
            var user = new User { Id = result.Id, Username = result.Username, Password = result.Password };
            return user;
        }

        // Добавление пользователя
        public async Task<bool> AddUserAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return await context.Users.ContainsAsync(user);
        }

        //Удаление пользователя по ID
        public async Task<bool> RemoveUserByIdAsync(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null) context.Users.Remove(user);
            await context.SaveChangesAsync();
            return !await context.Users.ContainsAsync(user);
        }

        // Обновление данных пользователя
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

        // Проверка авторизации
        public async Task<User> AuthenticateUserAsync(User user)
        {
            var result = await context.Users.FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);
            if (result != null)
            {
                var found_user = new User { Id = result.Id, Username = result.Username, Password = result.Password };
                return found_user;
            }
            else return null;
        }

        // Получение списка книг
        public async Task<List<Book>> GetBooksAsync()
        {
            var books = await context.Books.ToListAsync();
            return books;
        }

        // Получение книги по ID
        public async Task<Book> GetBookByIdAsync(int id)
        {
            var result = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (result == null) return null;
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
            return book;
        }

        // Добавление книги
        public async Task<bool> AddBookAsync(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return await context.Books.ContainsAsync(book);
        }

        // Удаление книги по ID
        public async Task<bool> RemoveBookByIdAsync(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book != null) context.Books.Remove(book);
            await context.SaveChangesAsync();
            return !await context.Books.ContainsAsync(book);
        }

        // Обновление данных книги
        public async Task<bool> EditBookAsync(Book updatingBook)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == updatingBook.Id);
            if (book == null) return false;
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
            return await context.Books.ContainsAsync(book);
        }

        //Проверка связи книги с пользователем
        public async Task<bool> IsBookLinkedToUserAsync(int bookId)
        {
            return _bookUserLinks.ContainsKey(bookId);
        }

        // Добавление связи книги с пользователем
        public async Task LinkBookToUserAsync(int bookId, int userId)
        {
            if (!_bookUserLinks.ContainsKey(bookId))
            {
                _bookUserLinks.Add(bookId, userId);
            }
        }

        // Удаление связи книги с пользователем
        public async Task UnlinkBookFromUserAsync(int bookId)
        {
            if (_bookUserLinks.ContainsKey(bookId))
            {
                _bookUserLinks.Remove(bookId);
            }
        }

    }
}
