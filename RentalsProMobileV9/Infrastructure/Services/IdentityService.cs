using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProAPIV8.Client.Parameters;
using RentalsProMobileV9.Infrastructure.Repository;
using RentalsProMobileV9.Infrastructure.Repository.Interface;
using RentalsProMobileV9.Infrastructure.Services.Interfaces;

namespace RentalsProMobileV9.Infrastructure.Services
{
    //public class IdentityService : IIdentityService
    //{
    //    public IRentalsProRepository _Repository { get; }

    //    public IdentityService()
    //    {
    //        _Repository = new RentalsProRepository();
    //    }

    //    public async Task<bool> SignInAsync(ValidUserParameters parameters)
    //    {
    //        var user = (await _Repository.PostForValidUserAsync(parameters)).Content;
    //        if (user != null)
    //        {
    //            ProgramState.AddUser(user);
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }

    //    //public async Task<bool> SignOutAsync()
    //    //{

    //    //}

    //    public UserDTO GetUserInfoAsync()
    //    {
    //        return ProgramState.User;
    //    }
    //}
}
