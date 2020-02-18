using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Interfaces;
using NSubstitute;

namespace MoneyAdmin.Domain.Handlers
{
    [TestClass]
    public sealed class CreateAccountCommandHandlerTests
    {
        private readonly CreateAccountCommandHandler _sut;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;


        public CreateAccountCommandHandlerTests()
        {
            _mapper = Substitute.For<IMapper>();
            _accountRepository = Substitute.For<IAccountRepository>();
            _sut = new CreateAccountCommandHandler(_accountRepository, _mapper);
        }

        [TestMethod]
        public async Task CreateAccountShouldTrue()
        {
            // Arrange
            var command = new CreateAccountCommand
            {
                Name = "NuConta"
            };

            // Action
            var commandResult = await _sut.Handle(command, new CancellationToken());

            // Assert
            commandResult.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public async Task CreateAccountShouldFalse()
        {
            // Arrange
            var command = new CreateAccountCommand();

            // Action
            var commandResult = await _sut.Handle(command, new CancellationToken());

            // Assert
            commandResult.IsSuccess.Should().BeFalse();
        }
    }
}
