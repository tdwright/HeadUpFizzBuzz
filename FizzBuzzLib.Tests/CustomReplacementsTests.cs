using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace FizzBuzzLib.Tests
{
    public class CustomReplacementsTests
    {
        [Fact]
        public void CustomReplacement_WhenPassedMultiple_ReturnReplacement()
        {
            // Arrange
            var fb = new FizzBuzzer(new Dictionary<int, string> { { 7, "Test" } });

            // Act
            var result = fb.ProcessInt(7);

            // Assert
            result.ShouldBe("Test");
        }

        [Fact]
        public void CustomReplacement_WhenPassedNonMultiple_ReturnValue()
        {
            // Arrange
            var fb = new FizzBuzzer(new Dictionary<int, string> { { 7, "Test" } });

            // Act
            var result = fb.ProcessInt(8);

            // Assert
            result.ShouldBe("8");
        }
    }
}
