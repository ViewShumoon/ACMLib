using ACMLib.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMLib.Framework.Solutions
{
    public class 统计连续子区间和 : ITest
    {
        public void Main()
        {
            int length = 3;
            int target = 6;
            int[] numbers = { 2, 4, 7 };
        }

        public int CountContinuousInterval(int length, int target, int[] numberArray)
        {
            var count = 0;

            long sum = numberArray[0];
            int end = 0;
            for (int start = 0; start < length; start++)
            {
                sum += numberArray[start];
                
                while (sum >= target && end <= start)
                {
                    // 右侧的都是满足大于 target 的区间，全部添加
                    count += length - start;

                    sum -= numberArray[end];

                    end++;
                }
            }

            return count;
        }

    }
}
