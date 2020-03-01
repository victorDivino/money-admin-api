using System;
using MoneyAdmin.Domain.Core.Enums;

namespace MoneyAdmin.Domain.Models
{
    public sealed class ExpensePayment : Payment
    {
        public Guid ExpenseId { get; private set; }
        public Expense Expense { get; private set; }

        public ExpensePayment(decimal amount, DateTime date, PaymentStatus status = PaymentStatus.ToPay)
            : base(amount, date, status)
        {
        }
    }
}
