using Biblioteka.mvvm.model;
using Biblioteka.mvvm.viewmodel;

namespace Biblioteka.mvvm.view;

public partial class BookDetailPage : ContentPage
{
    public BookDetailPage()
    {
        InitializeComponent();
        BindingContext = new BookDetailPageViewModel();
    }

    //private async void OnBackClicked(object sender, EventArgs e)
    //{
    //    await Navigation.PopAsync();
    //}
    // Вернуться на Главную страницу
    //private async void OnBackClicked(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync("MainPage");
    //}
}