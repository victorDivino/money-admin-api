using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyAdmin.Domain.Commands;
using MoneyAdmin.Domain.Core.Commands;
using MoneyAdmin.Domain.Interfaces;
using NSubstitute;
using System.Threading.Tasks;

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
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task ShouldReturnBadRequestResultToPostFileMethod()
        {
            // Arrange

            // Action
            var result = await _sut.PostFile(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}
