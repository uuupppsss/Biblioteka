using Biblioteka.mvvm.model;

namespace Biblioteka.mvvm.view;

public partial class RegisterPage : ContentPage
{
    //private FakeDB database;
    //public string Username { get; set; }
    //public string Password { get; set; }
    //public RegisterPage()
    //{
    //    InitializeComponent();
    //    database = new FakeDB();
    //    BindingContext = this;
    //}
    //private async void OnRegisterClicked(object sender, EventArgs e)
    //{
    //    await database.AddUserAsync(new User { Username = Username, Password = Password });
    //    await DisplayAlert("Óñïåõ", "Ïîëüçîâàòåëü çàðåãèñòðèðîâàí", "OK");
    //    await Navigation.PushAsync(new LoginPage());
    //}
    //private async void OnBackClicked(object sender, EventArgs e)
    //{
    //    await Navigation.PopAsync();
    //}
    //Переход на LoginPage после регистрации
    //private async void OnRegisterClicked(object sender, EventArgs e)
    //{
    //    await DisplayAlert("Успех", "Вы успешно зарегистрированы!", "OK");
    //    await Shell.Current.GoToAsync("login");
    //}

    //private async void OnBackClicked(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync("login");
    //}
    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    Скрытие Flyout меню
    //    Shell.Current.FlyoutIsPresented = false;

    //    Скрытие вкладок
    //    var tabs = Shell.Current.Items.OfType<TabBar>().ToList();
    //    foreach (var tab in tabs)
    //    {
    //        tab.IsVisible = false;
    //    }
    //}

    //protected override void OnDisappearing()
    //{
    //    base.OnDisappearing();

    //    var tabs = Shell.Current.Items.OfType<TabBar>().ToList();
    //    foreach (var tab in tabs)
    //    {
    //        tab.IsVisible = true;
    //    }
    //}
}