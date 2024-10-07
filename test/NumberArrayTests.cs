using CodingChallengeSolutions;
using FluentAssertions;
using System.Collections;

namespace ChallengeTests
{
    public class NumberArrayTests
    {
        [Theory]
        [ClassData(typeof(NumberArrayTestData))]
        public void FindLargestInEachTestShouldReturnExpected(decimal[][] testCase, decimal[] expected)
        {
            //Arrage
            //Act
            var result = NumberChallenges.FindLargest(testCase);

            //Assert
            result.Should().BeEquivalentTo(expected);
        }

        public class NumberArrayTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new decimal[][] { [4, 2, 7, 1], [20, 70, 40, 90], [1, 2, 0] }, new decimal[] { 7, 90, 2 } };
                yield return new object[] { new decimal[][] { [-34, -54, -74], [-32, -2, -65], [-54, 7, -43] }, new decimal[] { -34, -2, 7 } };
                yield return new object[] { new decimal[][] { [0.4321m, 0.7634m, 0.652m], [1.324m, 9.32m, 2.5423m, 6.4314m], [9, 3, 6, 3] }, new decimal[] { 0.7634m, 9.32m, 9 } };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}