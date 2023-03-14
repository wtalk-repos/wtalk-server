using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using wtalk.Cqrs.Commands.FriendRequest;
using Wtalk.Api.Errors;
using Wtalk.Core.Interfaces;
using Wtalk.Core.Responses.FriendRequest;
using Wtalk.Core.Specifications.FriendRequest;
using Wtalk.Infrastracture.Service;

namespace wtalk.Handlers.FriendRequest
{
    public class CreateFriendRequestHandler : IRequestHandler<CreateFriendRequestCommand, CreateFriendRequestResponse>
    {
        private readonly IGenericRepository<Wtalk.Core.Entities.FriendRequest> _genericRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public CreateFriendRequestHandler(
            IGenericRepository<Wtalk.Core.Entities.FriendRequest> genericRepository,
            IHttpContextAccessor httpContextAccessor,
            ITokenService tokenService,
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<CreateFriendRequestResponse> Handle(CreateFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0];
            var userId = _tokenService.ReadUserId(token);

            // Checking if already exis
            var found = await _genericRepository.GetEntityWithSpec(new FriendRequestSpecification(userId, request.FriendId));
            if (found != null) throw new BadRequestException("400", "Friend request already exist");

            var friendRequest = _mapper.Map<Wtalk.Core.Entities.FriendRequest>(request);
            friendRequest.InitiatorId = userId;

            _genericRepository.Add(friendRequest);

            return new CreateFriendRequestResponse
            {
                Id = friendRequest.Id
            };

        }
    }
}
