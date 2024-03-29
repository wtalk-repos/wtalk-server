﻿using AutoMapper;
using wtalk.Cqrs.Commands;
using Wtalk.Api.Cqrs.Commands.User;
using Wtalk.Core.Entities;
using Wtalk.Core.Responses.Friend;

namespace Wtalk.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, FriendResponse>();
            #endregion
            #region Account
            CreateMap<SignUpUserCommand, User>();
            #endregion
        }
    }
}
