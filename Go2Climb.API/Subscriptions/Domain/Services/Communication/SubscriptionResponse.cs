using Go2Climb.API.Shared.Domain.Services.Communication;
using Go2Climb.API.Subscriptions.Domain.Models;

namespace Go2Climb.API.Subscriptions.Domain.Services.Communication
{
    public class SubscriptionResponse : BaseResponse<Subscription>
    {
        //UNHAPPY
        public SubscriptionResponse(string message) : base(message)
        {
            
        }
        //HAPPY
        public SubscriptionResponse(Subscription resource) : base(resource)
        {
            
        }
    }
}