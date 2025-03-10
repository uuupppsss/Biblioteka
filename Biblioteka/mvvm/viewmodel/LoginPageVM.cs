using Biblioteka.mvvm.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.viewmodel
{
    public class LoginPageVM:BaseVM
    {
        private FakeDB connect;
        private MessagesServise messagesServise;
        public CommandVM LoginCommand {  get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginPageVM()
        {
            connect = FakeDB.Instance;
            messagesServise = MessagesServise.Instance;

            LoginCommand = new CommandVM(async () =>
            {
                if (Username == null || Password == null)
                {
                    messagesServise.ShowWarning("Ошибка", "Заполните все поля");
                }
                else
                {
                    User foundUser=await connect.LoginAsync(Username,Password);
                    if (foundUser != null)
                    {
                        connect.CurrentUser = foundUser;
                        messagesServise.ShowWarning("Успешно",$"Добро пожаловать, {Username}");
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                    else
                    {
                        messagesServise.ShowWarning("Ошибка", "Пользователь не найден");
                    }
                }
            });
        }
    }
}
