using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProMobileV9.ViewModels.Base;

namespace RentalsProMobileV9.ViewModels
{
    public partial class DetailsViewModel : TabViewModelBase
    {
        public DetailsViewModel() { }
        public DetailsViewModel(INavigation navigation, PropertyDTO propertyDTO) { }
    }
}
