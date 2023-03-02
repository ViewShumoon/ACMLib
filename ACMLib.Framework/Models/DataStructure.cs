using System;

namespace ACMLib.Framework.Models
{
    [Flags]
    public enum DataStructureType
    {
        未指定 = 0,
        数组 = 1,
        字符串 = 2,
        链表 = 4,
        栈 = 8,
        堆 = 16,
        队列 = 32,
        树 = 64,
        图 = 128
    }
}
