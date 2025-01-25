using RentalsProAPIV8.Client.DataTransferObjects;

namespace RentalsProMobileV9.Infrastructure.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignInAsync();
        //Task<bool> SignOutAsync();
        UserDTO GetUserInfoAsync();
    }
}
