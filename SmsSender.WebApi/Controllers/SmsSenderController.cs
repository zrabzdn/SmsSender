using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmsSender.BLL.Services;
using SmsSender.Shared.Contracts.DTOs;
using SmsSender.Shared.Contracts.Requests;
using SmsSender.Shared.Contracts.Responses;
using System.Collections.Generic;
using System.Net;

namespace SmsSender.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmsSenderController : DefaultController
    {
        private readonly ILogger<SmsSenderController> _logger;
        private readonly ISmsSenderAuthenticationService _auth;
        private readonly IMapper _mapper;                

        public SmsSenderController(ILogger<SmsSenderController> logger, ISmsSenderAuthenticationService auth, IMapper mapper)
        {
            _logger = logger;
            _auth = auth;
            _mapper = mapper;
        }

        [HttpPost("SendInvites")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        public IActionResult SendInvites([FromBody] SendInvitesRequest request)
        {
            return CallBLAction(() =>
            {
                _auth.SendInvites(_mapper.Map<SendInvitesDto>(request));
                return new ApiResponse<string>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = "All invitations have been sent."
                };
            });
        }
    }
}
