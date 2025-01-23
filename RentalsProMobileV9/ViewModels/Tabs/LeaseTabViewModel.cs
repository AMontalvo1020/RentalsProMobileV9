using System.Net;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentalsProAPIV8.Client.API;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProAPIV8.Client.Parameters;
using RentalsProMobileV9.ViewModels.Base;
using RentalsProMobileV9.Views.Popups;

namespace RentalsProMobileV9.ViewModels.Tabs
{
    public partial class LeaseTabViewModel : TabViewModelBase
    {
        [ObservableProperty] private bool showAdd;
        [ObservableProperty] private bool showRenew; 

        public LeaseTabViewModel() : base() { }

        public LeaseTabViewModel(INavigation navigation, PropertyDTO property) : base(navigation, property) { }

        public override async Task InitializeAsync()
        {
            if (IsInitialized)
            {
                return;
            }

            IsInitialized = true;
            await LoadLeaseAsync();
        }

        private async Task LoadLeaseAsync()
        {
            await IsBusyFor(async () =>
            {
                var response = await _Repository.PostForLeaseAsync(new PostForLeaseParameters
                {
                    PropertyID = Property.ID
                });

                Lease = response.Content;
                UpdateLeaseVisibility();
            });
        }

        private void UpdateLeaseVisibility()
        {
            ShowRenew = Lease != null;
            ShowAdd = Lease == null;
        }

        [RelayCommand]
        private Task AddLeaseAsync()
            => NavigateToLeasePopupAsync();

        [RelayCommand]
        private Task RenewLeaseAsync()
            => NavigateToLeasePopupAsync();

        private Task NavigateToLeasePopupAsync()
            => _navigation.PushModalAsync(new LeasePopup(_navigation, Property), true);
    }
}
