using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalsProMobileV9.Infrastructure.Services.Interfaces
{
    public interface INavigationService
    {
        Task InitializeAsync();

        //Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null);

        void NavigateToPage(Page page);

        Task PopAsync();
    }
}
