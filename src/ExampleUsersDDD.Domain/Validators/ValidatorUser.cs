
using FluentValidation;

using ExampleUsersDDD.Common.Validators;

using ExampleUsersDDD.Domain.Entities;

namespace ExampleUsersDDD.Domain.Validators
{
    public class ValidatorUser: AbstractValidatorBase<User> {
        
        public ValidatorUser()
        {
            RuleFor(user => user.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email address is required");

            RuleFor(user => user.Email)
                .EmailAddress()
                .WithMessage("A valid email is required");
        }

    }
}
