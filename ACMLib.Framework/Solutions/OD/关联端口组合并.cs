using ACMLib.Framework.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ACMLib.Framework.Solutions.OD
{
    public class 关联端口组合并 : ITest
    {
        public void Main()
        {
            var count = 3; //int.Parse(IO.ReadInputLine());
            int[][] ports =
            {
                new int[] { 2, 3, 1 },
                new int[] { 4, 3, 2 },
                new int[] { 5 }
            };

            var result = MergePorts(ports);
        }

        private int[][] MergePorts(int[][] ports)
        {
            var portList = new List<List<int>>();

            var intersects = portList[0].Intersect(portList[1]);

            if (intersects.Count() >= 2)
            {

            }
            throw new NotImplementedException();
        }
    }

    public static class IO
    {
        static readonly char[] separators = new char[] {','};
        public static string ReadInputLine()
        {
            string line;
            do
            {
                line = System.Console.ReadLine();
            } while (string.IsNullOrEmpty(line));

            return line;
        }

        public static IList<int> ReadInputNumbers(int count)
        {
            var result = new List<int>();

            for (int i = 0; i < count; i++)
            {
                var numbers = ReadInputLine().Split(separators);//, System.StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in numbers)
                {
                    result.Add(int.Parse(item));
                }
            }

            return result;
        }
    }
}
