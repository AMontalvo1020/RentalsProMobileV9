using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalsProMobileV9.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        public string DefaultEndpoint
        {
            get => Preferences.Get(nameof(DefaultEndpoint), string.Empty);
            set => Preferences.Set(nameof(DefaultEndpoint), value);
        }
    }
}
