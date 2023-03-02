using ACMLib.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMLib.Framework.Solutions
{
    public class 实现简易内存池 : ITest
    {
        public int Count = 100;

        private Dictionary<int, int> pool = new Dictionary<int, int>();

        private const int ADDRESS_START = 0;
        private const int ADDRESS_END = 99;
        private const string STATE_ERROR = "error";

        public void Main()
        {
            throw new NotImplementedException();
        }

        public dynamic Request(int size)
        {
            if (size <= 0 || size > Count)
            {
                return STATE_ERROR;
            }

            int result = 0;
            foreach (var range in pool)
            {
                if (result + size < range.Key)
                {
                    pool.Add(result, result + size);
                    return result;
                }
                else
                {
                    result = range.Value;
                }
            }

            return STATE_ERROR;
        }
        public dynamic Release(int address)
        {
            if (address <= 0 || address > Count)
            {
                return STATE_ERROR;
            }

            if (pool.ContainsKey(address))
            {
                pool.Remove(address);
                return null;
            }

            return STATE_ERROR;
        }

        
        private static string ReadLine()
        {
            string line;
            do
            {
                line = Console.ReadLine();
            } while (string.IsNullOrEmpty(line));

            return line;
        }
    }
}
