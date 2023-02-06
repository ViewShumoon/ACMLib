using System.Collections.Generic;

namespace ACMLib {

    public static class IO
    {
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
            for (int i = 0; i <= count; i++)
            {
                result.Add(int.Parse(ACMLib.IO.ReadInputLine()));
            }

            return result;
        }
    }
}
