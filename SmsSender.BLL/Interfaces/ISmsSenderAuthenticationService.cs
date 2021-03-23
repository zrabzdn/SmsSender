using SmsSender.Shared.Contracts.DTOs;

namespace SmsSender.BLL.Services
{
    public interface ISmsSenderAuthenticationService
    {
        void SendInvites(SendInvitesDto dto);
    }
}
