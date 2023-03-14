using MediatR;
using Wtalk.Core.Responses.User;
using Wtalk.Core.Specifications.User;

namespace wtalk.Cqrs.Queries.User
{
    public class SearchUsersQuery:IRequest<SearchUserResultListResponse>
    {
        public UserSpecParams SpecParams{ get; set; }
    }
}
