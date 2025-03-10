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

        public ApiConnect()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://192.168.0.1:5105/api/")
            };
            _messagesServise=MessagesServise.Instance;
        }


        //***Книги***

        //получить список книг
        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {
                var responce = await _httpClient.GetAsync("books/GetBooks");
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
                var responce = await _httpClient.GetAsync($"books/ GetBookById/{id}");
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
                var responce = await _httpClient.PostAsync($"books/AddBook",
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

        // Удалить книгу по ID
        public async Task DeleteBookAsync(int id)
        {
            try
            {
                var responce = await _httpClient.DeleteAsync($"books/DeleteBook/{id}");
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

        // Привязка книги к пользователю
        public async Task LinkBookToUserAsync(int bookId, int userId)
        {
            try
            {
                var responce = await _httpClient.GetAsync($"books/LinkBookToUser/{bookId}/{userId}");
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
                var responce = await _httpClient.GetAsync($"books/UnlinkBookFromUser/{bookId}");
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
                var responce = await _httpClient.GetAsync($"users/GetUsers");
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
                var responce = await _httpClient.GetAsync($"users/ GetUserById/{id}");
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
                var responce = await _httpClient.PostAsJsonAsync($"users/AddUser",
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
                var responce = await _httpClient.DeleteAsync($"users/DeleteUser/{id}");
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
                var responce = await _httpClient.PostAsync($"users/Login",
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

