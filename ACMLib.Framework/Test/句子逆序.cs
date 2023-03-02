using ACMLib.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMLib.Framework.Test
{
    public class 句子逆序 : ITest
    {
        public static readonly char separator = ' ';
        public void Main()
        {
            var line = IO.ReadInputLine();
            var wordList = SplitLine(line);

            var reversedLine = CombineWords(wordList.Reverse().ToList());

            Console.WriteLine(reversedLine);
        }

        private static IList<string> SplitLine(string line)
        {
            var wordList = new List<string>();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                var current = line[i];
                if (IsSeparator(current))
                {
                    if (builder.Length > 0)
                    {
                        wordList.Add(builder.ToString());
                        builder.Clear();
                    }

                    wordList.Add(current.ToString());
                }
                else
                {
                    builder.Append(current);
                }
            }

            // 添加最后一个单词
            wordList.Add(builder.ToString());

            return wordList;
        }

        private static bool IsSeparator(char current) => current == separator;

        private static string CombineWords(IList<string> words)
        {
            var builder = new StringBuilder();
            foreach (var item in words)
            {
                builder.Append(item);
            }

            return builder.ToString();
        }
    }

    public class IO
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
    }
}
