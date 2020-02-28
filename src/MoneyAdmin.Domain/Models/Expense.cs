using System;

namespace MoneyAdmin.Domain.Models
{
    public sealed class Expense : Transaction
    {
        public Expense(string name, string details, DateTime dueDate, Category category, Account account)
            : base(name, details, dueDate, category, account) { }

        public override void SetPayment(decimal value) =>
            Account.Amount -= value;
    }
}
