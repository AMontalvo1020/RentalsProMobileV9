using RentalsProMobileV9.Infrastructure;

namespace RentalsProMobileV9
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage();
            ProgramState.SetupApiManager();
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}