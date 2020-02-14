using System;
using MoneyAdmin.Domain.Core.Commands;

namespace MoneyAdmin.Domain.Commands
{
    public class CreateAccountCommand : CommandBase
    {
        public CreateAccountCommand()
        {
        }

        public string Name { get; set; }

        public decimal InitialValue { get; set; }
    }
}
