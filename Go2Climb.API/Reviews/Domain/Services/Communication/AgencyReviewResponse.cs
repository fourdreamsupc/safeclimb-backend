using Go2Climb.API.Reviews.Domain.Models;
using Go2Climb.API.Shared.Domain.Services.Communication;

namespace Go2Climb.API.Reviews.Domain.Services.Communication
{
    public class AgencyReviewResponse : BaseResponse<AgencyReview>
    {
        //UNHAPPY
        public AgencyReviewResponse(string message) : base(message)
        {
        }
        //HAPPY
        public AgencyReviewResponse(AgencyReview resource) : base(resource)
        {
        }
    }
}