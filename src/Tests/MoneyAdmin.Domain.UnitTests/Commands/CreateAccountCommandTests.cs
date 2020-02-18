using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyAdmin.Domain.Commands
{
    [TestClass]
    public class CreateAccountCommandTests
    {
        [TestMethod]
        public void CreateAccountWithNameValidShouldTrue()
        {
            // Arrange
            var command = new CreateAccountCommand();
            command.Name = "NuConta";

            // Action
            var result = command.IsValid;

            // Assert
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(61)]
        [DataRow(2)]
        public void CreateAccountWithNameInvalidShouldFalse(int nameLegth)
        {
            // Arrange
            var command = new CreateAccountCommand();
            command.Name = new string('a', nameLegth);

            // Action
            var result = command.IsValid;

            // Assert
            Assert.IsFalse(result);
        }
    }
}
