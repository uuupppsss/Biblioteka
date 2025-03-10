using Biblioteka.mvvm.viewmodel;

namespace Biblioteka;

public partial class FooterView : ContentView
{
	public FooterView()
	{
		InitializeComponent();
		BindingContext = new FooterVM();
	}


}