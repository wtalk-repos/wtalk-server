using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wtalk.Api.Cqrs.Commands.User;
using Wtalk.Core.Interfaces;

namespace Wtalk.Handlers.User
{
    public class SignUpUserHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;
        private readonly IDataProtection _dataProtection;
        private readonly IConfiguration _config;

        public SignUpUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IConfiguration config, ITokenService tokenService, IDataProtection dataProtection)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _tokenService = tokenService;
            _dataProtection = dataProtection;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _unitOfWork.UserRepository.FindUserByEmailAsync(request.Email);
            if (user == null) user = _mapper.Map<CreateUserCommand, Core.Entities.User>(request);
        
            if (user.Id == 0) _unitOfWork.Repository<Core.Entities.User>()?.Add(user);

            await _unitOfWork.Complete();

            return new Unit();
        }
    }
}

