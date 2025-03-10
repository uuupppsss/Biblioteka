using Biblioteka.mvvm.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.viewmodel
{
    public class FooterVM
    {
        private ApiConnect connect;
        private MessagesServise messagesServise;
        public CommandVM LogOut { get; set; }
        public CommandVM DeleteAccount { get; set; }
        public FooterVM()
        {
            connect= ApiConnect.Instance;
            messagesServise=MessagesServise.Instance;

            LogOut = new CommandVM(async () =>
            {
                if (connect.CurrentUser!=null)
                {
                    await messagesServise.ShowWarning("Выйти", $"Вы выйдете из текущего аккаунта {connect.CurrentUser.Username}");
                    connect.CurrentUser = null;
                }
            });

            DeleteAccount= new CommandVM(async () =>
            {
                if (connect.CurrentUser != null)
                {
                    await messagesServise.ShowWarning("Удалить", $"Вы удалите текущий аккаунт {connect.CurrentUser.Username}");
                    await connect.DeleteUserAsync(connect.CurrentUser.Id);
                    connect.CurrentUser = null;
                }
            });
        }
    }
}
