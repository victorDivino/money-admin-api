using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.Interfaces;
using NSubstitute;

namespace MoneyAdmin.WebApi.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        private readonly BankAccountController _sut;
        private readonly IBankAccountRepositoryReadOnly _repository;
        private readonly IMediator _mediator;

        public AccountControllerTest()
        {
            _mediator = Substitute.For<IMediator>();
            _repository = Substitute.For<IBankAccountRepositoryReadOnly>();
            _sut = new BankAccountController(_mediator, _repository);
        }

        [TestMethod]
        public async Task ShouldReturnOkResultToPostFileMethod()
        {
            // Arrange
            var file = Substitute.For<IFormFile>();
            _mediator.Send(Arg.Any<ImportBankAccountCommand>()).Returns(new CommandResult());

            // Action
            var result = await _sut.Import(file);

            // Assert
            result.Should().BeOfType(typeof(OkResult));
        }

        [TestMethod]
        public async Task ShouldReturnBadRequestResultToPostFileMethod()
        {
            // Action
            var result = await _sut.Import(null);

            // Assert
            result.Should().BeOfType(typeof(BadRequestObjectResult));
        }
    }
}
