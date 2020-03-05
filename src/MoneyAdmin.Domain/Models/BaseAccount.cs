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
        public DateTime DueDate { get; private set; }
        public AccountKind Kind { get; private set; }
        public BankAccount BankAccount { get; private set; }

        protected BaseAccount()
        {
        }

        protected BaseAccount(Guid bankAccountId, string name, decimal amount, string details, DateTime dueDate, AccountKind kind = AccountKind.Simple)
        {
            BankAccountId = bankAccountId;
            Name = name;
            Amount = amount;
            Details = details;
            DueDate = dueDate;
            Kind = kind;
        }
    }
}
