using Go2Climb.API.Services.Domain.Models;
using Go2Climb.API.Shared.Domain.Services.Communication;

namespace Go2Climb.API.Services.Domain.Services.Communication
{
    public class ServiceResponse : BaseResponse<Service>
    {
        //UNHAPPY
        public ServiceResponse(string message) : base(message)
        {
        }
        //HAPPY
        public ServiceResponse(Service resource) : base(resource)
        {
        }
    }
}