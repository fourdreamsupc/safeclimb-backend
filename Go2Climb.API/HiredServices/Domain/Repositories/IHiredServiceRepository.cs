using Go2Climb.API.HiredServices.Domain.Models;

namespace Go2Climb.API.HiredServices.Domain.Repositories
{
    public interface IHiredServiceRepository
    {
        Task<IEnumerable<HiredService>> ListAsync();
        Task AddAsync(HiredService service);
        Task<HiredService> FindByIdAsync(int id);
        Task<IEnumerable<HiredService>> FindByAgencyIdAsync(int agencyId);
        Task<IEnumerable<HiredService>> FindByCustomerIdAsync(int customerId);
        Task<IEnumerable<HiredService>> FindByCustomerIdWithServiceInformationAsync(int customerId);
        void Update(HiredService service);
        void Remove(HiredService service);
    }
}