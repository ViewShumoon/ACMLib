using ACMLib.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMLib.Framework.Solutions.OD
{
    internal class 单词倒序 : ITest
    {
        public void Main()
        {
            var line = "woH era uoy ? I ma enif.";

            var result = Reverse(line);
        }

        public dynamic Reverse(string line)
        {
            var wordList = new List<string>();

            StringBuilder wordBuilder = new StringBuilder();
            for (int i = line.Length - 1; i >= 0; i--)
            {
                var current = line[i];
                if (IsDivider(current))
                {
                    if (wordBuilder.Length > 0)
                    {
                        wordList.Add(wordBuilder.ToString());
                        wordBuilder.Clear();
                    }

                    wordList.Add(current.ToString());
                }
                else
                {
                    wordBuilder.Append(current);
                }
            }
            // 添加最后一个词语
            wordList.Add(wordBuilder.ToString());

            return ReverseWords(wordList);
        }

        private static string ReverseWords(IList<string> words)
        {
            StringBuilder line = new StringBuilder();
            for (int i = words.Count - 1; i >= 0; i--)
            {
                line.Append(words[i]);
            }

            return line.ToString();
        }

        private static bool IsDivider(char current) => current == ' ' || current == ',' || current == '.' || current == '?';
    }
}
