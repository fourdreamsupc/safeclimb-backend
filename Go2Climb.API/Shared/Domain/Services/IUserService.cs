using Go2Climb.API.Security.Domain.Services.Communication;

namespace Go2Climb.API.Shared.Domain.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    }
}