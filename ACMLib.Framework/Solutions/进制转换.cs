using ACMLib.Framework.Attribute;
using ACMLib.Framework.Models;


namespace ACMLib.Framework.Solutions
{
    [SolutionType(Models.DataStructureType.字符串)]
    public class 进制转换 : ITest
    {
        public void Main()
        {
            var line = IO.ReadLine();
            var hexString = line.Substring(2);
            var result = System.Int32.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
            System.Console.WriteLine(result);
        }
    }
}
