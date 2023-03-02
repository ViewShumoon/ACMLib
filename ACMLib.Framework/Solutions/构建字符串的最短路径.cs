using ACMLib.Framework.Attribute;
using ACMLib.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMLib.Framework.Solutions
{
    [SolutionType(DataStructureType.字符串)]
    public class 构建字符串的最短路径 : ITest
    {
        public void Main()
        {
            var pattern = "abc";
            var target = "abcbc";

            var result = ShortestWay(pattern, target);

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
