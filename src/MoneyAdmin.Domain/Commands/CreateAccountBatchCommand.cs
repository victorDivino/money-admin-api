using MoneyAdmin.Domain.Core.Commands;
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
    }
}
