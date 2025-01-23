using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using RentalsProAPIV8.Client.DataTransferObjects;

namespace RentalsProMobileV9.ViewModels.Base
{
    public abstract partial class PopupViewModelBase : ViewModelBase
    {
        public PopupViewModelBase() : base() { }

        public PopupViewModelBase(INavigation navigation, PropertyDTO property) : base(navigation, property)
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
