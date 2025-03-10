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
    //    private readonly FakeDB _database;
    //    public ObservableCollection<Book> Books { get; set; }

    //    private Book _selectedBook;
    //    public Book SelectedBook
    //    {
    //        get => _selectedBook;
    //        set { 
    //            _selectedBook = value;
    //            Signal(); 
    //        }
    //    }

    //    public Command AddBookCommand { get; }
    //    public Command<Book> DeleteBookCommand { get; }
    //    public Command<Book> SelectBookCommand { get; }

    //    public BooksViewModel()
    //    {
    //        _database = new FakeDB();
    //        Books = new ObservableCollection<Book>();
    //        LoadBooks();

    //        AddBookCommand = new Command(async () => await AddBook());
    //        DeleteBookCommand = new Command<Book>(async (book) => await DeleteBook(book));
    //        SelectBookCommand = new Command<Book>(async (book) => await SelectBook(book));
    //    }

    //    private async void LoadBooks()
    //    {
    //        var books = await _database.GetBooksAsync();
    //        Books.Clear();
    //        foreach (var book in books)
    //        {
    //            Books.Add(book);
    //        }
    //    }

    //    private async Task AddBook()
    //    {
    //        var database = new FakeDB();
    //        await Application.Current.MainPage.Navigation.PushAsync(new AddBookPage(database));
    //    }

    //    private async Task DeleteBook(Book book)
    //    {
    //        if (book != null)
    //        {
    //            bool confirm = await Application.Current.MainPage.DisplayAlert("Удаление", "Вы уверены, что хотите удалить эту книгу?", "Да", "Нет");
    //            if (confirm)
    //            {
    //                await _database.RemoveBookByIdAsync(book.Id);
    //                LoadBooks();
    //            }
    //        }
    //    }

    //    private async Task SelectBook(Book book)
    //    {
    //        if (book != null)
    //        {
    //            await Application.Current.MainPage.Navigation.PushAsync(new BookDetailPage(book));
    //        }
    //    }
    }
}
