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
    public sealed class CreateBankAccountCommandHandlerTests
    {
        private readonly CreateBankAccountCommandHandler _sut;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBankAccountCommandHandlerTests()
        {
            _mapper = Substitute.For<IMapper>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _sut = new CreateBankAccountCommandHandler(_unitOfWork);
        }

        [TestMethod]
        public async Task CreateAccountShouldTrue()
        {
            // Arrange
            var command = new CreateBankAccountCommand
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
            var command = new CreateBankAccountCommand();

            // Action
            var commandResult = await _sut.Handle(command, new CancellationToken());

            // Assert
            commandResult.IsSuccess.Should().BeFalse();
        }
    }
}
