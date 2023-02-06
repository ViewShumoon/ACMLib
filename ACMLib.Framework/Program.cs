

using ACMLib.Framework.Solutions;

namespace ACMLib.Framework
{
    public class Program
    {
        static void Main()
        {
            var test = new CalculateNSubtraction();
            var result = test.TestMain();
            System.Console.WriteLine(result);

            System.Console.ReadKey();
        }
    }
}
