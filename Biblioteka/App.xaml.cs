using Biblioteka.mvvm.view;

namespace Biblioteka
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
