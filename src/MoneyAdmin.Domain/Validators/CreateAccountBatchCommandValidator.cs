using FluentValidation;
using MoneyAdmin.Domain.Commands;

namespace MoneyAdmin.Domain.Validators
{
    class CreateAccountBatchCommandValidator : AbstractValidator<ImportBankAccountCommand>
    {
        public CreateAccountBatchCommandValidator()
        {
            When(c => c.File != null, () =>
            {
                RuleFor(c => c.File.Length)
                    .NotEqual(0).WithMessage("The file must not be empty");
            });
        }
    }
}
