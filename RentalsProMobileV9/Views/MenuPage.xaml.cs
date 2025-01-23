using RentalsProMobileV9.ViewModels;

namespace RentalsProMobileV9.Views;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
        BindingContext = new MenuViewModel(Navigation);
    }
}