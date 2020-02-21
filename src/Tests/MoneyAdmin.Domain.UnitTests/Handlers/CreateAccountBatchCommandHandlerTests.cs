using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Interfaces;
using NSubstitute;

namespace MoneyAdmin.Domain.Handlers
{
    [TestClass]
    public class CreateAccountBatchCommandHandlerTest
    {
        private IUnitOfWork _unitOfWork;
        private CreateAccountBatchCommandHandler _sut;

        public CreateAccountBatchCommandHandlerTest()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _sut = new CreateAccountBatchCommandHandler(_unitOfWork);
        }

        [TestMethod]
        public async Task ShouldBeTrueWhenFileIsValid()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            writer.WriteLine("Name,Amount");
            writer.WriteLine("Itau,1000");
            writer.Flush();
            stream.Position = 0;

            var command = new CreateAccountBatchCommand(stream);

            // Action
            var result = await _sut.Handle(command, new CancellationToken());

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public async Task ShouldBeFalseWhenFileIsEmpty()
        {
            // Arrange
            using var stream = new MemoryStream();
            var command = new CreateAccountBatchCommand(stream);

            // Action
            var result = await _sut.Handle(command, new CancellationToken());

            // Assert
            result.IsSuccess.Should().BeFalse();
        }
    }
}
