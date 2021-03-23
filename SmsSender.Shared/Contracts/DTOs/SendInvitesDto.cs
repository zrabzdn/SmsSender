using System.Collections.Generic;

namespace SmsSender.Shared.Contracts.DTOs
{
    public class SendInvitesDto
    {
        public string[] PhoneNumbers { get; set; }

        public string Message { get; set; }
    }
}
