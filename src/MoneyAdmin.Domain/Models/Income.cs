using System;
using System.Collections.Generic;

namespace MoneyAdmin.Domain.Models
{
    public sealed class Income : BaseAccount
    {
        public Guid IncomeCategoryId { get; private set; }
        public IncomeCategory Category { get; private set; }
        public ICollection<IncomePayment> Payments { get; private set; }

        public Income(string name, decimal amount, string details, short payDay, Guid bankAccountId)
            : base(name, amount, details, payDay, bankAccountId)
        {
        }
    }
}
