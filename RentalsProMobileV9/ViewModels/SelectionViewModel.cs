using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RentalsProMobileV9.ViewModels
{
    public partial class SelectionViewModel<T> : ObservableObject
    {
        [ObservableProperty] 
        private bool _selected;

        [ObservableProperty] 
        private T _value;
    }
}
