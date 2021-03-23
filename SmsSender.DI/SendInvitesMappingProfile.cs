using AutoMapper;
using SmsSender.Shared.Contracts.DTOs;
using SmsSender.Shared.Contracts.Requests;

namespace SmsSender.DI
{
    public class SendInvitesMappingProfile : Profile
    {
        public SendInvitesMappingProfile()
        {
            CreateMap<SendInvitesRequest, SendInvitesDto>();
        }
    }
}
