using ACMLib.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMLib.Framework.Solutions
{
    public class 移除重复字符 : ITest
    {
        public void Main()
        {
            string text = "acbbcad";

            var result = GetMinStringLen(text);
        }

        public int GetMinStringLen(string text)
        {
            if (!IsVaild(text))
            {
                return 0;
            }

            var charStack = new Stack<char>();

            foreach (var current in text)
            {
                if (charStack.Count == 0 || charStack.Peek() != current)
                {
                    charStack.Push(current);
                }
                else
                {
                    charStack.Pop();
                }
            }

            return charStack.Count;
        }

        private bool IsVaild(string text)
        {
            foreach (var letter in text)
            {
                if (!IsWithInRange(letter))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsWithInRange(char letter) => ('a' <= letter && letter <= 'z') || ('A' <= letter && letter <= 'Z');
    }
}
