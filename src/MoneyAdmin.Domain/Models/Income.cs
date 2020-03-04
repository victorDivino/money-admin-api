using System;
using System.Collections.Generic;
using MoneyAdmin.Domain.Core.Enums;

namespace MoneyAdmin.Domain.Models
{
    public sealed class Income : BaseAccount
    {
        public Guid IncomeCategoryId { get; private set; }
        public IncomeCategory Category { get; private set; }
        public ICollection<IncomePayment> Payments { get; private set; }

        public Income(Guid bankAccountId, string name, decimal amount, string details, DateTime dueDate, AccountKind kind = AccountKind.Simple, params IncomePayment[] payments)
            : base(bankAccountId, name, amount, details, dueDate, kind)
        {
            Payments = payments;
        }
    }
}
