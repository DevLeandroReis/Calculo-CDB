using Xunit;
using Moq;
using CDBApi.Controllers;
using CDBApi.Models;
using CDBApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Tests.CdbApi.Tests.Controllers
{
    public class CdbControllerTests
    {
        private readonly CdbController _controller;
        private readonly Mock<ICdbService> _mockService = new();

        public CdbControllerTests()
        {
            _controller = new CdbController(_mockService.Object);
        }

        [Fact]
        public void Calculate_ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            var request = new CdbInvestmentRequest { InvestedAmount = 1000, TermInMonths = 12 };
            var response = new CdbInvestmentResponse(1100, 0.2, 880, 1880);
            _mockService.Setup(s => s.Calculate(request)).Returns(response);

            // Act
            var result = _controller.Calculate(request) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(response, result.Value);
        }

        [Fact]
        public void Calculate_ShouldReturnBadRequest_WhenValidationFails()
        {
            // Arrange
            _mockService.Setup(s => s.Calculate(It.IsAny<CdbInvestmentRequest>()))
                        .Throws(new ArgumentException("Invalid request"));

            var request = new CdbInvestmentRequest();

            // Act
            var result = _controller.Calculate(request) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Contains("Invalid request", result.Value?.ToString());
        }

        [Fact]
        public void Calculate_ShouldReturnServerError_OnUnexpectedException()
        {
            // Arrange
            _mockService.Setup(s => s.Calculate(It.IsAny<CdbInvestmentRequest>()))
                        .Throws(new Exception());

            var request = new CdbInvestmentRequest { InvestedAmount = 1000, TermInMonths = 12 };

            // Act
            var result = _controller.Calculate(request) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }
    }
}