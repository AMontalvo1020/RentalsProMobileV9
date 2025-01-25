using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProAPIV8.Client.Parameters;
using RentalsProAPIV8.Core.Extensions;
using RentalsProMobileV9.Infrastructure;
using RentalsProMobileV9.Infrastructure.Services.Interfaces;
using RentalsProMobileV9.Services.Validations;
using RentalsProMobileV9.ViewModels.Base;
using RentalsProMobileV9.Views;

namespace RentalsProMobileV9.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        [ObservableProperty] private bool _isValid;
        [ObservableProperty] private ValidatableObject<string> username = new();
        [ObservableProperty] private ValidatableObject<string> password = new();

        public LoginViewModel() : base() { }

        [RelayCommand]
        private void Validate()
        {
            IsValid = Username.Validate() && Password.Validate();
        }

        [RelayCommand]
        private async Task SignIn()
        {
            await IsBusyFor(async () =>
            {
                var user = await AuthenticateUserAsync();
                if (user != null)
                {
                    CompleteLogin(user);
                }
                else
                {
                    DisplayAlertAsync("Login Failed", "Invalid username or password.");
                }
            });
        }

        private async Task<UserDTO> AuthenticateUserAsync()
        {
            var response = await _Repository.PostForValidUserAsync(new ValidUserParameters
            {
                Username = Username.Value,
                Password = Password.Value
            });

            return response.Content;
        }

        private async void CompleteLogin(UserDTO user)
        {
            ProgramState.AddUser(user);
            Application.Current.MainPage = new NavigationPage(new MenuPage());
        }
    }
}
