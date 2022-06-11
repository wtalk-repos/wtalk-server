using FluentValidation;
using MediatR;
using Wtalk.Core.Entities;
using Wtalk.Core.Enums;

namespace Wtalk.Api.Cqrs.Commands.User
{
    public class CreateUserCommand: IRequest<Unit>
    {
        public UserType UserType { get; set; } = UserType.Admin;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
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
