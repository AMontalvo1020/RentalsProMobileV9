using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalsProAPIV8.Client.DataTransferObjects;

namespace RentalsProMobileV9.ViewModels.Base
{
    public partial class TabViewModelBase : ViewModelBase
    {
        public TabViewModelBase() : base() { }
        public TabViewModelBase(INavigation navigation) : base(navigation) { }
        public TabViewModelBase(INavigation navigation, PropertyDTO property) : base(navigation, property) { }
    }
}
