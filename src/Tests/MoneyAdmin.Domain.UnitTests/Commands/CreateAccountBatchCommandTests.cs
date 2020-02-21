using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyAdmin.Domain.Commands
{
    [TestClass]
    public class CreateAccountBatchCommandTests
    {
        [TestMethod]
        public void ShouldBeTrueWhenFileIsValid()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            writer.WriteLine("Name,Amount");
            writer.WriteLine("Itau,1000");
            writer.Flush();
            stream.Position = 0;

            var sut = new CreateAccountBatchCommand(stream);

            // Assert
            sut.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldBeFalseWhenFileIsEmpty()
        {
            // Arrange
            using var stream = new MemoryStream();
            var sut = new CreateAccountBatchCommand(stream);

            // Assert
            sut.IsValid.Should().BeFalse();
        }
    }
}
