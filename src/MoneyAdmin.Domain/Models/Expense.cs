using System;
using System.Collections.Generic;

namespace MoneyAdmin.Domain.Models
{
    public sealed class Expense : BaseAccount
    {
        public Guid CategoryId { get; private set; }
        public ExpenseCategory Category { get; private set; }
        public ICollection<ExpensePayment> Payments { get; private set; }

        public Expense(string name, decimal amount, string details, short payDay, Guid bankAccountId)
            : base(name, amount, details, payDay, bankAccountId)
        {
        }
    }
}
