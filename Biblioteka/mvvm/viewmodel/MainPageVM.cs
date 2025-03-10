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
            private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                Signal();
            }
        }

        // Коллекция популярных книг
        private ObservableCollection<Book> _popularBooks;
        public ObservableCollection<Book> PopularBooks
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
            PopularBooks = new ObservableCollection<Book>
            {
            new Book { Title = "1984", Author = "Джордж Оруэлл", Description = "Антиутопия о тоталитарном обществе." },
            new Book { Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Description = "Роман о любви, вере и мистике." },
            new Book { Title = "Убийство в Восточном экспрессе", Author = "Агата Кристи", Description = "Детективная история о загадочном убийстве." }
            };
        }
    }
}
