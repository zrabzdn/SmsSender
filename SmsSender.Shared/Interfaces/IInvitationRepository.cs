
using System.Collections.Generic;

namespace SmsSender.Shared.Interfaces
{
    public interface IInvitationRepository
    {
        void SetInvitations(int userId, IEnumerable<string> phones);

        int GetCountInvitations(int apiId);
    }
}
