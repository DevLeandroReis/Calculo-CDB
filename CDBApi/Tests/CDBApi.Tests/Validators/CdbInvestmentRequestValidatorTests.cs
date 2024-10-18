using Xunit;
using CDBApi.Models;
using CDBApi.Validators;
using System;

namespace Tests.CdbApi.Tests.Validators
{
    public class CdbInvestmentRequestValidatorTests
    {
        private readonly CdbInvestmentRequestValidator _validator = new();

        [Fact]
        public void Validate_ShouldThrowArgumentException_WhenInvestedAmountIsMissing()
        {
            // Arrange
            var request = new CdbInvestmentRequest { TermInMonths = 12 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _validator.Validate(request));
        }

        [Fact]
        public void Validate_ShouldThrowArgumentException_WhenTermIsMissing()
        {
            // Arrange
            var request = new CdbInvestmentRequest { InvestedAmount = 1000 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _validator.Validate(request));
        }

        [Fact]
        public void Validate_ShouldThrowArgumentException_WhenTermIsInvalid()
        {
            // Arrange
            var request = new CdbInvestmentRequest { InvestedAmount = 1000, TermInMonths = 0 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _validator.Validate(request));
        }

        [Fact]
        public void Validate_ShouldThrowArgumentException_WhenInvestedAmountIsInvalid()
        {
            // Arrange
            var request = new CdbInvestmentRequest { InvestedAmount = 0, TermInMonths = 12 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _validator.Validate(request));
        }
    }
}