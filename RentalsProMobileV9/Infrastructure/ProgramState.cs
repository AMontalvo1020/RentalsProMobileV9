using RentalsProAPIV8.Client.API;
using RentalsProAPIV8.Client.DataTransferObjects;

namespace RentalsProMobileV9.Infrastructure
{
    public class ProgramState
    {
        public static UserDTO User { get; set; }
        public static ClientManager Manager { get; set; }
        public static void SetupApiManager() => Manager = new ClientManager("http://10.0.2.2:52075", new ApiManager());
        public static void AddUser(UserDTO user) => User = user;
    }
}
