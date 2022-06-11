using AutoMapper;
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
        }
    }
}
