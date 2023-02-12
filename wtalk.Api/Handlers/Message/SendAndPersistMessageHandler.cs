﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using wtalk.Cqrs.Commands.Message;
using wtalk.HubConfig;
using Wtalk.Core.Entities;
using Wtalk.Core.Helpers;
using Wtalk.Core.Interfaces;
using Wtalk.Core.Responses.Message;
using Wtalk.Infrastracture.Data;

namespace wtalk.Handlers.Message
{
    public class SendAndPersistMessageHandler : IRequestHandler<SendAndPersistMessageCommand, CreateMessageResponse>
    {
        private readonly IHubContext<ChatHub> _chatHubContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SendAndPersistMessageHandler(
            IHubContext<ChatHub> chatHubContext,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _chatHubContext = chatHubContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<CreateMessageResponse> Handle(SendAndPersistMessageCommand request, CancellationToken cancellationToken)
        {
            
            var message = _mapper.Map<Wtalk.Core.Entities.Message>(request);
            message.SenderId = _httpContextAccessor.HttpContext.User.GetUserId();

            //send 
            await _chatHubContext.Clients.Group("user-" + request.ReceiverId).SendAsync("newMessage", message);

            //persist
            _unitOfWork.Repository<Wtalk.Core.Entities.Message>()?.Add(message);
            await _unitOfWork.Complete();

            return new CreateMessageResponse
            {
                Id = message.Id
            };
        }
    }
}