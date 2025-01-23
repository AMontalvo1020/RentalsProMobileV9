using RentalsProAPIV7.Maui.Extensions;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProMobileV9.ViewModels.Popups;

namespace RentalsProMobileV9.Views.Popups;

public partial class LeasePopup : ContentPage
{
	public LeasePopup()
	{
		InitializeComponent();
	}

    public LeasePopup(INavigation navigation, PropertyDTO property)
    {
        InitializeComponent();
        this.SetBindingContext(new LeasePopupViewModel(navigation, property));
    }
}