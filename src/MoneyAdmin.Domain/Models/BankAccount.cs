using System;
using System.Collections.Generic;
using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.Core.Enums;
using MoneyAdmin.Domain.Core.Models;
using MoneyAdmin.Domain.Models;

namespace MoneyAdmin.Domain
{
    public sealed class BankAccount : Entity
    {
        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public ICollection<ExpensePayment> Debts { get; private set; }
        public ICollection<IncomePayment> Credits { get; private set; }

        public BankAccount(string name, decimal initialValue = 0)
        {
            Id = Guid.NewGuid();
            Name = name;
            Balance = initialValue;
            Debts = new List<ExpensePayment>();
            Credits = new List<IncomePayment>();
        }

        private BankAccount() { }

        public CommandResult AddTransaction(IncomePayment credit)
        {
            if (credit.PaymentStatus == PaymentStatus.Paid)
                Balance += credit.Value;

            Credits.Add(credit);

            return CommandResult.Success();
        }

        public CommandResult AddTransaction(ExpensePayment debit)
        {
            if (debit.PaymentStatus == PaymentStatus.Paid)
            {
                var balance = Balance -= debit.Value;

                if (balance < 0)
                    return new Exception("Insufficient balance!");

                Balance = balance;
            }

            Debts.Add(debit);
            return CommandResult.Success();
        }
    }
}
