using Biblioteka.mvvm.model;

namespace Biblioteka.mvvm.view;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }
    //   private FakeDB _database;
    //   public string Username { get; set; }
    //   public string Password { get; set; }
    //   public LoginPage()
    //{
    //	InitializeComponent();
    //       _database = new FakeDB();
    //       BindingContext = this;
    //   }
    //private async void OnLoginClicked(object sender, EventArgs e)
    //{
    //    var user = await _database.AuthenticateUserAsync(Username, Password);
    //    if (user != null)
    //        await Navigation.PushAsync(new MainPage());
    //    else
    //        await DisplayAlert("Îøèáêà", "Íåâåðíûå ó÷åòíûå äàííûå", "OK");
    //}
    //private async void OnRegisterClicked(object sender, EventArgs e)
    //{
    //    await Navigation.PushAsync(new RegisterPage());
    //}
    //private async void OnLoginClicked(object sender, EventArgs e)
    //{
    //    if (Username == "admin" && Password == "1234")
    //    {
    //        await Shell.Current.GoToAsync("//MainPage"); // Переход на Главную страницу
    //    }
    //    else
    //    {
    //        await DisplayAlert("Ошибка", "Неверный логин или пароль.", "OK");
    //    }
    //}

    //// Переход на RegisterPage
    //private async void OnRegisterClicked(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync("register"); // Переход на страницу регистрации
    //}

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    // Скрытие Flyout меню
    //    Shell.Current.FlyoutIsPresented = false;

    //    // Скрытие вкладок
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