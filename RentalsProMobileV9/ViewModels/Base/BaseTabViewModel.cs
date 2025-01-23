using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalsProAPIV8.Client.DataTransferObjects;

namespace RentalsProMobileV9.ViewModels.Base
{
    public partial class BaseTabViewModel : BasePageViewModel
    {
        public BaseTabViewModel() : base() { }

        public BaseTabViewModel(INavigation navigation) : base(navigation) { }

        public BaseTabViewModel(INavigation navigation, PropertyDTO property) : base(navigation, property) { }
    }
}
