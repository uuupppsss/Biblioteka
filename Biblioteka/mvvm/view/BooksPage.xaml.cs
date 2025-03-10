using Biblioteka.mvvm.viewmodel;

namespace Biblioteka.mvvm.view;

public partial class BooksPage : ContentPage
{
	public BooksPage()
	{
		InitializeComponent();
		BindingContext = new BooksViewModel();
	}
}