using RentalsProAPIV7.Maui.Extensions;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProMobileV9.ViewModels.Base.Interface;
using RentalsProMobileV9.ViewModels.Tabs;

namespace RentalsProMobileV9.Views.Tabs;

public partial class DetailsTab : ContentPage
{
	public DetailsTab()
	{
		InitializeComponent();
	}
    public DetailsTab(INavigation navigation, PropertyDTO property) : this()
    {
        this.SetBindingContext(new DetailsTabViewModel(navigation, property));
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