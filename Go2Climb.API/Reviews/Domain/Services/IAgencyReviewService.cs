using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Services.Communication;
using Go2Climb.API.Reviews.Domain.Models;
using Go2Climb.API.Reviews.Domain.Services.Communication;

namespace Go2Climb.API.Reviews.Domain.Services
{
    public interface IAgencyReviewService
    {
        Task<IEnumerable<AgencyReview>> ListAsync();
        Task<IEnumerable<AgencyReview>> ListByAgencyIdAsync(int agencyId);
        Task<IEnumerable<AgencyReview>> ListByCustomerIdAsync(int customerId);
        Task<AgencyReviewResponse> GetByIdAsync(int id);
        Task<AgencyReviewResponse> SaveAsync(AgencyReview agencyReview);
        Task<AgencyReviewResponse> DeleteAsync(int id);
    }
}