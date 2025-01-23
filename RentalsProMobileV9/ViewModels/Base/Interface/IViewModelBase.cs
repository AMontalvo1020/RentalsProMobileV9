using CommunityToolkit.Mvvm.Input;
using RentalsProMobileV9.Infrastructure;
using RentalsProMobileV9.Infrastructure.Repository.Interface;

namespace RentalsProMobileV9.ViewModels.Base.Interface
{
    public interface IViewModelBase : IQueryAttributable
    {
        public INavigation _navigation { get; }
        public IDeviceState _deviceState { get; }
        public IRentalsProRepository _Repository { get; }
        public IAsyncRelayCommand InitializeAsyncCommand { get; }
        public bool IsBusy { get; }
        public bool IsInitialized { get; }
        void InitializeDeviceConnection();
        void DisplayAlertAsync(string title, string message, string buttonText);
        Task InitializeAsync();
    }
}
