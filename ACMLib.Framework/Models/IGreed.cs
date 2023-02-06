using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMLib.Framework.Models
{
    // 基本思路：
    // 1.建立数学模型来描述问题。
    // 2.把求解的问题分成若干个子问题。
    // 3.对每个子问题求解，得到每个子问题的局部最优解。
    // 4.把每个子问题的局部最优解合成为原来问题的一个解。
    
    // 实现该算法的过程：
    // 从问题的某一初始状态出发；
    // while 能朝给定总目标前进一步 do
    // 求出可行解的一个解元素；
    // 由所有解元素组合成问题的一个可行解；

    public interface IGreed
    {

    }
}
