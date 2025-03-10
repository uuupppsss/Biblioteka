using Biblioteka.mvvm.model;
using Biblioteka.mvvm.viewmodel;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace Biblioteka.mvvm.view;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageVM();
    }
    //    private FakeDB _database;

    //    // Коллекция всех книг
    //    private ObservableCollection<Book> _books;
    //    public ObservableCollection<Book> Books
    //    {
    //        get => _books;
    //        set
    //        {
    //            _books = value;
    //            OnPropertyChanged(nameof(Books));
    //        }
    //    }

    //    // Коллекция популярных книг
    //    private ObservableCollection<Book> _popularBooks;
    //    public ObservableCollection<Book> PopularBooks
    //    {
    //        get => _popularBooks;
    //        set
    //        {
    //            _popularBooks = value;
    //            OnPropertyChanged(nameof(PopularBooks));
    //        }
    //    }

    //    // Выбранная книга
    //    private Book _selectedBook;
    //    public Book SelectedBook
    //    {
    //        get => _selectedBook;
    //        set { _selectedBook = value; }
    //    }

    //    public MainPage()
    //    {
    //        InitializeComponent();
    //        _database = new FakeDB();
    //        GetBooksAsync();
    //        LoadPopularBooks();
    //        BindingContext = this;
    //    }

    //    // Загрузка всех книг
    //    private async void GetBooksAsync()
    //    {
    //        Books = await _database.GetBooksAsync();
    //    }

    //    // Загрузка популярных книг
    //    private void LoadPopularBooks()
    //    {
    //        PopularBooks = new ObservableCollection<Book>
    //        {
    //        new Book { Title = "1984", Author = "Джордж Оруэлл", Description = "Антиутопия о тоталитарном обществе." },
    //        new Book { Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Description = "Роман о любви, вере и мистике." },
    //        new Book { Title = "Убийство в Восточном экспрессе", Author = "Агата Кристи", Description = "Детективная история о загадочном убийстве." }
    //        };
    //    }

    //    private void OnBookSelected(object sender, ItemTappedEventArgs e)

    //    {
    //        if (e.Item is Book book)
    //        {
    //        Navigation.PushAsync(new BookDetailPage(book));
    //        }
    //    }

    ////private void OnAddBookClicked(object sender, EventArgs e)
    ////{
    ////    Navigation.PushAsync(new AddBookPage(_database));
    ////}

    //private void OnEditBookClicked(object sender, EventArgs e)
    //{
    //    if (SelectedBook != null)
    //    {
    //        Navigation.PushAsync(new AddBookPage(_database, SelectedBook));
    //    }
    //    else
    //    {
    //        DisplayAlert("Ошибка", "Выберите книгу для редактирования.", "OK");
    //    }
    //}

    //private async void OnDeleteBookClicked(object sender, EventArgs e)
    //{
    //    if (SelectedBook != null)
    //    {
    //        bool isLinked = await _database.IsBookLinkedToUserAsync(SelectedBook.Id);

    //        if (isLinked)
    //        {
    //            await DisplayAlert("Ошибка", "Нельзя удалить книгу, которая выдана пользователю.", "OK");
    //            return;
    //        }

    //        bool confirm = await DisplayAlert("Удаление", "Вы уверены, что хотите удалить эту книгу?", "Да", "Нет");

    //        if (confirm)
    //        {
    //            await _database.RemoveBookByIdAsync(SelectedBook.Id);
    //            GetBooksAsync();
    //        }
    //    }
    //}
    ////private async void OnBookDetailsClicked(object sender, EventArgs e)
    ////{
    ////    var sampleBook = new Book
    ////    {
    ////        Title = "1984",
    ////        Author = "Джордж Оруэлл",
    ////        Description = "Антиутопия о тоталитарном обществе."
    ////    };

    ////    await Navigation.PushAsync(new BookDetailPage(sampleBook));
    ////}

    //// Переход на LoginPage (выход из аккаунта)
    ////private async void OnLogoutClicked(object sender, EventArgs e)
    ////{
    ////    bool confirm = await DisplayAlert("Выход", "Вы уверены, что хотите выйти?", "Да", "Нет");

    ////    if (confirm)
    ////    {
    ////        await Navigation.PopToRootAsync(); // Вернуться к стартовой странице (LoginPage)
    ////    }
    ////}
    //// Переход на AddBookPage
    //private async void OnAddBookClicked(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync(nameof(AddBookPage));
    //}

    //// Переход на BookDetailPage с передачей данных
    //private async void OnBookDetailsClicked(object sender, EventArgs e)
    //{
    //    var sampleBook = new Book
    //    {
    //        Title = "1984",
    //        Author = "Джордж Оруэлл",
    //        Description = "Антиутопия о тоталитарном обществе."
    //    };

    //    await Shell.Current.GoToAsync($"{nameof(BookDetailPage)}?title={sampleBook.Title}&author={sampleBook.Author}&description={sampleBook.Description}");
    //}

    //// Выход на страницу авторизации
    //private async void OnLogoutClicked(object sender, EventArgs e)
    //{
    //    bool confirm = await DisplayAlert("Выход", "Вы уверены, что хотите выйти?", "Да", "Нет");

    //    if (confirm)
    //    {
    //        await Shell.Current.GoToAsync("login"); // Переход на страницу авторизации
    //    }
    //}

}
           
