using FluentValidation;
using MoneyAdmin.Domain.Commands;

namespace MoneyAdmin.Domain.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("The Name is required")
                .NotEmpty().WithMessage("The Name is required")
                .Length(3, 60).WithMessage("The Name must be greater than 2 less than 60");
        }
    }
}
