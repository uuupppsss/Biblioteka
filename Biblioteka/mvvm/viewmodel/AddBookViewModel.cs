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
        private ApiConnect connect;
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public CommandVM SaveBookCommand { get; }

        public AddBookViewModel()
        {
            connect=ApiConnect.Instance;
            SaveBookCommand = new CommandVM(() => SaveBook());
        }

        private async void SaveBook()
        {
            if (!string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Author))
            {
                await connect.AddBookAsync(new Book { Title = Title, Author = Author, Description = Description });
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Введите название и автора", "OK");
            }
        }


    }
}
