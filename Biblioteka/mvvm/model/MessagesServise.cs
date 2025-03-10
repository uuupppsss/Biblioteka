using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.model
{
    public class MessagesServise
    {
        static MessagesServise instance;

        public static MessagesServise Instance
        {
            get
            {
                if (instance == null)
                    instance = new MessagesServise();
                return instance;
            }
        }
        public async Task ShowWarning(string title, string message)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, "OK");
        }
    }
}
