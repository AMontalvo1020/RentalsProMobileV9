using RentalsProAPIV8.Client.API;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProAPIV8.Client.Parameters;

namespace RentalsProMobileV9.Infrastructure.Repository.Interface
{
    public interface IRentalsProRepository
    {
        Task<ApiResponse<UserDTO>> PostForValidUserAsync(ValidUserParameters parameters);
        Task<ApiResponse<List<PropertyDTO>>> PostForPropertiesAsync(PostForPropertiesParameters parameters);
        Task<ApiResponse<PropertyDTO>> GetPropertyAsync(int propertyID);
        Task<ApiResponse<List<TypeDTO>>> GetPropertyTypesAsync();
        Task<ApiResponse<List<StatusDTO>>> GetStatusesAsync();
        Task<ApiResponse<List<StatusDTO>>> GetPaymentStatusesAsync();
        Task<ApiResponse<string>> PatchPropertyStatusAsync(int propertyID, int statusID);
        Task<ApiResponse<string>> PatchPropertyPaymentStatusAsync(int propertyID, int statusID);
        Task<ApiResponse<LeaseDTO>> PostForLeaseAsync(PostForLeaseParameters parameters);
        Task<ApiResponse<string>> PostLeaseAsync(LeaseDTO leaseDTO);
        Task<ApiResponse<List<UnitDTO>>> GetUnitsAsync(int PropertyID, bool Active);
        Task<ApiResponse<UnitDTO>> GetUnitAsync(int UnitID);
    }
}
