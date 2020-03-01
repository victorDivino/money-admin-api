using System;

namespace MoneyAdmin.Domain.Models
{
    public sealed class IncomePayment : Payment
    {
        public Guid IncomeId { get; private set; }
        public Expense Income { get; private set; }

        public IncomePayment(decimal amount, DateTime date)
            : base(amount, date)
        {
        }
    }
}
