using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyAdmin.Domain.Commands;

namespace MoneyAdmin.Domain.Profiles
{
    [TestClass]
    public sealed class AccountMappingProfileTests
    {
        [TestMethod]
        public void AccountMappingProfileShouldValid()
        {
            // Arrange
            var profile = new AccountMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);

            var source = new CreateAccountCommand()
            {
                Name = "NuConta",
                InitialValue = 154
            };

            // Action
            var destination = mapper.Map<CreateAccountCommand, Account>(source);

            // Arrange
            using (new AssertionScope())
            {
                destination.Name.Should().Be(source.Name);
                destination.Amount.Should().Be(source.InitialValue);
            }
        }
    }
}
