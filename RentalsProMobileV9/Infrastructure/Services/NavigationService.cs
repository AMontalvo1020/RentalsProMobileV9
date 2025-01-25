using RentalsProMobileV9.Infrastructure.Services.Interfaces;
using RentalsProMobileV9.Views;

namespace RentalsProMobileV9.Infrastructure.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IAppEnvironmentService _appEnvironmentService;

        public NavigationService(IAppEnvironmentService appEnvironmentService)
        {
            _appEnvironmentService = appEnvironmentService;
        }

        public async Task InitializeAsync()
        {
            var user = _appEnvironmentService.IdentityService.GetUserInfoAsync();

            NavigateToPage(user == null ? new LoginPage() : new PropertiesPage());

            //await NavigateToAsync(user == null ? "//Login" : "//Main/Catalog");
        }

        public void NavigateToPage(Page page)
        {
            if (Application.Current?.MainPage is NavigationPage navigationPage)
            {
                navigationPage.Navigation.PushAsync(page);
            }

            throw new InvalidOperationException("The application is not using a NavigationPage as its MainPage.");
        }

        public Task PopAsync()
        {
            return Shell.Current.GoToAsync("..");
        }
    }
}
