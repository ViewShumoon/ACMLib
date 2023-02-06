using ACMLib.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMLib.Framework.Solutions
{
    public class ShortestWayToFormString : ITest, IGreed
    {
        public dynamic TestMain()
        {
            var pattern = "abc";
            var target = "abcbc";

            var result = ShortestWay(pattern, target);
            return result;
        }

        public int ShortestWay(string pattern, string target)
        {
            int count = 0;

            int currentIndex = 0, sentry;
            while (currentIndex < target.Length)
            {
                sentry = currentIndex;

                foreach (var letter in pattern)
                {
                    if (letter == target[currentIndex])
                    {
                        currentIndex++;
                    }
                }
                /*
                * int patternIndex = 0;
                * while (patternIndex < pattern.Length)
                * {
                *     if (pattern[patternIndex].Equals(target[currentIndex]))
                *     {
                *         currentIndex++;
                *         patternIndex++;
                *     }
                *     else
                *     {
                *         patternIndex++;
                *     }
                * }
                */
                if (currentIndex == sentry)
                {
                    return -1;
                }
                else
                {
                    count++;
                }
            }
            
            return count;
        }
    }
}
