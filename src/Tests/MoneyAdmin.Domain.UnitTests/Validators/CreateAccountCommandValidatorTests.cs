using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyAdmin.Domain.Commands;

namespace MoneyAdmin.Domain.Validators
{
    [TestClass]
    public sealed class CreateAccountCommandValidatorTests
    {
        private readonly CreateAccountCommandValidator _validator;
        private readonly CreateAccountCommand _command;

        public CreateAccountCommandValidatorTests()
        {
            var validator = new CreateAccountCommandValidator();
            var command = new CreateAccountCommand();
            _validator = validator;
            _command = command;
        }

        [TestMethod]
        public void CreateAccountCommandValidatorShouldBeTrue()
        {
            // Arrange
            _command.Name = "NuConta";

            // Action
            var validation = _validator.Validate(_command);

            // Assert            
            validation.IsValid.Should().BeTrue();
        }


        [DataTestMethod]
        [DataRow(61)]
        [DataRow(2)]
        [DataRow(0)]
        public void CreateAccountCommandValidatorWithInvalidNameShouldError(int nameLegth)
        {
            // Arrange
            _command.Name = new string('a', nameLegth);

            // Action
            var validation = _validator.Validate(_command);

            // Assert
            validation.Errors.Single().ErrorMessage.Should().Be("The name must be greater than 2 less than 60");
        }
    }
}
