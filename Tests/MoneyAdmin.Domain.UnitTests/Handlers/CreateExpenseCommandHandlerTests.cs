using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Interfaces;
using NSubstitute;
using static MoneyAdmin.Domain.Core.Enums.AccountKind;

namespace MoneyAdmin.Domain.Handlers
{
    [TestClass]
    public sealed class CreateExpenseCommandHandlerTests
    {
        private readonly CreateExpenseCommandHandler _sut;
        private readonly IAccountRepository _accountRepository;
        private readonly IExpenseRepository _expenseRepository;
        public CreateExpenseCommandHandlerTests()
        {
            _accountRepository = Substitute.For<IAccountRepository>();
            _expenseRepository = Substitute.For<IExpenseRepository>();

            _sut = new CreateExpenseCommandHandler(_accountRepository, _expenseRepository);
        }

        [TestMethod]
        public async Task CreateASimpleExpenseWithPayDaySouldToDebitFromBankAccount()
        {
            //Arrange
            var bankAccount = new BankAccount("Nuconta", 100);
            _accountRepository.GetById(bankAccount.Id).Returns(bankAccount);

            var command = new CreateExpenseCommand
            {
                BankAccountId = bankAccount.Id,
                Name = "Lunch",
                Value = 50,
                DueDate = DateTime.Today,
                AccountKind = Simple,
                PayDay = DateTime.Now,
                Detail = "Test"
            };

            //Action
            await _sut.Handle(command, new CancellationToken());

            //Assert
            bankAccount.Balance.Should().Be(50);
        }

        [TestMethod]
        public async Task CreateASimpleExpenseWithPayDayNullNoMustToDebitFromBankAccount()
        {
            //Arrange
            var bankAccount = new BankAccount("Nuconta", 100);
            _accountRepository.GetById(bankAccount.Id).Returns(bankAccount);

            var command = new CreateExpenseCommand
            {
                BankAccountId = bankAccount.Id,
                Name = "Lunch",
                Value = 50,
                DueDate = DateTime.Today,
                AccountKind = Simple,
                PayDay = null,
                Detail = "Test"
            };

            //Action
            await _sut.Handle(command, new CancellationToken());

            //Assert
            bankAccount.Balance.Should().Be(100);
        }
    }
}
