using Shouldly;
using Xunit;

namespace FizzBuzzLib.Tests
{
    public class SingleIntTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        public void NonMultiples_WhenPassedToProcessInt_ReturnSimpleStrings(int input)
        {
            // Arrange
            var fb = new FizzBuzzer();

            // Act
            var result = fb.ProcessInt(input);

            // Assert
            result.ShouldBe(input.ToString());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void ThreeMultiples_WhenPassedToProcessInt_ReturnFizz(int input)
        {
            // Arrange
            var fb = new FizzBuzzer();

            // Act
            var result = fb.ProcessInt(input);

            // Assert
            result.ShouldBe("Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void FiveMultiples_WhenPassedToProcessInt_ReturnBuzz(int input)
        {
            // Arrange
            var fb = new FizzBuzzer();

            // Act
            var result = fb.ProcessInt(input);

            // Assert
            result.ShouldBe("Buzz");
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        public void BothMultiples_WhenPassedToProcessInt_ReturnFizzBuzz(int input)
        {
            // Arrange
            var fb = new FizzBuzzer();

            // Act
            var result = fb.ProcessInt(input);

            // Assert
            result.ShouldBe("FizzBuzz");
        }
    }
}
