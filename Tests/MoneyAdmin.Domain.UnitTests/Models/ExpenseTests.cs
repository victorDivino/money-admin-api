using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyAdmin.Domain.Models
{
    [TestClass]
    public sealed class ExpenseTests
    {
        [TestMethod]
        public void ToPayASimpleExpenseShouldToDebtTheBankAccount()
        {
            var banckAccount = new BankAccount("Nubank", 100);
            var expense = new Expense("Enel", 50, "", 5, banckAccount);
            var payment = new Payment(20, DateTime.Now);
            expense.ToPay(payment);
            banckAccount.Balance.Should().Be(50);
        }
    }
}
