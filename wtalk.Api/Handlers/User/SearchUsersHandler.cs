using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using wtalk.Cqrs.Queries.User;
using Wtalk.Core.Entities;
using Wtalk.Core.Interfaces;
using Wtalk.Core.Responses.User;
using Wtalk.Core.Specifications.User;

namespace wtalk.Handlers.User
{
    public class SearchUsersHandler : IRequestHandler<SearchUsersQuery, SearchUserResultListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Wtalk.Core.Entities.User> _genericRepository;
        public SearchUsersHandler(IMapper mapper, IGenericRepository<Wtalk.Core.Entities.User> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<SearchUserResultListResponse> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
        {
            var userSpecification = new SearchUserSpecification(request.SpecParams);
            var users = await _genericRepository.ListAsync(userSpecification);
            var usersResponse = _mapper.Map<List<SearchUserResultResponse>>(users);
            var count = await _genericRepository.CountAsync(userSpecification);
            return new SearchUserResultListResponse
            {
                Pagination = new Wtalk.Core.Helpers.Pagination<SearchUserResultResponse>(request.SpecParams.PageIndex, request.SpecParams.PageSize, count, usersResponse)
            };
        }
    }
}
