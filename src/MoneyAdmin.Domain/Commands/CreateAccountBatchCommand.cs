using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.Validators;
using System.IO;

namespace MoneyAdmin.Domain.Commands
{
    public class CreateAccountBatchCommand : CommandBase
    {
        public CreateAccountBatchCommand(Stream File)
        {
            this.File = File;
        }

        public Stream File { get; private set; }

        public bool IsValid
        {
            get
            {
                var validation = new CreateAccountBatchCommandValidator().Validate(this);
                return validation.IsValid;
            }
        }
    }
}
