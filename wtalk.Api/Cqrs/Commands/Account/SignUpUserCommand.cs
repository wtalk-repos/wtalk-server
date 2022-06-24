using FluentValidation;
using MediatR;
using Wtalk.Core.Enums;

namespace wtalk.Cqrs.Commands
{
    public class SignUpUserCommand : IRequest<Unit>
    {
        public UserType UserType { get; set; } = UserType.User;
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class SignUpUserCommandValidator : AbstractValidator<SignUpUserCommand>
    {
        public SignUpUserCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.FirstName).NotEmpty()
                .Length(0, 100).WithMessage("First name should have 100 chars at most.");

            RuleFor(x => x.LastName).NotEmpty()
                .Length(0, 100).WithMessage("Last name should have 100 chars at most.");

            RuleFor(x => x.Email).NotEmpty()
                .Length(0, 100).WithMessage("Email should have 100 chars at most.")
                .EmailAddress().WithMessage("Not valid format.");
        }
    }
}
