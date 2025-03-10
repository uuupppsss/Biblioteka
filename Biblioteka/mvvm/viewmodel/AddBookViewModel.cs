using Biblioteka.mvvm.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.viewmodel
{
    public class AddBookViewModel :BaseVM
    {
        private MessagesServise messagesServise;
        private ApiConnect connect;
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public CommandVM SaveBookCommand { get; }

        public AddBookViewModel()
        {
            messagesServise=MessagesServise.Instance;
            connect=ApiConnect.Instance;
            SaveBookCommand = new CommandVM(() => SaveBook());
        }

        private async void SaveBook()
        {
            if (!string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Author))
            {
                await connect.AddBookAsync(new Book { Title = Title, Author = Author, Description = Description });
                await messagesServise.ShowWarning("Успешно", "Книга добавлена");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await messagesServise.ShowWarning("Ошибка", "Заполните все поля");
            }
        }


    }
}
