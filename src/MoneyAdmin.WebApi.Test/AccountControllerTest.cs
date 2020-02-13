using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyAdmin.Domain.Interfaces;
using MoneyAdmin.WebApi.Controllers;
using NSubstitute;
using System;
using System.IO;

namespace MoneyAdmin.WebApi.Test
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void ShouldReturnOkResultToPostFileMethod()
        {
            // Arrange
            var mockRepo = Substitute.For<IAccountRepository>();
            var mockRepoReadOnly = Substitute.For<IAccountRepositoryReadOnly>();
            var controller = new AccountController(mockRepo, mockRepoReadOnly);

            var stream = new MemoryStream();
            var sw = new StreamWriter(stream);
            sw.WriteLine("Name,Amount");
            sw.WriteLine("Itau,1000");
            sw.WriteLine("Nubank,2000");
            sw.Flush();
            stream.Position = 0;
            var file = new FormFile(stream, 0, stream.Length, null, Path.GetTempFileName())
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/csv"
            };

            // Action
            var result = controller.PostFile(file);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void ShouldReturnBadRequestResultToPostFileMethod()
        {
            // Arrange
            var mockRepo = Substitute.For<IAccountRepository>();
            var mockRepoReadOnly = Substitute.For<IAccountRepositoryReadOnly>();
            var controller = new AccountController(mockRepo, mockRepoReadOnly);

            // Action
            var result = controller.PostFile(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void ShouldThrowExceptionByWhitespaceToPostFileMethod()
        {
            // Arrange
            var mockRepo = Substitute.For<IAccountRepository>();
            var mockRepoReadOnly = Substitute.For<IAccountRepositoryReadOnly>();
            var controller = new AccountController(mockRepo, mockRepoReadOnly);

            var stream = new MemoryStream();
            var sw = new StreamWriter(stream);
            sw.WriteLine("Name,Amount");
            sw.WriteLine(new String(' ', 10) + ",1000");
            sw.Flush();
            stream.Position = 0;
            var file = new FormFile(stream, 0, stream.Length, null, Path.GetTempFileName())
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/csv"
            };

            Exception exception = null;

            // Action
            try
            {
                controller.PostFile(file);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void ShouldThrowExceptionByMinLengthToPostFileMethod()
        {
            // Arrange
            var mockRepo = Substitute.For<IAccountRepository>();
            var mockRepoReadOnly = Substitute.For<IAccountRepositoryReadOnly>();
            var controller = new AccountController(mockRepo, mockRepoReadOnly);

            var stream = new MemoryStream();
            var sw = new StreamWriter(stream);
            sw.WriteLine("Name,Amount");
            sw.WriteLine(new String('a', 1) + ",1000");
            sw.Flush();
            stream.Position = 0;
            var file = new FormFile(stream, 0, stream.Length, null, Path.GetTempFileName())
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/csv"
            };

            Exception exception = null;

            // Action
            try
            {
                controller.PostFile(file);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void ShouldThrowExceptionByMaxLengthToPostFileMethod()
        {
            // Arrange
            var mockRepo = Substitute.For<IAccountRepository>();
            var mockRepoReadOnly = Substitute.For<IAccountRepositoryReadOnly>();
            var controller = new AccountController(mockRepo, mockRepoReadOnly);

            var stream = new MemoryStream();
            var sw = new StreamWriter(stream);
            sw.WriteLine("Name,Amount");
            sw.WriteLine(new String('a', 101) + ",1000");
            sw.Flush();
            stream.Position = 0;
            var file = new FormFile(stream, 0, stream.Length, null, Path.GetTempFileName())
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/csv"
            };

            Exception exception = null;

            // Action
            try
            {
                controller.PostFile(file);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            Assert.IsNotNull(exception);
        }
    }
}
