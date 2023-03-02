using System.Collections.Generic;

namespace ACMLib.Framework.Common {

    public static class IO
    {
        public static string ReadLine()
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
            for (int i = 0; i <= count; i++)
            {
                result.Add(int.Parse(ReadLine()));
            }

            return result;
        }

    }
}
