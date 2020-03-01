using System;
using MoneyAdmin.Domain.Core.Enums;
using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain.Models
{
    public abstract class Payment : Entity
    {
        public decimal Value { get; private set; }
        public DateTime DueDate { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }

        public Payment(decimal amount, DateTime date, PaymentStatus status = PaymentStatus.ToPay)
        {
            Id = Guid.NewGuid();
            Value = amount;
            DueDate = date;
            PaymentStatus = status;
        }
    }
}