using AutoFixture.Xunit2;
using TestSamples;
using FluentAssertions;

namespace ChallengeTests
{
    public class PalindromeTests
    {
        //Positive cases
        [Theory]
        [InlineData("racecar")]
        [InlineData("level")]
        [InlineData("kayak")]
        [InlineData("deified")]
        [InlineData("mom")]
        [InlineData("rotator")]
        public void PositivePalindromeTests(string word)
        {
            //Arrage
            //Act
            //Assert
            word.IsPalindrome().Should().BeTrue();
        }

        //Negative cases
        [Theory]
        [InlineData("booze")]
        [InlineData("deaf")]
        [InlineData("oldest")]
        [InlineData("loneliness")]
        [InlineData("lefty")]        
        public void NegativePalindromeTests(string word)
        {
            //Arrage
            //Act
            //Assert
            word.IsPalindrome().Should().BeFalse();
        }
    }
}