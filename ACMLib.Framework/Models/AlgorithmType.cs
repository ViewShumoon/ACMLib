using System;

namespace ACMLib.Framework.Models
{
    [Flags]
    public enum AlgorithmType
    {
        未指定 = 0,
        哈希 = 1,
        回溯 = 2,
        动态规划 = 4,
        贪心 = 8,
        模拟 = 16
    }
}
