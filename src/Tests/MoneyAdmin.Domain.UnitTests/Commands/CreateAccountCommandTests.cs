using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyAdmin.Domain.Commands
{
    [TestClass]
    public sealed class CreateAccountCommandTests
    {
        [TestMethod]
        public void CreateAccountWithNameValidShouldTrue()
        {
            // Arrange
            var command = new CreateAccountCommand
            {
                Name = "NuConta"
            };

            // Assert
            command.IsValid.Should().BeTrue();
        }

        [DataTestMethod]
        [DataRow(61)]
        [DataRow(2)]
        [DataRow(0)]
        public void CreateAccountWithNameInvalidShouldFalse(int nameLegth)
        {
            // Arrange
            var command = new CreateAccountCommand
            {
                Name = new string('a', nameLegth)
            };

            // Assert
            command.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void CreateAccountWithNameNullShouldFalse()
        {
            // Arrange
            var command = new CreateAccountCommand
            {
                Name = null
            };

            // Assert
            command.IsValid.Should().BeFalse();
        }
    }
}
