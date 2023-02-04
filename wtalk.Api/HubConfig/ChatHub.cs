using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Wtalk.Core.Helpers;
using Wtalk.Core.Interfaces;

namespace wtalk.HubConfig
{
    public class ChatHub : Hub
    {
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatHub(ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            this._tokenService = tokenService;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async override Task OnConnectedAsync()
        {
            var userId = Context.User.GetUserId();
            System.Console.WriteLine(userId);
            await Clients.User(Context.ConnectionId).SendAsync("newMessage", "Welcome");
            await Clients.All.SendAsync("newMessage", "Welcome bla");
            await Groups.AddToGroupAsync(Context.ConnectionId, "user-" + userId);
        }
    }
}
