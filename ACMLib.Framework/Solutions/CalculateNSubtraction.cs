using ACMLib.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMLib.Framework.Solutions
{
    public class CalculateNSubtraction : ITest
    {
        private readonly Dictionary<char, int> charIntDictionary = new Dictionary<char, int>()
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'a', 10 },
            { 'b', 11 },
            { 'c', 12 },
            { 'd', 13 },
            { 'e', 14 },
            { 'f', 15 },
            { 'g', 16 },
            { 'h', 17 },
            { 'i', 18 },
            { 'j', 19 },
            { 'k', 20 },
            { 'l', 21 },
            { 'm', 22 },
            { 'n', 23 },
            { 'o', 24 },
            { 'p', 25 },
            { 'q', 26 },
            { 'r', 27 },
            { 's', 28 },
            { 't', 29 },
            { 'u', 30 },
            { 'v', 31 },
            { 'w', 32 },
            { 'x', 33 },
            { 'y', 34 },
            { 'z', 35 }
        };

        public dynamic TestMain()
        {
            int nBase = 16; //int.Parse(IO.ReadLine());
            string string1 = "100"; //"1234567890";
            string string2 = "fff"; //"abcdefghij";

            var result = NSubtraction(nBase, string1, string2);
            return result;
        }

        public dynamic NSubtraction(int nBase, string minuend, string subtrahend)
        {
            if (!IsVaild(nBase, minuend, subtrahend))
            {
                return -1;
            }

            if ((minuend.Length == subtrahend.Length) && minuend.Equals(subtrahend))
            {
                return new NSubtractionResult(0, "0");
            }

            int sign;
            string resultString;
            var max = Math.Max(minuend.Length, subtrahend.Length);
            if (minuend.Length < subtrahend.Length)
            { 
                sign = 1;
                resultString = Calculate(nBase, subtrahend, minuend.PadLeft(max, '0'));
            } else if (minuend.Length > subtrahend.Length)
            {
                sign = 0;
                resultString = Calculate(nBase, minuend, subtrahend.PadLeft(max, '0'));
            }
            else
            {
                var comparison = String.Compare(minuend, subtrahend);
                if (comparison < 0)
                {
                    sign = 1;
                    resultString = Calculate(nBase, subtrahend, minuend);
                }
                else
                {
                    sign = 0;
                    resultString = Calculate(nBase, minuend, subtrahend);
                }
            }

            return new NSubtractionResult(sign, resultString);
        }

        private string Calculate(int nBase, string minuend, string subtrahend)
        {
            var resultChars = new char[minuend.Length];

            // 从最好一位开始计算
            int carry = 0;
            int difference = 0;
            for (int i = minuend.Length - 1; i >= 0; i--)
            {
                var x = CharToInt(minuend[i]);
                var y = CharToInt(subtrahend[i]);

                if (x >= y)
                {
                    difference = x - carry - y;
                    carry = 0;
                }
                else
                {
                    difference = x + nBase - carry - y;
                    carry = 1;
                }

                var currentChar = IntToChar(difference);
                resultChars[i] = currentChar;
            }

            if (resultChars[0] == '0')
            {
                return new string(resultChars).TrimStart('0');
            }
            else
            {
                return new string(resultChars);
            }
        }

        private int CharToInt(char index) => charIntDictionary[index];
        private char IntToChar(int index) => charIntDictionary.Keys.ElementAt(index);
        
        private static bool IsVaild(int nBase, string minuend, string subtrahend)
        {
            if (nBase < 2 || nBase > 35)
            {
                return false;
            }

            if (IsStartWithZero(minuend) || IsStartWithZero(subtrahend))
            {
                return false;
            }

            if (!IsStringWithInRange(minuend, nBase) || !IsStringWithInRange(subtrahend , nBase))
            {
                return false;
            }

            return true;
        }

        private static bool IsStringWithInRange(string text, int nBase)
        {
            foreach (var letter in text)
            {
                if (!IsCharWithInRange(letter, nBase))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsCharWithInRange(char letter, int nBase)
        {
            if (nBase <= 10)
            {
                var maxCharASCII = '0' + nBase;
                return (letter >= '0' && letter <= (char)maxCharASCII);
            }
            else
            {
                var maxCharASCII = 'a' + nBase;
                return (letter >= '0' && letter <= '9') || (letter >= 'a' && letter <= (char)maxCharASCII);
            }
             
        }

        private static bool IsStartWithZero(string text) => text[0] == '0';

        public struct NSubtractionResult
        {
            public int Sign;
            public string Result;

            public NSubtractionResult(int sign, string result)
            {
                Sign = sign;
                Result = result;
            }

            public override string ToString()
            {
                return $"{Sign} {Result}";
            }
        }
    }

    public class IO
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
    }

}
