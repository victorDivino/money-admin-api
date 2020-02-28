using System;
using MoneyAdmin.Domain.Core.Models;

namespace MoneyAdmin.Domain.Models
{
    public sealed class Payment : Entity
    {
        public decimal Value { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public bool IsPaid { get; private set; }
        public Transaction Transaction { get; private set; }

        public Payment(decimal value, DateTime paymentDate, bool isPaid, Transaction transaction)
        {
            Value = value;
            PaymentDate = paymentDate;
            Transaction = transaction;
            IsPaid = false;

            if (isPaid)
                ToPay();
        }

        public void ToPay()
        {
            if (IsPaid)
                return;

            IsPaid = true;
            Transaction.SetPayment(Value);
        }
    }
}