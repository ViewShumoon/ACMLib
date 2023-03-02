using ACMLib.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMLib.Framework.Test
{
    public class 字符串排序 : ITest
    {
        public void Main()
        {
            var line = IO.ReadInputLine();
            var lettersAndSymbols = SeparateLetters(line);

            var result = CombineChars(lettersAndSymbols, line.Length);
        }

  

        private LetterAndSymbol SeparateLetters(string line)
        {
            var wordList = new List<char>();
            var symbols = new Dictionary<int, char>();

            for (int i = 0; i < line.Length; i++)
            {
                var current = line[i];
                if (IsLetter(current))
                {
                    wordList.Add(current);
                }
                else
                {
                    symbols.Add(i, current);
                }
            }

            wordList = wordList.OrderBy(letter => letter, new OrdinalIgnoreCaseComparer()).ToList();

            return new LetterAndSymbol
            {
                Letters = wordList,
                Symbols = symbols
            };
        }
 
        private static bool IsLetter(char letter) =>
            ('a' <= letter && letter <= 'z') ||
            ('A' <= letter && letter <= 'Z');
        private string CombineChars(LetterAndSymbol lettersAndSymbols, int length)
       {
            var builder = new StringBuilder(length);
            var currentLetterIndex = 0;
            for (int i = 0; i < length; i++)
            {
                char current;
                if (lettersAndSymbols.Symbols.TryGetValue(i, out current))
                {
                    builder.Append(current);
                }
                else
                {
                    builder.Append(lettersAndSymbols.Letters[currentLetterIndex]);
                    currentLetterIndex++;
                }
            }

            return builder.ToString();
       }

    }
    public class OrdinalIgnoreCaseComparer : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            x = Char.ToLower(x);
            y = Char.ToLower(y);
            if (x < y) return -1;
            if (x > y) return 1;

            return 0;
        }
    }



    public struct LetterAndSymbol
    {
        public IList<char> Letters;
        public Dictionary<int, char> Symbols;
    }
}
