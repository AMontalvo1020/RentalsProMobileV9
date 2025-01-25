using RentalsProAPIV8.Client.API;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProAPIV8.Client.Parameters;
using RentalsProMobileV9.Infrastructure.Repository.Interface;

namespace RentalsProMobileV9.Infrastructure.Repository
{
    public class RentalsProRepository : IRentalsProRepository
    {
        public async Task<ApiResponse<UserDTO>> PostForValidUserAsync(ValidUserParameters parameters) 
            => await ClientManager.PostForValidUserAsync(parameters);

        public async Task<ApiResponse<List<PropertyDTO>>> PostForPropertiesAsync(PostForPropertiesParameters parameters) 
            => await ClientManager.PostForPropertiesAsync(parameters);

        public async Task<ApiResponse<PropertyDTO>> GetPropertyAsync(int propertyID) 
            => await ClientManager.GetPropertyAsync(propertyID);

        public async Task<ApiResponse<List<StatusDTO>>> GetStatusesAsync() 
            => await ClientManager.GetStatusesAsync();

        public async Task<ApiResponse<List<StatusDTO>>> GetPaymentStatusesAsync() 
            => await ClientManager.GetPaymentStatusesAsync();

        public async Task<ApiResponse<List<TypeDTO>>> GetPropertyTypesAsync() 
            => await ClientManager.GetPropertyTypesAsync();

        public async Task<ApiResponse<string>> PatchPropertyStatusAsync(int propertyID, int statusID) 
            => await ClientManager.PatchPropertyStatusAsync(propertyID, statusID);

        public async Task<ApiResponse<string>> PatchPropertyPaymentStatusAsync(int propertyID, int statusID) 
            => await ClientManager.PatchPropertyPaymentStatusAsync(propertyID, statusID);

        public async Task<ApiResponse<LeaseDTO>> PostForLeaseAsync(PostForLeaseParameters parameters) 
            => await ClientManager.PostForLeaseAsync(parameters);

        public async Task<ApiResponse<string>> PostLeaseAsync(LeaseDTO leaseDTO) 
            => await ClientManager.PostLeaseAsync(leaseDTO);

        public async Task<ApiResponse<List<UnitDTO>>> GetUnitsAsync(int PropertyID, bool Active) 
            => await ClientManager.GetUnitsAsync(PropertyID, Active);

        public async Task<ApiResponse<UnitDTO>> GetUnitAsync(int UnitID) 
            => await ClientManager.GetUnitAsync(UnitID);
    }
}
