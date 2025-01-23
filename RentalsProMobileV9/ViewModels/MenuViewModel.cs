using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using RentalsProMobileV9.Infrastructure.Repository.Interface;
using RentalsProMobileV9.ViewModels.Base;
using RentalsProMobileV9.Views;

namespace RentalsProMobileV9.ViewModels
{
    public record ButtonItem(string Text, IAsyncRelayCommand Command);

    public partial class MenuViewModel : ViewModelBase
    {
        public ObservableCollection<ButtonItem> ButtonItems { get; }

        public MenuViewModel() : this(null) { }

        public MenuViewModel(INavigation navigation) : base(navigation)
        {
            ButtonItems = InitializeButtonItems();
        }

        private ObservableCollection<ButtonItem> InitializeButtonItems()
        {
            return new ObservableCollection<ButtonItem>
            {
                new("Properties", new AsyncRelayCommand(NavigateToPropertiesAsync))
            };
        }

        private async Task NavigateToPropertiesAsync()
        {
            if (_navigation == null)
            {
                DisplayAlertAsync("Error", "Navigation is not available.");
                return;
            }

            await _navigation.PushAsync(new PropertiesPage(_navigation));
        }
    }
}
