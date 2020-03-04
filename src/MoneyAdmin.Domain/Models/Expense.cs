using System;
using System.Collections.Generic;
using MoneyAdmin.Domain.Core.Enums;

namespace MoneyAdmin.Domain.Models
{
    public sealed class Expense : BaseAccount
    {
        public Guid CategoryId { get; private set; }
        public ExpenseCategory Category { get; private set; }
        public ICollection<ExpensePayment> Payments { get; private set; }

        public Expense(Guid bankAccountId, string name, decimal amount, string details, DateTime dueDate, AccountKind kind = AccountKind.Simple, params ExpensePayment[] payments)
            : base(bankAccountId, name, amount, details, dueDate, kind)
        {
            Payments = payments;
        }
    }
}
