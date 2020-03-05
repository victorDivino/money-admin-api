using System;

namespace MoneyAdmin.Domain.Models
{
    public sealed class ExpensePayment : Payment
    {
        public Guid ExpenseId { get; private set; }
        public Expense Expense { get; private set; }

        private ExpensePayment() { }

        public ExpensePayment(decimal value, DateTime dueDate, DateTime? payDay = null)
            : base(value, dueDate, payDay)
        {
        }
    }
}
