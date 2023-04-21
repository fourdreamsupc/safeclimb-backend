using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Services.Communication;
using Go2Climb.API.HiredServices.Domain.Models;
using Go2Climb.API.HiredServices.Domain.Services.Communication;

namespace Go2Climb.API.HiredServices.Domain.Services
{
    public interface IHiredServiceService
    {
        Task<IEnumerable<HiredService>> ListAsync();
        Task<IEnumerable<HiredService>> FindByAgencyIdAsync(int agencyId);
        Task<IEnumerable<HiredService>> FindByCustomerIdAsync(int customerId);
        Task<IEnumerable<HiredService>> FindByCustomerIdWithServiceInformationAsync(int customerId);
        Task<HideServiceResponse> SaveAsync(HiredService service);
        Task<HideServiceResponse> FindById(int id);
        Task<HideServiceResponse> UpdateAsync(int id, HiredService service);
        Task<HideServiceResponse> DeleteAsync(int id);
    }
}