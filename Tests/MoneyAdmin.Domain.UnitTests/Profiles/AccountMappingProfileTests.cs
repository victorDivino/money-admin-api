using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyAdmin.Domain.Profiles
{
    [TestClass]
    public sealed class AccountMappingProfileTests
    {
        [TestMethod]
        public void AccountMappingProfileShouldValid()
        {
            // Arrange
            //var profile = new AccountMappingProfile();
            //var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            //var mapper = new Mapper(configuration);

            //var source = new CreateBankAccountCommand()
            //{
            //    Name = "NuConta",
            //    InitialValue = 154
            //};

            //// Action
            //var destination = mapper.Map<CreateBankAccountCommand, BankAccount>(source);

            //// Assert
            //using (new AssertionScope())
            //{
            //    destination.Name.Should().Be(source.Name);
            //    destination.Balance.Should().Be(source.InitialValue);
        }
    }
}
