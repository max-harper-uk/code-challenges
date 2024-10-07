using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSamples
{
    public static class StringChallangeSolutions
    {
        public static bool IsAnagramOf(this string testWord, string knownWord)
        {
            if (knownWord.Length != testWord.Length) return false;
            if (knownWord.Equals(testWord, StringComparison.OrdinalIgnoreCase)) return false;
            
            var knownWordCharList = knownWord.ToList();
            for (int index = 0; index < testWord.Length; index++)
            {
                var letter = testWord.ElementAt(index);
                if (knownWordCharList.Remove(letter) && knownWordCharList.Count == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsPalindrome(this string word)
        {
            var reversedWord = new StringBuilder(word.Length);
            for (int index = word.Length-1; index >= 0; index--)
            {
                reversedWord.Append(word[index]);
            }

            return word.Equals(reversedWord.ToString());
        }
    }
}
