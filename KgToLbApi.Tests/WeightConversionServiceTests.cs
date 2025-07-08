using KgToLbApi.Domain;
using Xunit;

namespace KgToLbApi.Tests
{
    public class WeightConversionServiceTests
    {
        [Fact]
        public void ConvertKgToPounds_OneKg_ReturnsCorrectValue()
        {
            // Arrange
            var service = new WeightConversionService();

            // Act
            var result = service.ConvertKgToPounds(1);

            // Assert
            Assert.Equal(2.20462, result, 5);
        }

        [Fact]
        public void ConvertKgToPounds_NegativeKg_ThrowsArgumentException()
        {
            // Arrange
            var service = new WeightConversionService();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.ConvertKgToPounds(-1));
        }
    }
}
