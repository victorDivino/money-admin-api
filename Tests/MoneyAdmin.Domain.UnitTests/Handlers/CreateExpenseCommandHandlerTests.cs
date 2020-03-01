using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Interfaces;

namespace MoneyAdmin.Domain.Handlers
{
    [TestClass]
    public sealed class CreateExpenseCommandHandlerTests
    {
        private readonly CreateExpenseCommandHandler _sut;
        private readonly IAccountRepository _accountRepository;
        public CreateExpenseCommandHandlerTests()
        {
            _sut = new CreateExpenseCommandHandler();

        }

        [TestMethod]
        public async Task CreateASimpleExpensePaidSouldToDebitFromBanktAccount()
        {
            //Arrange
            var bankAccount = new BankAccount("Nuconta", 100);
            var command = new CreateExpenseCommand
            {
                BankAccountId = bankAccount.Id,
                Name = "Lunch",
                Value = 50,
                IsPaid = true,
                Detail = "Test"
            };

            //Action
            await _sut.Handle(command, new CancellationToken());

            //Assert
            bankAccount.Balance.Should().Be(50);
        }
    }
}
