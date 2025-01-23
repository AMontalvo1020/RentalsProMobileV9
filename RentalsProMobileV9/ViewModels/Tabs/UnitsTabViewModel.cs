using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProMobileV9.ViewModels.Base;
using RentalsProAPIV8.Core.Extensions;
using CommunityToolkit.Mvvm.Input;

namespace RentalsProMobileV9.ViewModels.Tabs
{
    public partial class UnitsTabViewModel : TabViewModelBase
    {
        public UnitsTabViewModel() : base() { }

        public UnitsTabViewModel(INavigation navigation, PropertyDTO propertyDTO) : base(navigation, propertyDTO)
        {
            //LoadUnitsAsync();
        }

        //[RelayCommand]
        //public async void LoadUnitsAsync()
        //    => await ExecuteAsync(async () =>
        //             {
        //                 var response = await _rentalsProRepository.GetUnitsAsync(Property.ID.Value, true);
                     
        //                 HandleResponse(response,
        //                                content => Units = content.AsObservable(),
        //                                "No units found.",
        //                                "Failed to load unit details.");
        //             });
    }
}
