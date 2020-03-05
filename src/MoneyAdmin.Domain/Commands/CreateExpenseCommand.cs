using System;
using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.Core.Enums;

namespace MoneyAdmin.Domain.Commands
{
    public sealed class CreateExpenseCommand : CommandBase
    {
        public Guid BankAccountId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }
        public AccountKind AccountKind { get; set; }
        public DateTime? PayDay { get; set; }
        public string Detail { get; set; }

        public override bool IsValid => throw new NotImplementedException();
    }
}
