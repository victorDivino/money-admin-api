using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyAdmin.Domain.Validators;

namespace MoneyAdmin.Domain.Commands
{
    [TestClass]
    public sealed class CreateAccountCommandTests
    {
        private readonly CreateAccountCommandValidator _validator;
        private readonly CreateAccountCommand _command;

        public CreateAccountCommandTests()
        {
            var validator = new CreateAccountCommandValidator();
            var command = new CreateAccountCommand();
            _validator = validator;
            _command = command;
        }

        [TestMethod]
        public void CreateAccountShouldValid()
        {
            // Arrange
            _command.Name = "NuConta";
            _command.InitialValue = 0;

            // Action
            var validation = _validator.Validate(_command);

            // Assert            
            validation.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void CreateAccountWithNameEmptyOrInitialValueLowerZeroShouldInvalid()
        {
            // Arrange
            _command.Name = "";
            _command.InitialValue = -1;

            // Action
            var validation = _validator.Validate(_command);

            // Assert
            using (new AssertionScope())
            {
                validation.Errors.ElementAt(0).ErrorMessage.Should().Be("is required");
                validation.Errors.ElementAt(1).ErrorMessage.Should().Be("should be lower or equals than 0");
            }
        }
    }
}
