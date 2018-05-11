using Xunit;
using Shouldly;
using System.Linq;

namespace FizzBuzzLib.Tests
{
    public class IEnumerableTests
    {
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1, 10, 10)]
        [InlineData(10, 20, 11)]
        public void IEnumerable_WhenPassedMinMax_ReturnsCorrectNumberOfItems(int min, int max, int expectedCount)
        {
            // Arrange
            var fb = new FizzBuzzer();

            // Act
            var seq = fb.FizzBuzz(min, max).ToList();

            // Assert
            seq.Count.ShouldBe(expectedCount);
        }

        [Theory]
        [InlineData(0, "1")]
        [InlineData(1, "2")]
        [InlineData(2, "Fizz")]
        [InlineData(3, "4")]
        [InlineData(4, "Buzz")]
        [InlineData(5, "Fizz")]
        [InlineData(6, "7")]
        [InlineData(7, "8")]
        [InlineData(8, "Fizz")]
        [InlineData(9, "Buzz")]
        public void IEnumerable_WhenPassed0to10_ReturnsFirst10Items(int index, string expected)
        {
            // Arrange
            var fb = new FizzBuzzer();

            // Act
            var seq = fb.FizzBuzz(1,10).ToList();

            // Assert
            seq[index].ShouldBe(expected);
        }
    }
}
