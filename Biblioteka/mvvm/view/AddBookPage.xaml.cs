using Biblioteka.mvvm.model;
using Biblioteka.mvvm.viewmodel;

namespace Biblioteka.mvvm.view;

public partial class AddBookPage : ContentPage
{
    public AddBookPage()
    {
        InitializeComponent();
        BindingContext = new AddBookViewModel();
    }
    //private readonly FakeDB _database;
    //private readonly Book _originalBookData; // Исходные данные для восстановления
    //private readonly Book _bookToEdit;

    //public AddBookPage(FakeDB database, Book bookToEdit = null)
    //{
    //    InitializeComponent();
    //    _database = database;
    //    _bookToEdit = bookToEdit;

    //    if (_bookToEdit != null)
    //    {
    //        // Сохраняем исходные данные для отмены редактирования
    //        _originalBookData = new Book
    //        {
    //            Title = _bookToEdit.Title,
    //            Author = _bookToEdit.Author,
    //            Genre = _bookToEdit.Genre,
    //            PageCount = _bookToEdit.PageCount,
    //            PublishDate = _bookToEdit.PublishDate
    //        };

    //        // Заполняем поля значениями для редактирования
    //        TitleEntry.Text = _bookToEdit.Title;
    //        AuthorEntry.Text = _bookToEdit.Author;
    //        GenrePicker.SelectedItem = _bookToEdit.Genre;
    //        PagesSlider.Value = _bookToEdit.PageCount;
    //        PagesLabel.Text = $"{_bookToEdit.PageCount} страниц";
    //        PublishDatePicker.Date = _bookToEdit.PublishDate;
    //    }
    //}

    //private void OnPagesSliderChanged(object sender, ValueChangedEventArgs e)
    //{
    //    PagesLabel.Text = $"{(int)e.NewValue} страниц";
    //}

    //private async void OnSaveClicked(object sender, EventArgs e)
    //{
    //    if (string.IsNullOrWhiteSpace(TitleEntry.Text) || string.IsNullOrWhiteSpace(AuthorEntry.Text))
    //    {
    //        await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля.", "OK");
    //        return;
    //    }

    //    if (_bookToEdit == null)
    //    {
    //        var newBook = new Book
    //        {
    //            Title = TitleEntry.Text,
    //            Author = AuthorEntry.Text,
    //            Genre = GenrePicker.SelectedItem?.ToString(),
    //            PageCount = (int)PagesSlider.Value,
    //            PublishDate = PublishDatePicker.Date
    //        };

    //        await _database.AddBookAsync(newBook);
    //    }
    //    else
    //    {
    //        _bookToEdit.Title = TitleEntry.Text;
    //        _bookToEdit.Author = AuthorEntry.Text;
    //        _bookToEdit.Genre = GenrePicker.SelectedItem?.ToString();
    //        _bookToEdit.PageCount = (int)PagesSlider.Value;
    //        _bookToEdit.PublishDate = PublishDatePicker.Date;
    //        await _database.EditBookAsync(_bookToEdit);
    //    }

    //    await DisplayAlert("Успех", "Книга успешно сохранена.", "OK");
    //    await Navigation.PopAsync();
    //}

    //// Логика отмены редактирования
    //private async void OnCancelClicked(object sender, EventArgs e)
    //{
    //    if (_bookToEdit != null)
    //    {
    //        // Восстановление исходных данных
    //        _bookToEdit.Title = _originalBookData.Title;
    //        _bookToEdit.Author = _originalBookData.Author;
    //        _bookToEdit.Genre = _originalBookData.Genre;
    //        _bookToEdit.PageCount = _originalBookData.PageCount;
    //        _bookToEdit.PublishDate = _originalBookData.PublishDate;
    //    }

    //    await DisplayAlert("Отмена", "Изменения отменены.", "OK");
    //    await Navigation.PopAsync();
    //}
    // Сохранение книги и возврат на MainPage
    //private async void OnSaveClicked(object sender, EventArgs e)
    //{
    //    var newBook = new Book
    //    {
    //        Title = TitleEntry.Text,
    //        Author = AuthorEntry.Text
    //    };

    //    await _database.AddBookAsync(newBook);

    //    await DisplayAlert("Успех", "Книга добавлена!", "OK");
    //    await Shell.Current.GoToAsync("//MainPage");  // Переход на Главную страницу
    //}

    //// Отмена добавления и возврат на MainPage
    //private async void OnCancelClicked(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync("//MainPage");
    //}
}