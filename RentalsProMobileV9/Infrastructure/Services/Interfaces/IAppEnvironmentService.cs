using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalsProMobileV9.Infrastructure.Services.Interfaces
{
    public interface IAppEnvironmentService
    {
        IIdentityService IdentityService { get; }
    }
}
