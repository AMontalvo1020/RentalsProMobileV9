using CommunityToolkit.Mvvm.Messaging.Messages;

namespace RentalsProMobileV9.Services
{
    public class CountChangedMessage(int count) : ValueChangedMessage<int>(count);
}
