using FluentValidation;
using MediatR;
using Wtalk.Core.Responses.Account;

namespace wtalk.Cqrs.Commands.Account
{
    public class SignInUserCommand : IRequest<SignInResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class SignInCommandValidator : AbstractValidator<SignInUserCommand>
    {
        public SignInCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;
            //RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();

        }
    }
}
