﻿using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShgEcom.Application.Authentication.Commands.Register;
using ShgEcom.Application.Authentication.Common;
using ShgEcom.Application.Authentication.Queries.Login;
using ShgEcom.Contracts.Authentication;

namespace ShgEcom.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController(ISender mediator, IMapper _mapper) : ApiController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var commond = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await mediator.Send(commond);

            return authResult.Match(authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)), Problem);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            ErrorOr<AuthenticationResult> authResult = await mediator.Send(query);

            return authResult.Match(authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)), Problem);
        }
    }
}
