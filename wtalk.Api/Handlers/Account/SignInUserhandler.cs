using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using wtalk.Cqrs.Commands;
using wtalk.Cqrs.Commands.Account;
using Wtalk.Api.Cqrs.Commands.User;
using Wtalk.Api.Errors;
using Wtalk.Core.Interfaces;
using Wtalk.Core.Responses.Account;

namespace Wtalk.Handlers.Account
{
    public class SingInUserHandler : IRequestHandler<SignInUserCommand, SignInResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;
        private readonly IDataProtection _dataProtection;
        private readonly IConfiguration _config;

        public SingInUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IConfiguration config, ITokenService tokenService,IDataProtection dataProtection)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _tokenService = tokenService;
            _dataProtection = dataProtection;
        }

        public async Task<SignInResponse> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _unitOfWork.UserRepository.FindUserByEmailAsync(request.Email);
            if (user == null) throw new UnauthorizedException("401", "Invalid username or password.");

            var hashedPassword = _dataProtection.Hash(request.Password, user.Salt!);
            if (user.Password != hashedPassword) throw new UnauthorizedException("401", "Invalid username or password.");
        
            return new SignInResponse
            {
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                Token = _tokenService.CreateToken(user.Id, user.Id, user.Email!)
            };
        }
    }
}

