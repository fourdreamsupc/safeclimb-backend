using Go2Climb.API.HiredServices.Domain.Models;
using Go2Climb.API.Shared.Domain.Services.Communication;

namespace Go2Climb.API.HiredServices.Domain.Services.Communication
{
    public class HideServiceResponse : BaseResponse<HiredService>
    {
        public HideServiceResponse(string message) : base(message) {}

        public HideServiceResponse(HiredService resource) : base(resource) {}
    }
}