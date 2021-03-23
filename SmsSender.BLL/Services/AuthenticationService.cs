using SmsSender.BLL.Interfaces;
using SmsSender.Shared.Contracts.DTOs;
using SmsSender.Shared.Interfaces;

namespace SmsSender.BLL.Services
{
    public class AuthenticationService : ISmsSenderAuthenticationService
    {
        private readonly IInvitationRepository _invitationRepository;
        private readonly ISendInvitesRequestValidationService<SendInvitesDto> _requestValidationService;
        private readonly ISmsService _smsService;

        public AuthenticationService(IInvitationRepository invitationRepository,
            ISendInvitesRequestValidationService<SendInvitesDto> requestValidationService,
            ISmsService smsService)
        {
            _invitationRepository = invitationRepository;
            _requestValidationService = requestValidationService;
            _smsService = smsService;
        }

        public void SendInvites(SendInvitesDto dto)
        {
            _requestValidationService.ValidateRequest(dto);

            _requestValidationService.ValidateSendInvitesAbility(dto, _invitationRepository.GetCountInvitations(4));

            _invitationRepository.SetInvitations(7, dto.PhoneNumbers);

            foreach (var phoneNumber in dto.PhoneNumbers)
            {
                _smsService.Send(phoneNumber, dto.Message);
            }            
        }
    }
}
