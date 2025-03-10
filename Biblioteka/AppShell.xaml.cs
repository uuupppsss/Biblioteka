using Biblioteka.mvvm.view;

namespace Biblioteka
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BookDetailPage), typeof(BookDetailPage));
            Routing.RegisterRoute(nameof(AddBookPage), typeof(AddBookPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
        
    }
}
