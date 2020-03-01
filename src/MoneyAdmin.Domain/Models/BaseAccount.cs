using System;
using MoneyAdmin.Domain.Core.Enums;
using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain.Models
{
    public abstract class BaseAccount : Entity
    {
        public Guid BankAccountId { get; private set; }
        public string Name { get; private set; }
        public decimal Amount { get; set; }
        public string Details { get; private set; }
        public short PayDay { get; private set; }
        public AccountKind Kind { get; private set; }
        public BankAccount BankAccount { get; private set; }

        protected BaseAccount(string name, decimal amount, string details, short payDay, Guid bankAccountId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Amount = amount;
            Details = details;
            PayDay = payDay;
            BankAccountId = bankAccountId;
        }
    }
}
