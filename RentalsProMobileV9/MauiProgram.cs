using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Logging;
using RentalsProMobileV9.Infrastructure.Repository;
using RentalsProMobileV9.Infrastructure.Repository.Interface;
using RentalsProMobileV9.ViewModels;
using RentalsProMobileV9.ViewModels.Base;
using RentalsProMobileV9.ViewModels.Tabs;
using RentalsProMobileV9.Views;
using RentalsProMobileV9.Views.Tabs;

namespace RentalsProMobileV9
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            return MauiApp.CreateBuilder()
                          .UseMauiApp<App>()
                          .ConfigureEffects(effects => { })
                          .UseMauiCommunityToolkit()
                          .UseMauiCommunityToolkitCore()
                          .ConfigureFonts(fonts =>
                          {
                              fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                              fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                              fonts.AddFont("FontAwesomeRegular.otf", "FontAwesome-Regular");
                              fonts.AddFont("FontAwesomeSolid.otf", "FontAwesome-Solid");
                              fonts.AddFont("Montserrat-Bold.ttf", "Montserrat-Bold");
                              fonts.AddFont("Montserrat-Regular.ttf", "Montserrat-Regular");
                          })
                          .RegisterAppServices()
                          .RegisterViewModels()
                          .Build();
//            var builder = MauiApp.CreateBuilder();
//            builder.UseMauiApp<App>()
//                   .UseMauiCommunityToolkit()
//                   .UseMauiCommunityToolkitCore()
//                   .RegisterViewModels()
//                   .ConfigureFonts(fonts =>
//                   {
//                       fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
//                       fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
//                   });

//            // Register your services here
//            builder.Services.AddTransient<IRentalsProRepository, RentalsProRepository>();
//#if DEBUG
//            builder.Logging.AddDebug();
//#endif

//            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            //mauiAppBuilder.Services.AddTransient<LoginViewModel>();
            //mauiAppBuilder.Services.AddTransient<MenuViewModel>();
            //mauiAppBuilder.Services.AddTransient<PropertiesViewModel>();
            //mauiAppBuilder.Services.AddTransient<DetailsViewModel>();
            //mauiAppBuilder.Services.AddTransient<BasePageViewModel>();
            //mauiAppBuilder.Services.AddTransient<BaseTabViewModel>();
            //mauiAppBuilder.Services.AddTransient<BasePopupViewModel>();
            //mauiAppBuilder.Services.AddTransient<DetailsViewModel>();
            //mauiAppBuilder.Services.AddTransient<DetailsTabViewModel>();
            //mauiAppBuilder.Services.AddTransient<LeaseTabViewModel>();
            //mauiAppBuilder.Services.AddTransient<UnitsTabViewModel>();
            //mauiAppBuilder.Services.AddTransient<DetailsViewModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            //mauiAppBuilder.Services.AddSingleton<DetailPage>();
            //mauiAppBuilder.Services.AddTransient<PropertiesPage>();

            return mauiAppBuilder;
        }
    }
}
