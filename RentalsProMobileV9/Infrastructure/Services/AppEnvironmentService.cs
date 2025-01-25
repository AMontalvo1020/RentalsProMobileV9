using RentalsProMobileV9.Infrastructure.Services.Interfaces;

namespace RentalsProMobileV9.Infrastructure.Services
{
    public class AppEnvironmentService : IAppEnvironmentService
    {
        private readonly IIdentityService _identityService;
        public IIdentityService IdentityService { get; private set; }

        public AppEnvironmentService(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public void UpdateDependencies()
        {
            IdentityService = _identityService;
        }
    }
}
