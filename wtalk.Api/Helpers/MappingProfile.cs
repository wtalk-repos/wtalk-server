using AutoMapper;
using wtalk.Cqrs.Commands;
using Wtalk.Api.Cqrs.Commands.User;
using Wtalk.Core.Entities;

namespace Wtalk.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<CreateUserCommand, User>();
            #endregion
            #region Account
            CreateMap<SignUpUserCommand, User>();
            #endregion
        }
    }
}
