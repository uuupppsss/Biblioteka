using Biblioteka.mvvm.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.viewmodel
{
    public class MainPageVM:BaseVM
    {
        //Коллекция всех книг
        private ApiConnect connect;
        private List<Book> _books;
        public List<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                Signal();
            }
        }

        // Коллекция популярных книг
        private List<Book> _popularBooks;
        public List<Book> PopularBooks
        {
            get => _popularBooks;
            set
            {
                _popularBooks = value;
                Signal();
            }
        }

        // Выбранная книга
        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set { 
                _selectedBook = value;
                Signal();
            }
        }

        public CommandVM AddBook { get; set; }
        public CommandVM GoToDetails { get; set; }
        public CommandVM UpdateBook { get; set; }


        public MainPageVM()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            connect =ApiConnect.Instance;
            connect.BooksListChanged += LoadBooks;
            LoadBooks();
            AddBook = new CommandVM(async () =>
            {
                await Shell.Current.GoToAsync("AddBookPage");
            });
        }

        private async void LoadBooks()
        {
            Books = await connect.GetBooksAsync();
            PopularBooks = Books.Where(b => b.IsPopular).ToList();
        }
    }
}
