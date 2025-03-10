using Biblioteka.mvvm.model;
using Biblioteka.mvvm.view;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.viewmodel
{
    public class BooksViewModel:BaseVM
    {
		private ApiConnect connect;

		private List<Book> _books;

		public List<Book> Books
		{
			get { return _books; }
			set { 
				_books = value;
				Signal();
			}
		}

		private Book _selectedBook;

		public Book SelectedBook
		{
			get { return _selectedBook; }
			set { 
				_selectedBook = value; 
				Signal() ;
			}
		}


		public CommandVM ViewDetails {  get; set; }

        public BooksViewModel()
        {
            connect=ApiConnect.Instance;
			ViewDetails = new CommandVM(async () =>
			{
                if (SelectedBook != null)
                {
                    var navigationParameter = new ShellNavigationQueryParameters
                {
                    { "SelectedBook", SelectedBook }
                };
                    await Shell.Current.GoToAsync("BookDetailPage", navigationParameter);
                    SelectedBook = null;
                }
            });
		}

    }
}
