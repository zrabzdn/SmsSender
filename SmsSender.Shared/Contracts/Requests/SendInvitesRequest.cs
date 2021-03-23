using System.Collections.Generic;

namespace SmsSender.Shared.Contracts.Requests
{
    public class SendInvitesRequest
    {
        public List<string> PhoneNumbers { get; set; }

        public string Message { get; set; }
    }
}
