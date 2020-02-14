using FluentValidation;
using MoneyAdmin.Domain.Commands;

namespace MoneyAdmin.Domain.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("is required");
            RuleFor(x => x.InitialValue).GreaterThanOrEqualTo(0);
        }
    }
}
