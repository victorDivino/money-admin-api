using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MoneyAdmin.Domain.CsvMaps
{
    [TestClass]
    public class AccountCsvMapTests
    {
        [TestMethod]
        public void ShouldThrowExceptionWhenHeaderIsInvalid()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            writer.WriteLine(new string('a', 10));
            writer.Flush();
            stream.Position = 0;

            Action openReadFile = () => OpenReadFile(stream);

            // Assert
            openReadFile.Should().Throw<HeaderValidationException>();
        }

        [DataTestMethod]
        [DataRow(' ', 0)]
        [DataRow(' ', 10)]
        [DataRow('a', 1)]
        [DataRow('a', 61)]
        public void ShouldThrowExceptionWhenNameIsInvalid(char character, int count)
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            writer.WriteLine("Name,Amount");
            writer.WriteLine(new string(character, count) + ",1000");
            writer.Flush();
            stream.Position = 0;

            Action openReadFile = () => OpenReadFile(stream);

            // Assert
            openReadFile.Should().Throw<FieldValidationException>();
        }

        private static void OpenReadFile(MemoryStream stream)
        {
            using var reader = new StreamReader(stream);
            using var sut = new CsvReader(reader, CultureInfo.InvariantCulture);
            sut.Configuration.RegisterClassMap<AccountCsvMap>();
            sut.GetRecords<Account>().ToList();
        }
    }
}
