using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyAdmin.Domain.Models
{
    [TestClass]
    public sealed class ExpenseTests
    {
        [TestMethod]
        public void Test()
        {
            var account = new Account("Nubank", 100);
            var expense = new Expense("Luz", "", DateTime.Now, null, account);
            var payment = new Payment(50, DateTime.Now, true, expense);

            account.Amount.Should().Be(50);
        }
    }
}
