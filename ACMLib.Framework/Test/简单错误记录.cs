using ACMLib.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMLib.Framework.Test
{
    public class 简单错误记录 : ITest
    {
        public const int Length = 8;
        public void Main()
        {
            var line = IO.ReadInputLine();
            var errorList = GetFileNameAndIndex(line);

            var result = GetErrorCount(errorList);

            if (result.Count >= 8)
            {
                for (int i = result.Count - 8; i < result.Count; i++)
                {
                    var current = result.ElementAt(i);
                    var error = $"{current.Key} {current.Value}";

                    Console.WriteLine(line);
                }
            }
        }

        private Dictionary<string,int> GetErrorCount(IList<FileNameAndIndex> errorList)
        {
            var result = new Dictionary<string, int>();
            for (int i = 0; i < Length; i++)
            {
                var current = errorList[i];
                var key = $"{current.FileName} {current.LineIndex}";
                if (result.ContainsKey(key))
                {
                    result[key] += 1;
                }
                else
                {
                    result.Add(key, 1);
                }
            }

            return result;
        }

        public static IList<FileNameAndIndex> GetFileNameAndIndex(string path)
        {
            var result = new List<FileNameAndIndex>();
            var builder = new StringBuilder();
            for (int i = path.Length -1; i >= 0; i--)
            {
                var current = path[i];

                if (IsSeparetor(current))
                {
                    var nameAndIndex = builder.ToString().Split(' ');
                    result.Add(new FileNameAndIndex(nameAndIndex[0], nameAndIndex[1]));
                }
                else
                {
                    builder.Append(current);
                }
            }

            return result;
        }

        public struct FileNameAndIndex
        {
            public string FileName;
            public int LineIndex;

            public FileNameAndIndex(string name, string lineIndex)
            {
                if (name.Length > 16)
                {
                    FileName = name.Substring(name.Length - 16);
                }
                else
                {
                    FileName = name;
                }
                
                LineIndex = int.Parse(lineIndex);
            }
        }

        private static bool IsSeparetor(char item) => item == '\\';
    }
}
