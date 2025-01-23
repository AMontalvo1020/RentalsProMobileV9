using RentalsProAPIV7.Maui.Extensions;
using RentalsProMobileV9.ViewModels;
using RentalsProMobileV9.ViewModels.Base.Interface;

namespace RentalsProMobileV9.Views
{
    public partial class PropertiesPage : ContentPage
    {
        public PropertiesPage()
        {
            InitializeComponent();
        }

        public PropertiesPage(INavigation navigation) : this()
        {
            this.SetBindingContext(new PropertiesViewModel(navigation));
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
}