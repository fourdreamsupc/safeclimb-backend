using Go2Climb.API.Subscriptions.Domain.Models;
using Go2Climb.API.Subscriptions.Domain.Services.Communication;

namespace Go2Climb.API.Subscriptions.Domain.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task<SubscriptionResponse> GetById(int id);
        Task<SubscriptionResponse> SaveAsync(Subscription subscription);
        Task<SubscriptionResponse> UpdateAsync(int id, Subscription subscription);
        Task<SubscriptionResponse> DeleteAsync(int id);
    }
}