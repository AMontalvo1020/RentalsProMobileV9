using RentalsProAPIV7.Maui.Extensions;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProMobileV9.ViewModels.Base.Interface;
using RentalsProMobileV9.ViewModels.Tabs;

namespace RentalsProMobileV9.Views.Tabs;

public partial class LeaseTab : ContentPage
{
	public LeaseTab()
	{
		InitializeComponent();
	}

    public LeaseTab(INavigation navigation, PropertyDTO property) : this()
    {
        this.SetBindingContext(new LeaseTabViewModel(navigation, property));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is not IViewModelBase ivmb)
        {
            return;
        }

        await ivmb.InitializeAsyncCommand.ExecuteAsync(null);
    }
}