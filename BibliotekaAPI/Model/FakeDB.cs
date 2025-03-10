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
        private ObservableCollection<User> _users;
        private ObservableCollection<Books> _books;
        private Dictionary<int, int> _bookUserLinks; // <bookId, userId>

        private int _userIdCounter = 1;
        private int _bookIdCounter = 1;

        public FakeDB()
        {
            _users = new ObservableCollection<User>();
            _books = new ObservableCollection<Books>();
            _bookUserLinks = new Dictionary<int, int>(); // Связи книги с пользователем

            _users.Add(new User() { Id = _userIdCounter++, Username = "admin", Password = "1234" });
            _books.Add(new Books() { Id = _bookIdCounter++, Title = "Я Умный", Author = "Самый умный" });

            // Пример связи книги с пользователем
            _bookUserLinks.Add(1, 1); // Книга с Id = 1 закреплена за пользователем с Id = 1
        }

        // Получение списка пользователей
        public async Task<ObservableCollection<User>> GetUsersAsync()
        {
            return await Task.FromResult(new ObservableCollection<User>(_users));
        }

        // Получение пользователя по ID
        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return await Task.FromResult(user != null ? new User { Id = user.Id, Username = user.Username, Password = user.Password } : null);
        }

        // Добавление пользователя
        public async Task AddUserAsync(User user)
        {
            user.Id = _userIdCounter++;
            _users.Add(user);
        }

        // Удаление пользователя по ID
        public async Task RemoveUserByIdAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null) _users.Remove(user);
        }

        // Обновление данных пользователя
        public async Task EditUserAsync(User updatingUser)
        {
            var user = _users.FirstOrDefault(u => u.Id == updatingUser.Id);
            if (user != null)
            {
                user.Username = updatingUser.Username;
                user.Password = updatingUser.Password;
            }
        }

        // Проверка авторизации
        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            return await Task.FromResult(_users.FirstOrDefault(u => u.Username == username && u.Password == password));
        }

        // Получение списка книг
        public async Task<ObservableCollection<Books>> GetBooksAsync()
        {
            return await Task.FromResult(new ObservableCollection<Books>(_books));
        }

        // Получение книги по ID
        public async Task<Books> GetBookByIdAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return await Task.FromResult(book != null ? new Books { Id = book.Id, Title = book.Title, Author = book.Author, Description = book.Description } : null);
        }

        // Добавление книги
        public async Task AddBookAsync(Books book)
        {
            book.Id = _bookIdCounter++;
            _books.Add(book);
        }

        // Удаление книги по ID
        public async Task RemoveBookByIdAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null) _books.Remove(book);
        }

        // Обновление данных книги
        public async Task EditBookAsync(Books updatingBook)
        {
            var book = _books.FirstOrDefault(b => b.Id == updatingBook.Id);
            if (book != null)
            {
                book.Title = updatingBook.Title;
                book.Author = updatingBook.Author;
                book.Description = updatingBook.Description;
            }
        }
        // Проверка связи книги с пользователем
        public async Task<bool> IsBookLinkedToUserAsync(int bookId)
        {
            return await Task.FromResult(_bookUserLinks.ContainsKey(bookId));
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
