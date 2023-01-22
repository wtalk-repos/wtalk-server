using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wtalk.Cqrs.Queries;
using Wtalk.Core.Responses.Friend;
using Wtalk.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Wtalk.Infrastracture.Service;
using Microsoft.AspNetCore.Http;
using Wtalk.Core.Specifications.User;
using System.Linq;
using Wtalk.Core.Helpers.SpargelTracker.Core.Helpers;
using AutoMapper;
using System.Collections.Generic;
using Wtalk.Infrastracture.Data.Context;
using Microsoft.EntityFrameworkCore;
using Wtalk.Core.Entities;
using Wtalk.Core.Interfaces.Repositories;

namespace wtalk.Handlers.User
{
    public class GetFriendsListHandler : IRequestHandler<GetFriendsListQuery, FriendListResponse>
    {

        private readonly IReadGenericRepository<Wtalk.Core.Entities.User> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly WtalkContext dbReadContext;
        public GetFriendsListHandler(IReadGenericRepository<Wtalk.Core.Entities.User> userRepository, IHttpContextAccessor httpContextAccessor, ITokenService tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _mapper = mapper;
            this.dbReadContext = dbReadContext;
        }
        public async Task<FriendListResponse> Handle(GetFriendsListQuery request, CancellationToken cancellationToken)
        {
     
            var token = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"][0];
            var userId = _tokenService.ReadUserId(token);
            var userSpecification = new UserSpecification(userId);
            var user = await _userRepository.GetEntityWithSpec(userSpecification);
            if (user == null) throw new BadHttpRequestException("User not found");
            var friends = user.UserFriends.Where(e=>e.UserId==userId).Select(e => e.Friend);
            var friendsResponses = _mapper.Map<IReadOnlyList<FriendResponse>>(friends);
            var totalItems = friendsResponses.Count;
            var pagination = new Pagination<FriendResponse>(friendsResponses, request.SpecParams.PageIndex, totalItems, request.SpecParams.PageSize);
            return new FriendListResponse
            {
                Pagination = pagination
            };
        }
    }
}
