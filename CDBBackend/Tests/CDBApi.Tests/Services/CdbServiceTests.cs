using Xunit;
using Moq;
using CDBApi.Models;
using CDBApi.Services;
using CDBApi.Validators;
using System;
using CdbApi.Services;

namespace Tests.CdbApi.Tests.Services
{
    public class CdbServiceTests
    {
        private readonly CdbService _service;
        private readonly Mock<IValidator<CdbInvestmentRequest>> _mockValidator = new();

        public CdbServiceTests()
        {
            _service = new CdbService(_mockValidator.Object);
        }

        [Fact]
        public void Calculate_ShouldReturnCorrectResponse_WhenRequestIsValid()
        {
            // Arrange
            var request = new CdbInvestmentRequest { InvestedAmount = 1000, TermInMonths = 12 };
            _mockValidator.Setup(v => v.Validate(request));

            // Act
            var response = _service.Calculate(request);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.FinalValue > 1000);
        }

        [Fact]
        public void Calculate_ShouldThrowException_WhenRequestIsInvalid()
        {
            // Arrange
            var request = new CdbInvestmentRequest();
            _mockValidator.Setup(v => v.Validate(request))
                          .Throws(new ArgumentException("Invalid request"));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _service.Calculate(request));
        }
    }
}