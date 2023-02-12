using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using wtalk.Cqrs.Queries.Message;
using Wtalk.Core.Helpers;
using Wtalk.Core.Interfaces.Repositories;
using Wtalk.Core.Responses.Message;
using Wtalk.Core.Specifications.Message;

namespace wtalk.Handlers.Message
{
    public class GetMessageListHandler : IRequestHandler<GetMessageListQuery, GetMessageListResponse>
    {
        private readonly IReadGenericRepository<Wtalk.Core.Entities.Message> _readGenericRepository;
        private readonly IMapper _mapper;
        public GetMessageListHandler(
            IReadGenericRepository<Wtalk.Core.Entities.Message> readGenericRepository, IMapper mapper)
        {
            _readGenericRepository = readGenericRepository;
            _mapper = mapper;
        }
        public async Task<GetMessageListResponse> Handle(GetMessageListQuery request, CancellationToken cancellationToken)
        {
            var spec = new MessageSpecification(request.MessageSpecParams);
            var messages = await _readGenericRepository.ListAsync(spec);
            var totalItems = await _readGenericRepository.CountAsync(spec);
            var messageResponses = _mapper.Map<IReadOnlyList<MessageResponse>>(messages);

            return new GetMessageListResponse
            {
                Pagination = new Pagination<MessageResponse>(request.MessageSpecParams.PageIndex, request.MessageSpecParams.PageSize, totalItems, messageResponses)
            };
        }
    }
}
