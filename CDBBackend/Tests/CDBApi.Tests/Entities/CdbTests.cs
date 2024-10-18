using Xunit;
using CDBApi.Entities;

namespace Tests.CdbApi.Tests.Entities
{
    public class CdbTests
    {
        [Theory]
        [InlineData(1000, 6, 0.225)]
        [InlineData(1000, 7, 0.20)]
        [InlineData(1000, 12, 0.20)]
        [InlineData(1000, 13, 0.175)]
        [InlineData(1000, 24, 0.175)]
        [InlineData(1000, 25, 0.15)]
        [InlineData(1000, 36, 0.15)]
        public void Cdb_ShouldCalculateTaxCorrectly(double investedAmount, int term, double expectedTax)
        {
            // Arrange
            var cdb = new Cdb(investedAmount, term);

            // Act
            cdb.Calculate();

            // Assert
            Assert.Equal(expectedTax, cdb.Tax);
        }

        [Theory]
        [InlineData(1000, 6, 1046.3106f)]
        [InlineData(1000, 12, 1098.4657f)]
        [InlineData(1000, 24, 1215.5835f)]
        [InlineData(1000, 36, 1354.0747f)]
        public void Cdb_ShouldCalculateFinalValueCorrectly(double investedAmount, int termInMoths, double expectedFinalValue)
        {
            // Arrange
            var cdb = new Cdb(investedAmount, termInMoths);
            float epsilon = 0.001f;

            // Act
            cdb.Calculate();

            // Assert
            Assert.True(Math.Abs(expectedFinalValue - cdb.FinalValue) < epsilon);
        }


        [Theory]
        [InlineData(1000, 6, 1059.7557f)]
        [InlineData(1000, 12, 1123.0821)]
        [InlineData(1000, 24, 1261.3134f)]
        [InlineData(1000, 36, 1416.5585f)]
        public void Cdb_ShouldCalculateGrossCorrectly(double investedAmount, int termInMoths, double expectedGross)
        {
            // Arrange
            var cdb = new Cdb(investedAmount, termInMoths);
            float epsilon = 0.001f;

            // Act
            cdb.Calculate();

            // Assert
            Assert.True(Math.Abs(expectedGross - cdb.Gross) < epsilon);
        }

        [Theory]
        [InlineData(1000, 6, 59.7557f)]
        [InlineData(1000, 12, 123.0821f)]
        [InlineData(1000, 24, 261.3134f)]
        [InlineData(1000, 36, 416.5585f)]
        public void Cdb_ShouldCalculateGrossYieldCorrectly(double investedAmount, int termInMoths, double expectedGrossYield)
        {
            // Arrange
            var cdb = new Cdb(investedAmount, termInMoths);
            float epsilon = 0.001f;

            // Act
            cdb.Calculate();

            // Assert
            Assert.True(Math.Abs(expectedGrossYield - cdb.GrossYield) < epsilon);
        }

        [Theory]
        [InlineData(1000, 6, 46.3106f)]
        [InlineData(1000, 12, 98.4657f)]
        [InlineData(1000, 24, 215.5835f)]
        [InlineData(1000, 36, 354.0747f)]
        public void Cdb_ShouldCalculateNetYieldCorrectly(double investedAmount, int termInMoths, double expectedNetYield)
        {
            // Arrange
            var cdb = new Cdb(investedAmount, termInMoths);
            float epsilon = 0.001f;

            // Act
            cdb.Calculate();

            // Assert
            Assert.True(Math.Abs(expectedNetYield - cdb.NetYield) < epsilon);
        }
    }
}