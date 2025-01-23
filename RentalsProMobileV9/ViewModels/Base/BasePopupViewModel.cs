using CommunityToolkit.Mvvm.Input;
using RentalsProAPIV8.Client.DataTransferObjects;

namespace RentalsProMobileV9.ViewModels.Base
{
    public abstract partial class BasePopupViewModel : BasePageViewModel
    {
        public BasePopupViewModel() : base() { }

        public BasePopupViewModel(INavigation navigation, PropertyDTO property) : base(navigation, property)
        {
            Property = property;
        }

        [RelayCommand]
        public async Task CancelAsync()
        {
            await _navigation.PopModalAsync(true);
        }

        public abstract Task SaveAsync();
    }
}
