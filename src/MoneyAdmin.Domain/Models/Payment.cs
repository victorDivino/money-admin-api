using System;
using MoneyAdmin.Domain.Core.Enums;
using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain.Models
{
    public abstract class Payment : Entity
    {
        public decimal Value { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? PayDay { get; private set; }
        public PaymentStatus Status { get; private set; }

        protected Payment() { }

        public Payment(decimal value, DateTime dueDate, DateTime? payDay = null)
        {
            Id = Guid.NewGuid();
            Value = value;
            DueDate = dueDate;
            PayDay = payDay;
            Status = PayDay is null ? PaymentStatus.ToPay : PaymentStatus.Paid;
        }
    }
}