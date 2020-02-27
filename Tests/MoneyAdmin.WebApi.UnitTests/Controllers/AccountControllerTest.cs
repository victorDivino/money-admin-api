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
        private readonly AccountController _sut;
        private readonly IAccountRepositoryReadOnly _repository;
        private readonly IMediator _mediator;

        public AccountControllerTest()
        {
            _mediator = Substitute.For<IMediator>();
            _repository = Substitute.For<IAccountRepositoryReadOnly>();
            _sut = new AccountController(_mediator, _repository);
        }

        [TestMethod]
        public async Task ShouldReturnOkResultToPostFileMethod()
        {
            // Arrange
            var file = Substitute.For<IFormFile>();
            _mediator.Send(Arg.Any<CreateAccountBatchCommand>()).Returns(new CommandResult());

            // Action
            var result = await _sut.PostFile(file);

            // Assert
            result.Should().BeOfType(typeof(OkResult));
        }

        [TestMethod]
        public async Task ShouldReturnBadRequestResultToPostFileMethod()
        {
            // Action
            var result = await _sut.PostFile(null);

            // Assert
            result.Should().BeOfType(typeof(BadRequestObjectResult));
        }
    }
}
