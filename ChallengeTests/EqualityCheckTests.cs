using FluentAssertions;

namespace ChallengeTests
{
    public class EqualityCheckTests
    {
        [Theory]
        [InlineData(1, true, false)]
        [InlineData(0, "0", false)]
        [InlineData(1, 1, true)]
        public void WhenComparingEqualityShouldReturnExpectedResult(object obj1, object obj2, bool expected)
        {
            //Arrage
            //Act
            var result = obj1.Equals(obj2);

            //Assert
            result.Should().Be(expected);
        }

    }
}