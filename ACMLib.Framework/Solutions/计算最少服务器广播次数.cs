using ACMLib.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMLib.Framework.Solutions
{
    public class 计算最少服务器广播次数 : ITest
    {
        public void Main()
        {
            var serverTable = new int[][]
            {
               //         1,2,3,4,5
               new int[] {1,0,1,0,0},
               new int[] {0,1,0,1,0},
               new int[] {1,0,1,0,1},
               new int[] {0,1,0,1,0},
               new int[] {0,0,1,0,1}
            };

            var result = CountServerConnection(serverTable);

        }

        private dynamic CountServerConnection(int[][] serverTable)
        {
            var rank = serverTable[0].Length;
            var linkedServerList = new List<int[]>();

            var visited = new int[rank];

            for (int i = 0; i < rank; i++)
            {
                for (int j = 0; j < rank; j++)
                {

                }
            }


            return -1;
        }


    }
}
