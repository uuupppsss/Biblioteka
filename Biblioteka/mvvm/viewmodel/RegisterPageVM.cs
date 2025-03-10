using Biblioteka.mvvm.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.viewmodel
{
    public class RegisterPageVM:BaseVM
    {
        private ApiConnect connect;
        private MessagesServise messagesServise;

        public CommandVM RegisterCommand { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public RegisterPageVM()
        {
            connect=ApiConnect.Instance;
            messagesServise=MessagesServise.Instance;

            RegisterCommand = new CommandVM(async () =>
            {
                if (Username == null || Password == null)
                {
                    messagesServise.ShowWarning("Ошибка", "Заполните все поля");
                }
                else
                {
                    await connect.AddUserAsync(new User {Username=Username,Password=Password});
                    messagesServise.ShowWarning("Успешно", "Вы зарегистрированы");
                }
            });
        }
    }
}
