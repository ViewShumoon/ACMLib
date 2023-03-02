using ACMLib.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMLib.Framework.Solutions.OD
{
    /*
    * 0 R
    * 1 B R
    * 2 RB BR
    * 3 BRRB RBBR
    * 4 RBBR BRRB BRRB RBBR
    */

    public class 对称字符串 : ITest
    {
        public void Main()
        {
            var count = 1;
            int target = 5, index = 9;
            
            var result = GetLetterAt(target, index);
        }

        public string GetLetterAt(int rank,int target)
        {
            long stringLength = (long)Math.Pow(2, rank - 1);
            var flipCount = 0;
            
            flipCount = Filp(stringLength, target, flipCount);

            return (flipCount % 2 == 0) ? "red" : "blue";
        }

        private int Filp(long stringLength, long currentIndex, int filpCount)
        {
            if (stringLength == 1)
            {
                return filpCount;
            }

            var middle = stringLength / 2;
            if (currentIndex < middle)
            {
                filpCount++;
                return Filp(middle, currentIndex, filpCount);
            }
            else
            {
                return Filp(middle, currentIndex - middle, filpCount);
            }
        }
    }
}
