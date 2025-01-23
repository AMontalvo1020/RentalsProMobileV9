using RentalsProAPIV7.Maui.Extensions;
using RentalsProAPIV8.Client.Constants;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProMobileV9.ViewModels;
using RentalsProMobileV9.ViewModels.Tabs;
using RentalsProMobileV9.Views.Tabs;

namespace RentalsProMobileV9.Views;

public partial class DetailPage : TabbedPage
{
	public DetailPage()
	{
		InitializeComponent();
	}

    public DetailPage(INavigation navigation, PropertyDTO propertyDTO) : this()
    {
        this.SetBindingContext(new DetailsViewModel(navigation, propertyDTO));
        AddDetailTabs(navigation, propertyDTO);
    }

    private void AddDetailTabs(INavigation navigation, PropertyDTO propertyDTO)
    {
        this.AddTab<DetailsTab, DetailsTabViewModel>(navigation, propertyDTO);
        if (ShouldAddLeaseTab(propertyDTO))
        {
            this.AddTab<LeaseTab, LeaseTabViewModel>(navigation, propertyDTO);
        }
        if (ShouldAddUnitsTab(propertyDTO))
        {
            this.AddTab<UnitsTab, UnitsTabViewModel>(navigation, propertyDTO);
        }
    }

    private static bool ShouldAddLeaseTab(PropertyDTO propertyDTO)
    {
        return propertyDTO.Units == null || propertyDTO.Units.Count == 0;
    }

    private static bool ShouldAddUnitsTab(PropertyDTO propertyDTO)
    {
        return propertyDTO?.Units?.Count > 0;
    }
}