using System;

namespace RegexM
{
    public class Program
    {
        private const char MATCHER = '*';

        public static void Main(string[] args)
        {
            Console.WriteLine("Match('abcd', 'a*d') +: " + CheckMatch("abcd", "a*d"));
            Console.WriteLine("Match('abcd', 'a*') +: " + CheckMatch("abcd", "a*"));
            Console.WriteLine("Match('fas', 'a*') -: " + CheckMatch("fas", "a*"));
            Console.WriteLine("Match('abc', 'abc') +: " + CheckMatch("abc", "abc"));
            Console.WriteLine("Match('absd', 'abc') -: " + CheckMatch("absd", "abc"));
            Console.WriteLine("Match('asfa', 'a*f*') +: " + CheckMatch("asfa", "a*f*"));
            Console.WriteLine("Match('fasf', 'a*f*') -: " + CheckMatch("fasf", "a*f*"));
            Console.WriteLine("Match('fasffasf', 'f*f*f') +: " + CheckMatch("fasffasf", "f*f*f"));
            Console.WriteLine("Match('ad', 'a*d') +: " + CheckMatch("ad", "a*d"));
            Console.WriteLine("Match('adadad', 'a*d*') +: " + CheckMatch("adadad", "a*d*"));
            Console.WriteLine("Match('adadad', 'a*d') +: " + CheckMatch("adadad", "a*d"));
            Console.WriteLine("Match('adadad', 'a*d*s') -: " + CheckMatch("adadad", "a*d*s"));
            Console.WriteLine("Match('adadads', 'a*d*s') +: " + CheckMatch("adadads", "a*d*s"));
            Console.WriteLine("Match('adadads', 'a*i*s') -: " + CheckMatch("adadads", "a*i*s"));
            Console.WriteLine("Match('adadaadaads', 'a*a*a*s') +: " + CheckMatch("adadaadaads", "a*a*a*s"));
            Console.WriteLine("Match('aaas', 'a*a*a*s') +: " + CheckMatch("aaas", "a*a*a*s"));

            Console.ReadLine();
        }

        public static bool CheckMatch(string str, string pattern)
        {
            if (string.IsNullOrEmpty(str))
            {
                if (string.IsNullOrEmpty(pattern))
                {
                    return true;
                }

                if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(pattern.Trim(MATCHER)))
                {
                    return true;
                }

                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(pattern))
                {
                    return false;
                }

                if (string.IsNullOrEmpty(pattern.Trim(MATCHER)))
                {
                    return true;
                }
            }

            // positions from str for matches
            int[] strPositions = new int[str.Length + 1];
            // positions from pattern for matches
            int[] patternPositions = new int[pattern.Length + 1];
            // last position checked
            int lastPosition = -1;
            // chars matched from str to pattern
            bool[,] positionsStrPatternTest = new bool[str.Length + 1, pattern.Length + 1];

            int strIndex = 0;
            int patternIndex = 0;

            // search for first *
            while (strIndex < str.Length && patternIndex < pattern.Length
                && pattern[patternIndex] != MATCHER
                && (str[strIndex] == pattern[patternIndex]))
            {
                strIndex++;
                patternIndex++;
            }

            // if it is pattern end or * found put values in position arrays
            if (patternIndex == pattern.Length || pattern[patternIndex] == MATCHER)
            {
                positionsStrPatternTest[strIndex, patternIndex] = true;

                lastPosition++;

                strPositions[lastPosition] = strIndex;
                patternPositions[lastPosition] = patternIndex;
            }

            bool isMatch = false;

            while (lastPosition >= 0 && !isMatch)
            {
                // get next match indexes
                strIndex = strPositions[lastPosition];
                patternIndex = patternPositions[lastPosition];

                lastPosition--;

                // if it is end, then we got a match
                if (strIndex == str.Length && patternIndex == pattern.Length)
                    isMatch = true;
                else
                {
                    for (int i = strIndex; i < str.Length; i++)
                    {
                        int curStrPos = i;
                        int curPatternPos = patternIndex + 1;

                        if (curPatternPos == pattern.Length)
                        {
                            curStrPos = str.Length;
                        }
                        else
                        {
                            // while chars match go through everything
                            while (curStrPos < str.Length && curPatternPos < pattern.Length
                                && pattern[curPatternPos] != MATCHER && str[curStrPos] == pattern[curPatternPos])
                            {
                                curStrPos++;
                                curPatternPos++;
                            }
                        }

                        // update arrays if we are at the end of block or inputs and we have not updated it already
                        if (((curPatternPos == pattern.Length && curStrPos == str.Length)
                            || (curPatternPos < pattern.Length && pattern[curPatternPos] == MATCHER))
                            && !positionsStrPatternTest[curStrPos, curPatternPos])
                        {
                            positionsStrPatternTest[curStrPos, curPatternPos] = true;

                            lastPosition++;

                            strPositions[lastPosition] = curStrPos;
                            patternPositions[lastPosition] = curPatternPos;
                        }
                    }
                }
            }

            return isMatch;
        }
    }
}