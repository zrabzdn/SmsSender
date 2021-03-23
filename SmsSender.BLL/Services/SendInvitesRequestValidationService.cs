using SmsSender.BLL.Exceptions;
using SmsSender.BLL.Interfaces;
using SmsSender.Shared.Contracts.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace SmsSender.BLL.Services
{
    public class SendInvitesRequestValidationService : ISendInvitesRequestValidationService<SendInvitesDto>
    {
        public void ValidateRequest(SendInvitesDto dto)
        {
            if (dto.PhoneNumbers == null || !dto.PhoneNumbers.Any() || dto.PhoneNumbers.Any(p => string.IsNullOrWhiteSpace(p)))
            {
                throw new ValidationException(HttpStatusCode.Unauthorized,
                    "PHONE_NUMBERS_EMPTY: Phone_numbers is missing.");
            }

            if (dto.PhoneNumbers.Length > 16)
            {
                throw new ValidationException(HttpStatusCode.PaymentRequired,
                    "PHONE_NUMBERS_INVALID: Too much phone numbers, should be less or equal to 16 per request.");
            }

            if (new HashSet<string>(dto.PhoneNumbers).ToList().Count < dto.PhoneNumbers.Length)
            {
                throw new ValidationException(HttpStatusCode.Forbidden, "PHONE_NUMBERS_INVALID: Duplicate numbers detected.");
            }            

            if (dto.PhoneNumbers.Where(pn => Regex.IsMatch(pn, @"^((7)+([0-9]){10})$")).ToList().Count !=
                dto.PhoneNumbers.Length)
            {
                throw new ValidationException(HttpStatusCode.BadRequest,
                    "PHONE_NUMBERS_INVALID: One or several phone numbers do not match with international format.");
            }

            if (string.IsNullOrWhiteSpace(dto.Message))
            {
                throw new ValidationException(HttpStatusCode.MethodNotAllowed, "MESSAGE_EMPTY: Invite message is missing.");
            }

            if (!Regex.IsMatch(dto.Message,
                @"^[@£$¥èéùìòÇØøÅå_ÆæßÉ!""#%&'()*+,-./0123456789:;<=>? ¡ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÑÜ§¿abcdefghijklmnopqrstuvwxyzäöñüà^{}\[~]|€]+$")
            )
            {
                throw new ValidationException(HttpStatusCode.NotAcceptable,
                    "MESSAGE_INVALID: Invite message should contain only characters in 7-bit GSM encoding or Cyrillic letters as well.");
            }

            if (!Regex.IsMatch(dto.Message, @"\P{IsBasicLatin}") && dto.Message.Length > 160 ||
                Regex.IsMatch(dto.Message, @"\p{IsBasicLatin}") && dto.Message.Length > 128)
            {
                throw new ValidationException(HttpStatusCode.ProxyAuthenticationRequired,
                    "MESSAGE_INVALID: Invite message too long, should be less or equal to 128 characters of 7-bit GSM charset.");
            }
        }

        public void ValidateSendInvitesAbility(SendInvitesDto dto, int currentInvitationsNumber)
        {
            if (currentInvitationsNumber + dto.PhoneNumbers.Length > 128)
            {
                throw new ValidationException(HttpStatusCode.Forbidden,
                    "PHONE_NUMBERS_INVALID: Too much phone numbers, should be less or equal to 128 per day.");
            }
        }
    }
}
