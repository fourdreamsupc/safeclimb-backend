using Go2Climb.API.Activities.Domain.Models;
using Go2Climb.API.Shared.Domain.Services.Communication;

namespace Go2Climb.API.Activities.Domain.Services.Communication
{
    public class ActivityResponse : BaseResponse<Activity>
    {
        //UNHAPPY
        public ActivityResponse(string message) : base(message)
        {
            
        }
        //HAPPY
        public ActivityResponse(Activity resource) : base(resource)
        {
            
        }
    }
}