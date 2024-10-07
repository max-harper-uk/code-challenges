using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeSolutions
{
    public static class NumberChallenges
    {
        public static decimal[] FindLargest(decimal[][] numberArrays)
        {
            var results = new List<decimal>(numberArrays.Length);

            foreach (var array in numberArrays)
                results.Add(array.Max());

            return [.. results];
        }
    }
}
