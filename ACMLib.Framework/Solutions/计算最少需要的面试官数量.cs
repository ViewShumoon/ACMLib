
using ACMLib.Framework.Attribute;
using ACMLib.Framework.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ACMLib.Framework.Solutions
{
    [SolutionType(AlgorithmType = AlgorithmType.贪心)]
    public class 计算最少需要的面试官数量 : ITest
    {
        public void Main()
        {
            int maxCharge = 2;//int.Parse(IO.GetLine());
            int interviewCount = 4;//int.Parse(IO.GetLine());
            var intervalList = new int[][] //ReadInputIntervals(interviewCount);
            {
                new int[]{ 1, 2 },
                new int[]{ 3, 5 },
                new int[]{ 4, 7 },
                new int[]{ 6, 8 },
            };

            var count = MinInterviewers(maxCharge, interviewCount, intervalList);
            System.Console.WriteLine(count);
        }

        public int MinInterviewers(int maxCharge, int interviewCount, int[][] intervals)
        {
            var intervalOrdered = intervals.OrderBy(item => item[0]).Select(i => new Interval
            {
                StartTime_InHour = i[0],
                EndTime_InHour = i[1]
            }).ToArray();

            var intervalList = new SortedList<int, int>
            {
                { intervalOrdered[0].EndTime_InHour, 1}
            };
            for (int i = 1; i < intervalOrdered.Length; i++)
            {
                foreach (var current in intervalList)
                {
                    if ((current.Key <= intervalOrdered[i].StartTime_InHour) && (current.Value < maxCharge))
                    {

                    }
                }
                //var current = intervalList.First();
                //if (current.Value <= intervalOrdered[i].StartTime_InHour)
                //{
                //    intervalList.RemoveAt(0);
                //    intervalList.Add(intervalOrdered[i].StartTime_InHour, intervalOrdered[i].EndTime_InHour);
                //}
                //else
                //{
                //    intervalList.Add(intervalOrdered[i].StartTime_InHour, intervalOrdered[i].EndTime_InHour);
                //}
            }

            return intervalList.Count;
        }

        private static int[][] ReadInputIntervals(int count)
        {
            var result = new int[count][];

            for (int i = 0; i <= count; i++)
            {
                var hours = ACMLib.Framework.Common.IO.ReadLine().Split(' ');

                result[i] = new int[2]
                {
                    int.Parse(hours[0]),
                    int.Parse(hours[1])
                };
            }

            return result;
        }

        public struct Interval
        {
            public int StartTime_InHour;
            public int EndTime_InHour;
        }

        public struct Interview : IComparable<Interview>, IEquatable<Interview>
        {
            public int StartTime_InHour;
            public int EndTime_InHour;
            public bool IsCollide(Interview other) => this.EndTime_InHour < other.StartTime_InHour;

            public int CompareTo(Interview other)
            {
                if (this.EndTime_InHour < other.StartTime_InHour) return -1;
                if (this.Equals(other)) return 0;
                //if (this.StartTime_InHour > other.EndTime_InHour) 
                return 1;
            }

            public bool Equals(Interview other) => this.StartTime_InHour == other.StartTime_InHour && this.EndTime_InHour == other.EndTime_InHour;

            public override string ToString() => $"{{{StartTime_InHour}, {EndTime_InHour}}}";

        }
    }
}
