namespace RentalsProMobileV9.Infrastructure
{
    public interface IDeviceState
    {
        bool IsOnline();
    }

    public class DeviceState : IDeviceState
    {
        public bool IsOnline()
        {
            return Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        }
    }
}
