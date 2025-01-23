using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalsProAPIV8.Client.DataTransferObjects;

namespace RentalsProMobileV9.Services.Services.Interfaces
{
    public interface IPropertyService
    {
        IEnumerable<PropertyDTO> Properties { get; set; }
        Task<List<PropertyDTO>> GetPropertiesAsync();
        Task ClearPropertiesAsync();
    }
}
