using System;

namespace MoneyAdmin.Domain.Models
{
    public sealed class IncomePayment : Payment
    {
        public Guid IncomeId { get; private set; }
        public Expense Income { get; private set; }

        public IncomePayment(decimal value, DateTime dueDate, DateTime? payDay = null)
            : base(value, dueDate, payDay)
        {
        }

    }
}
