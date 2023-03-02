using ACMLib.Framework.Attribute;
using ACMLib.Framework.Models;

using System.Collections.Generic;
using System.Linq;

namespace ACMLib.Framework.Solutions
{
    [SolutionType(DataStructureType.字符串)]
    public class 字符串分割 : ITest
    {
        public void Main()
        {
            var line = "guwldvzrsfurobidegiyazkggfpgmyhlrbfjrjerrbnjdenrdxjfmrhtumfdsedkcmthphgavzxlmpcpwbkwsvplhmkbkgkw"; //IO.ReadLine();

            var result = SubStringToList(line, 8);

            foreach (var item in result)
            {
                System.Console.WriteLine(item);
            }
        }

        public static IList<string> SubStringToList(string text, int length)
        {
            var result = new List<string>();

            if (text.Length <= length)
            {
                result.Add(text.PadRight(length, '0'));
            }
            else
            {
                int count = text.Length / length;
                for (int i = 0; i < count; i++)
                {
                    int startIndex = i * length;
                    result.Add(text.Substring(startIndex, length));
                }

                if (text.Length % length != 0)
                {
                    var finalLine = text.Substring((int)count * length);
                    result.Add(finalLine.PadRight(length, '0'));
                }
            }

            return result;
        }
    }
}
