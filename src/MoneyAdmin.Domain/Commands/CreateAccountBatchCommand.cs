using System.IO;
using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.Validators;

namespace MoneyAdmin.Domain.Commands
{
    public class CreateAccountBatchCommand : CommandBase
    {
        public CreateAccountBatchCommand(Stream File)
        {
            this.File = File;
        }

        public Stream File { get; private set; }

        public override bool IsValid
        {
            get
            {
                var validation = new CreateAccountBatchCommandValidator().Validate(this);
                return validation.IsValid;
            }
        }
    }
}
