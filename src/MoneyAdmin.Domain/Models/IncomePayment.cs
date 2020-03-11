using System;

namespace MoneyAdmin.Domain.Models
{
    public sealed class IncomePayment : Payment
    {
        public Guid IncomeId { get; private set; }
        public Income Income { get; private set; }

        private IncomePayment() { }

        public IncomePayment(decimal value, DateTime dueDate, DateTime? payDay = null)
            : base(value, dueDate, payDay)
        {
        }

    }
}
