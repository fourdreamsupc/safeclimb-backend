using Go2Climb.API.Reviews.Domain.Models;
using Go2Climb.API.Shared.Domain.Services.Communication;

namespace Go2Climb.API.Reviews.Domain.Services.Communication
{
    public class ServiceReviewResponse : BaseResponse<ServiceReview>
    {
        //UNHAPPY
        public ServiceReviewResponse(string message) : base(message)
        {
        }
        //HAPPY
        public ServiceReviewResponse(ServiceReview resource) : base(resource)
        {
        }
    }
}