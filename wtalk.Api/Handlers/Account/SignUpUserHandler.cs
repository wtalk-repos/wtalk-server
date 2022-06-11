using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using wtalk.Cqrs.Commands;
using Wtalk.Api.Cqrs.Commands.User;
using Wtalk.Core.Interfaces;

namespace Wtalk.Handlers.Account
{
    public class SignUpUserHandler : IRequestHandler<SignUpUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;
        private readonly IDataProtection _dataProtection;
        private readonly IConfiguration _config;

        public SignUpUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IConfiguration config, ITokenService tokenService,IDataProtection dataProtection)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _tokenService = tokenService;
            _dataProtection = dataProtection;
        }

        public async Task<Unit> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {

            var user = _mapper.Map<SignUpUserCommand, Core.Entities.User>(request);
            user.Salt = _dataProtection.GenerateSalt();
            user.Password = _dataProtection.Hash(request.Password, user.Salt);
            if (user == null) user = _mapper.Map<SignUpUserCommand, Core.Entities.User>(request);
        
            if (user.Id == 0) _unitOfWork.Repository<Core.Entities.User>()?.Add(user);

            await _unitOfWork.Complete();

            return new Unit();
        }
    }
}

