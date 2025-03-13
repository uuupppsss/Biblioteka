using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Biblioteka.mvvm.model
{
    public class ApiConnect
    {
        public User CurrentUser { get; set; }
        public Action BooksListChanged;
        private HttpClient _httpClient;
        private MessagesServise _messagesServise;
        private static ApiConnect instance;
        public static ApiConnect Instance
        {
            get
            {
                if (instance == null)
                    instance = new ApiConnect();
                return instance;
            }
        }

        HttpClientHandler handler = new HttpClientHandler();


        public ApiConnect()
        {
            //_httpClient = new HttpClient()
            //{
            //    BaseAddress = new Uri("http://10.0.2.2:5105/api/")
            //};
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }; //<- Чтоб апи подключалось 0.o

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://10.0.2.2:5105/api/")
            };
            _messagesServise =MessagesServise.Instance;
        }


        //***Книги**

        //получить список книг
        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {
                    var responce = await _httpClient.GetAsync("Books/GetBooks");
                    if (!responce.IsSuccessStatusCode)
                    {
                        await _messagesServise.ShowWarning("Error", responce.StatusCode.ToString());
                        return null;
                    }
                    else return await responce.Content.ReadFromJsonAsync<List<Book>>();
                    
            }
            catch (Exception ex)
            {
                await _messagesServise.ShowWarning("Error", ex.ToString());
                return null;
            }
        }

        // Получить книгу по ID
        public async Task<Book> GetBookByIdAsync(int id)
        {
            try
            {
                var responce = await _httpClient.GetAsync($"Books/ GetBookById/{id}");
                if (!responce.IsSuccessStatusCode)
                {
                    await _messagesServise.ShowWarning("Error", responce.StatusCode.ToString());
                    return null;
                }
                else return await responce.Content.ReadFromJsonAsync<Book>();
            }
            catch (Exception ex)
            {
                await _messagesServise.ShowWarning("Error", ex.ToString());
                return null;
            }
        }

        // Добавить новую книгу
        public async Task AddBookAsync(Book book)
        {
            try
            {
                string json = JsonSerializer.Serialize(book);
                var responce = await _httpClient.PostAsync($"Books/AddBook",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                if (!responce.IsSuccessStatusCode)
                {
                    await _messagesServise.ShowWarning("Error", responce.StatusCode.ToString());
                }
                else
                {
                    BooksListChanged.Invoke();
                    //привязка к текущему пользователю
                    if (CurrentUser != null)
                    {
                        LinkBookToUserAsync(book.Id, CurrentUser.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                await _messagesServise.ShowWarning("Error", ex.ToString());
            }
        }

        //Обновление книги
        public async Task UpdateBookAsync(Book book)
        {
            string json = JsonSerializer.Serialize(book);
            try
            {
                var responce = await _httpClient.PostAsJsonAsync($"Books/UpdateBook",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                if (!responce.IsSuccessStatusCode)
                {
                    await _messagesServise.ShowWarning("Error", responce.StatusCode.ToString());
                }
                else BooksListChanged.Invoke();
            }
            catch (Exception ex)
            {
                await _messagesServise.ShowWarning("Error", ex.ToString());
            }
        }

        // Удалить книгу по ID
        public async Task DeleteBookAsync(int id)
        {
            try
            {
                var responce = await _httpClient.DeleteAsync($"Books/DeleteBook/{id}");
                if (!responce.IsSuccessStatusCode)
                {
                    await _messagesServise.ShowWarning("Error", responce.StatusCode.ToString());
                }
                else
                {
                    BooksListChanged.Invoke();
                }
            }
            catch (Exception ex)
            {
                await _messagesServise.ShowWarning("Error", ex.ToString());
            }
        }

        // Привязка книги к пользователю
        public async Task LinkBookToUserAsync(int bookId, int userId)
        {
            try
            {
                var responce = await _httpClient.GetAsync($"Books/LinkBookToUser/{bookId}/{userId}");
                if (!responce.IsSuccessStatusCode)
                {
                    await _messagesServise.ShowWarning("Error", responce.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                await _messagesServise.ShowWarning("Error", ex.ToString());
            }
        }

        // Отвязка книги от пользователя
        public async Task UnlinkBookFromUserAsync(int bookId)
        {
            
            try
            {
                var responce = await _httpClient.GetAsync($"Books/UnlinkBookFromUser/{bookId}");
                if (!responce.IsSuccessStatusCode)
                {
                    await _messagesServise.ShowWarning("Error", responce.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                await _messagesServise.ShowWarning("Error", ex.ToString());
            }
        }


        //***Пользователи***

        // Получить всех пользователей
        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                var responce = await _httpClient.GetAsync($"Users/GetUsers");
                if (!responce.IsSuccessStatusCode)
                {
                    await _messagesServise.ShowWarning("Error", responce.StatusCode.ToString());
                    return null;
                }
                else return await responce.Content.ReadFromJsonAsync<List<User>>();
            }
            catch (Exception ex)
            {
                await _messagesServise.ShowWarning("Error", ex.ToString());
                return null;
            }
        }

        // Получить пользователя по ID
        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                var responce = await _httpClient.GetAsync($"Users/ GetUserById/{id}");
                if (!responce.IsSuccessStatusCode)
                {
                    await _messagesServise.ShowWarning("Error", responce.StatusCode.ToString());
                    return null;
                }
                else return await responce.Content.ReadFromJsonAsync<User>();
            }
            catch (Exception ex)
            {
                await _messagesServise.ShowWarning("Error", ex.ToString());
                return null;
            }
        }

        // Добавить нового пользователя
        public async Task AddUserAsync(User user)
        {
            string json = JsonSerializer.Serialize(user);
            try
            {
                var responce = await _httpClient.PostAsJsonAsync($"Users/AddUser",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                if (!responce.IsSuccessStatusCode)
                {
                    await _messagesServise.ShowWarning("Error", responce.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                await _messagesServise.ShowWarning("Error", ex.ToString());
            }
        }



        // Удалить пользователя по ID
        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var responce = await _httpClient.DeleteAsync($"Users/DeleteUser/{id}");
                if (!responce.IsSuccessStatusCode)
                {
                    await _messagesServise.ShowWarning("Error", responce.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                await _messagesServise.ShowWarning("Error", ex.ToString());
            }
        }

        // Авторизация
        public async Task<User> LoginAsync(User user)
        {
            try
            {
                string json = JsonSerializer.Serialize(user);
                var responce = await _httpClient.PostAsync($"Users/Login",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                if (!responce.IsSuccessStatusCode)
                {
                    await _messagesServise.ShowWarning("Error", responce.StatusCode.ToString());
                    return null;
                }
                else return await responce.Content.ReadFromJsonAsync<User>();
            }
            catch (Exception ex)
            {
                await _messagesServise.ShowWarning("Error", ex.ToString());
                return null;
            }
            
        }
    }

}

