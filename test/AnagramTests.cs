using FluentAssertions;
using TestSamples;

namespace ChallengeTests
{
    public class AnagramTests
    {
        //Positive cases
        [Theory]
        [InlineData("cents", "scent")]
        [InlineData("deaf", "fade")]
        [InlineData("molest", "motels")]
        [InlineData("toneless", "noteless")]
        [InlineData("untidy", "nudity")]
        [InlineData("race", "care")]
        public void PositiveAnagramCasesShouldBeTrue(string s, string t)
        {
            //Arrage
            //Act
            //Assert
            t.IsAnagramOf(s).Should().BeTrue();
        }

        //Negative cases
        [Theory]
        [InlineData("booze", "dozen")]
        [InlineData("deaf", "fear")]
        [InlineData("oldest", "molest")]
        [InlineData("loneliness", "noteworthyless")]
        [InlineData("lefty", "righty")]
        [InlineData("racecar", "racecar")]
        public void NegativeAnagramCasesShouldBeFalse(string s, string t)
        {
            //Arrage
            //Act
            //Assert
            t.IsAnagramOf(s).Should().BeFalse();
        }
    }
}