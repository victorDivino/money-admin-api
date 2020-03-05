using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.Validators;

namespace MoneyAdmin.Domain.Commands
{
    public class CreateBankAccountCommand : CommandBase
    {
        public string Name { get; set; }

        public decimal InitialValue { get; set; }

        public override bool IsValid
        {
            get
            {
                var validator = new CreateAccountCommandValidator();
                var validation = validator.Validate(this);
                return validation.IsValid;
            }
        }
    }
}
