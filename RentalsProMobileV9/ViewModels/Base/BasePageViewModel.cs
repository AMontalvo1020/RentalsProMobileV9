using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProMobileV9.Infrastructure;
using RentalsProMobileV9.Infrastructure.Repository;
using RentalsProMobileV9.Infrastructure.Repository.Interface;

namespace RentalsProMobileV9.ViewModels.Base
{
    public abstract partial class BasePageViewModel : ObservableObject
    {
        // Dependencies
        protected readonly INavigation _navigation;
        protected readonly IRentalsProRepository _rentalsProRepository;
        protected readonly IDeviceState _deviceState;

        // Commands
        public IAsyncRelayCommand InitializeAsyncCommand { get; }

        // Properties
        [ObservableProperty] private bool isOnline;
        [ObservableProperty] private long isBusyCounter;
        [ObservableProperty] private bool isInitialized;
        [ObservableProperty] private PropertyDTO property;
        [ObservableProperty] private UnitDTO unit;
        [ObservableProperty] private ObservableCollection<UnitDTO> units = new();
        [ObservableProperty] private LeaseDTO lease;
        [ObservableProperty] private ObservableCollection<UserDTO> tenants = new();

        public bool initialized;

        protected BasePageViewModel()
        {
            _rentalsProRepository = new RentalsProRepository();
            _deviceState = new DeviceState();

            InitializeDeviceConnection();

            InitializeAsyncCommand = new AsyncRelayCommand(
                async () =>
                {
                    await IsBusyFor(InitializeAsync);
                    IsInitialized = true;
                },
                AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler
            );
        }

        protected BasePageViewModel(INavigation navigation) : this()
        {
            _navigation = navigation;
        }

        protected BasePageViewModel(INavigation navigation, PropertyDTO property) : this(navigation)
        {
            Property = property;
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        protected async Task IsBusyFor(Func<Task> unitOfWork)
        {
            Interlocked.Increment(ref isBusyCounter);
            try
            {
                await unitOfWork();
            }
            finally
            {
                Interlocked.Decrement(ref isBusyCounter);
            }
        }

        private async void InitializeDeviceConnection()
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

        //public async Task ExecuteAsync(Func<Task> action)
        //{
        //    IsBusy = true;
        //    try
        //    {
        //        await action();
        //    }
        //    catch (HttpRequestException)
        //    {
        //        DisplayAlertAsync("Network Error", "Please check your internet connection and try again.");
        //    }
        //    catch (Exception ex)
        //    {
        //        DisplayAlertAsync("Error", $"An unexpected error occurred: {ex.Message}");
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        //public void HandleResponse<T>(ApiResponse<T> response, Action<T> onSuccess, string notFoundMessage, string errorMessage)
        //{
        //    if (response == null)
        //    {
        //        DisplayAlertAsync("Error", "No response received. Please check your connection.");
        //        return;
        //    }

        //    switch (response.StatusCode)
        //    {
        //        case HttpStatusCode.OK:
        //            onSuccess(response.Content);
        //            break;
        //        case HttpStatusCode.NotFound:
        //            DisplayAlertAsync("Not Found", notFoundMessage);
        //            break;
        //        default:
        //            DisplayAlertAsync("Error", errorMessage);
        //            break;
        //    }
        //}

        public async void DisplayAlertAsync(string title, string message)
        {
            if (Application.Current?.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert(title, message, "OK");
            }
        }
    }
}
