using System.Net;
using CommunityToolkit.Mvvm.Input;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProMobileV9.ViewModels.Base;

namespace RentalsProMobileV9.ViewModels.Popups
{
    public partial class LeasePopupViewModel : PopupViewModelBase
    {
        public LeasePopupViewModel() : base() { }

        public LeasePopupViewModel(INavigation navigation, PropertyDTO property, UnitDTO? unit = null) : base(navigation, property)
        {
            Lease = new LeaseDTO
            {
                PropertyID = property.ID,
                UnitID = unit != null ? unit.UnitID : null,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
        }

        [RelayCommand]
        public override async Task SaveAsync()
        {
            await IsBusyFor(async () =>
            {
                var response = await _Repository.PostLeaseAsync(Lease);
                if (response.Content)
                {
                    DisplayAlertAsync("Save Successful!", "Lease saved Successfully.");
                    await _navigation.PopModalAsync(true);
                }
                else
                {
                    DisplayAlertAsync("Save Unsuccessful!", "There was an issue saving.");
                }
            });
        }
    }
}
