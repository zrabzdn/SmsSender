using SmsSender.Shared.Contracts.DTOs;

namespace SmsSender.BLL.Interfaces
{
    public interface ISendInvitesRequestValidationService<T> : IRequestValidationService<T>
    {
        void ValidateSendInvitesAbility(SendInvitesDto dto, int currentInvitationsNumber);
    }
}
