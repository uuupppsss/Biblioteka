using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.model
{
    public class FakeDB
    {
        public User CurrentUser { get; set; }
        public Action BooksListChanged;
        private static FakeDB instanse;
        public static FakeDB Instance
        {
            get
            {
                if(instanse==null) 
                    instanse = new FakeDB();
                return instanse;
            }
        }
        private ObservableCollection<User> _users;
        private ObservableCollection<Book> _books;
        private Dictionary<int, int> _bookUserLinks; // <bookId, userId>

        private int _userIdCounter = 1;
        private int _bookIdCounter = 1;

        public FakeDB()
        {
            _users = new ObservableCollection<User>()
            {
                new User() { Id = _userIdCounter++, Username = "admin", Password = "1234" }
            };
            _books = new ObservableCollection<Book>()
            {
                new Book { Id = _bookIdCounter++, IsPopular=true, Title = "1984", Author = "Джордж Оруэлл", Description = "Антиутопия о тоталитарном обществе." },
                new Book { Id = _bookIdCounter++, IsPopular=true, Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Description = "Роман о любви, вере и мистике." },
                new Book { Id = _bookIdCounter++, IsPopular=false, Title = "Убийство в Восточном экспрессе", Author = "Агата Кристи", Description = "Детективная история о загадочном убийстве." },
                new Book() { Id = _bookIdCounter++, IsPopular=false, Title = "Я Умный", Author = "Самый умный" }
            };

            _bookUserLinks = new Dictionary<int, int>(); // Связи книги с пользователем


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
        public async Task<User> LoginAsync(string username, string password)
        {
            return await Task.FromResult(_users.FirstOrDefault(u => u.Username == username && u.Password == password));
        }

        // Получение списка книг
        public async Task<List<Book>> GetBooksAsync()
        {
            return await Task.FromResult(new List<Book>(_books));
        }

        // Получение книги по ID
        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return await Task.FromResult(book != null ? new Book { Id = book.Id, Title = book.Title, Author = book.Author, Description = book.Description } : null);
        }

        // Добавление книги
        public async Task AddBookAsync(Book book)
        {
            book.Id = _bookIdCounter++;
            _books.Add(book);
            BooksListChanged.Invoke();
        }

        // Удаление книги по ID
        public async Task DeleteBookAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null) _books.Remove(book);
            BooksListChanged.Invoke();
        }

        // Обновление данных книги
        public async Task EditBookAsync(Book updatingBook)
        {
            var book = _books.FirstOrDefault(b => b.Id == updatingBook.Id);
            if (book != null)
            {
                book.Title = updatingBook.Title;
                book.Author = updatingBook.Author;
                book.Description = updatingBook.Description;
            }
            BooksListChanged.Invoke();
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
