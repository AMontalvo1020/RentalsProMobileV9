using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentalsProAPIV8.Client.Constants;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProAPIV8.Client.Parameters;
using RentalsProAPIV8.Core.Extensions;
using RentalsProMobileV9.Infrastructure;
using RentalsProMobileV9.ViewModels.Base;
using RentalsProMobileV9.Views;

namespace RentalsProMobileV9.ViewModels
{
    public partial class PropertiesViewModel : ViewModelBase
    {
        [ObservableProperty] private ObservableCollection<PropertyDTO> properties = new();

        public PropertiesViewModel() : base() { }

        public PropertiesViewModel(INavigation navigation) : base(navigation) { }

        public override async Task InitializeAsync()
        {
            await LoadPropertiesAsync();
        }

        [RelayCommand]
        private async Task LoadPropertiesAsync() 
            => await IsBusyFor(async () =>
               {
                   // Prepare request parameters
                   var parameters = new PostForPropertiesParameters
                   {
                       UserID = ProgramState.User.Role != (int)Enums.UserRole.Admin ? ProgramState.User.ID : null
                   };

                   // Fetch properties
                   Properties = (await _Repository.PostForPropertiesAsync(parameters)).Content.AsObservable();
               });

        [RelayCommand]
        private async Task NavigateToPropertyAsync(PropertyDTO propertyDTO)
        {
            if (propertyDTO == null)
            {
                DisplayAlertAsync("Error", "Invalid property details.");
                return;
            }

            if (_navigation == null)
            {
                DisplayAlertAsync("Error", "Navigation is not available.");
                return;
            }

            await _navigation.PushAsync(new DetailPage(_navigation, propertyDTO));
        }




        //private readonly AppObservableCollection<PropertyDTO> _properties = new();
        //public IReadOnlyList<PropertyDTO> Properties => _properties;

        //public PropertiesViewModel() : base() { }

        //public PropertiesViewModel(INavigation navigation) : base(navigation)
        //{
        //    _properties = new AppObservableCollection<PropertyDTO>();
        //    //LoadData();
        //}

        //public override async Task InitializeAsync()
        //{
        //    if (initialized)
        //    {
        //        return;
        //    }

        //    initialized = true;
        //    await LoadProperties();
        //}

        //[RelayCommand]
        //private async Task LoadProperties()
        //{
        //    await IsBusyFor(async () =>
        //    {
        //        // Get Properties
        //        var response = await _rentalsProRepository.PostForPropertiesAsync(new PostForPropertiesParameters
        //        {
        //            UserID = ProgramState.User.Role != (int)Enums.UserRole.Admin ? ProgramState.User.ID : null
        //        });

        //        _properties.ReloadData(response.Content);
        //    });
        //}

        ////private async void LoadData()
        ////{
        ////    await LoadProperties();
        ////}

        ////[RelayCommand]
        ////private async Task LoadProperties()
        ////    => await ExecuteAsync(async () =>
        ////    {
        ////        var response = await _rentalsProRepository.PostForPropertiesAsync(new PostForPropertiesParameters
        ////        {
        ////            UserID = ProgramState.User.Role != (int)Enums.UserRole.Admin ? ProgramState.User.ID : null
        ////        });

        ////        //HandleResponse(response,
        ////        //               content => Properties = (AppObservableCollection<PropertyDTO>)content.AsObservable(),
        ////        //               "No properties found.",
        ////        //               "Failed to load properties. Please try again.");
        ////    });

        //[RelayCommand]
        //private async Task NavigateToProperty(PropertyDTO propertyDTO)
        //{
        //    if (_navigation == null)
        //    {
        //        DisplayAlertAsync("Error", "Navigation is not available.");
        //        return;
        //    }

        //    await _navigation.PushAsync(new DetailPage(_navigation, propertyDTO));
        //}
    }
}
