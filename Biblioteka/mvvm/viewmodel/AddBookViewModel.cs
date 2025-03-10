using Biblioteka.mvvm.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.viewmodel
{
    [QueryProperty(nameof(SelectedBook), "SelectedBook")]
    public class AddBookViewModel :BaseVM
    {
        private MessagesServise messagesServise;
        private FakeDB connect;
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                Signal();
            }
        }

        private string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                Signal();
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                Signal();
            }
        }

        private string _genre;
        public string Genre
        {
            get { return _genre; }
            set
            {
                _genre = value;
                Signal();
            }
        }

        private DateTime _publishDate;
        public DateTime PublishDate
        {
            get { return _publishDate; }
            set
            {
                _publishDate = value;
                Signal();
            }
        }

        private int _pageCount;
        public int PageCount
        {
            get { return _pageCount; }
            set
            {
                _pageCount = value;
                Signal();
            }
        }

        private Book? _selectedBook;

        public Book? SelectedBook
        {
            get { return _selectedBook; }
            set { 
                _selectedBook = value;
                Signal();
            }
        }

        public CommandVM SaveBookCommand { get; }

        public AddBookViewModel()
        {
            messagesServise=MessagesServise.Instance;
            //connect=ApiConnect.Instance;
            connect=FakeDB.Instance;
            if (SelectedBook != null)
            {
                Title =SelectedBook.Title;
                Author=SelectedBook.Author;
                Description=SelectedBook.Description;
                Genre=SelectedBook.Genre;
                PublishDate=SelectedBook.PublishDate;
                PageCount=SelectedBook.PageCount;
            }
            SaveBookCommand = new CommandVM(() => SaveBook());
        }

        private async void SaveBook()
        {
            if (SelectedBook == null)
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
            else
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
}
