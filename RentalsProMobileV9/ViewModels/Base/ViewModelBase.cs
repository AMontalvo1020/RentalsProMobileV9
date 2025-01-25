using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProAPIV8.Maui.Infrastructure;
using RentalsProAPIV8.Maui.ViewModels;
using RentalsProMobileV9.Infrastructure.Repository;
using RentalsProMobileV9.Infrastructure.Repository.Interface;

namespace RentalsProMobileV9.ViewModels.Base
{
    public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
    {
        // Dependencies
        private long _isBusy;
        public INavigation _navigation { get; }
        public IDeviceState _deviceState { get; }
        public IRentalsProRepository _Repository { get; }
        public IAsyncRelayCommand InitializeAsyncCommand { get; }
        public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;

        [ObservableProperty] private bool isOnline;
        [ObservableProperty] private bool isInitialized;
        [ObservableProperty] private PropertyDTO property;
        [ObservableProperty] private UnitDTO unit;
        [ObservableProperty] private ObservableCollection<UnitDTO> units = new();
        [ObservableProperty] private LeaseDTO lease;
        [ObservableProperty] private ObservableCollection<UserDTO> tenants = new();

        protected ViewModelBase()
        {
            _Repository = new RentalsProRepository();
            _deviceState = new DeviceState();

            InitializeDeviceConnection();

            InitializeAsyncCommand = new AsyncRelayCommand(async () =>
            {
                await IsBusyFor(InitializeAsync);
                IsInitialized = true;
            });
        }

        protected ViewModelBase(INavigation navigation) : this()
        {
            _navigation = navigation;
        }

        protected ViewModelBase(INavigation navigation, PropertyDTO property) : this(navigation)
        {
            Property = property;
        }

        public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
        {
        }

        public virtual Task InitializeAsync() => Task.CompletedTask;

        protected async Task IsBusyFor(Func<Task> unitOfWork)
        {
            Interlocked.Increment(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));

            try
            {
                await unitOfWork();
            }
            finally
            {
                Interlocked.Decrement(ref _isBusy);
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public async void DisplayAlertAsync(string title, string message, string buttonText = "OK")
        {
            if (Application.Current?.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert(title, message, buttonText);
            }
        }

        public void InitializeDeviceConnection()
        {
            try
            {
                IsOnline = _deviceState.IsOnline();
                if (!IsOnline)
                {
                    DisplayAlertAsync("No Internet", "You are not currently connected to the internet.");
                }
            }
            catch (Exception ex)
            {
                DisplayAlertAsync("Error", $"An error occurred while checking connectivity: {ex.Message}");
            }
        }
    }
}
