using System;
using System.Collections.Generic;
using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.Core.Models;
using MoneyAdmin.Domain.Models;
using static MoneyAdmin.Domain.Core.Enums.PaymentStatus;

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

        public CommandResult AddCredit(IncomePayment incomePayment)
        {
            if (incomePayment.Status == Paid)
                Balance += incomePayment.Value;

            Credits.Add(incomePayment);

            return CommandResult.Success();
        }

        public CommandResult AddDebit(ExpensePayment expensePayment)
        {
            if (expensePayment.Status == Paid)
            {
                var balance = Balance -= expensePayment.Value;

                if (balance < 0)
                    return new Exception("Insufficient balance!");

                Balance = balance;
            }

            Debts.Add(expensePayment);
            return CommandResult.Success();
        }
    }
}
