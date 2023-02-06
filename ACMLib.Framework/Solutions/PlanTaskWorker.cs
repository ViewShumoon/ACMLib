
using ACMLib.Framework.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ACMLib.Framework.Solutions
{

    public class PlanTaskWorker : ITest, IGreed
    {
        public dynamic TestMain()
        {
            int[] tasks = { 3, 2, 1 };
            int[] workers = { 0, 3, 3 };
            int pills = 1;
            int pillStrength = 1;

            var count = this.MaxTaskAssign(tasks, workers, pills, pillStrength);
            return count;
        }

        public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
        {
            tasks = tasks.OrderBy(t => t).ToArray();
            //workers = workers.OrderDescending().ToArray();
            workers = workers.OrderByDescending(w => w).ToArray();

            // 二分答案
            int count = -1;
            int low = 0;
            int high = Math.Min(tasks.Length, workers.Length);
            while (low < high)
            {
                var mid = (low + high) / 2;

                var currentTasks = tasks.Take(mid).ToArray();
                var currentWorkers = workers.Take(mid).ToArray();
                if (IsTaskCanBeDone(currentTasks, currentWorkers, pills, strength))
                {
                    count = mid;
                    low = mid;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return count;
        }

        private static bool IsTaskCanBeDone(int[] tasks, int[] workers, int pills, int pillStrength)
        {
            var currentTasks = tasks.ToList();

            foreach (var worker in workers)
            {
                if (worker >= currentTasks.First())
                {
                    currentTasks.RemoveAt(0);
                }
                else
                {
                    if (pills == 0)
                    {
                        return false;
                    }
                    else
                    {
                        pills--;
                    }

                    var index = currentTasks.BinarySearch(worker + pillStrength, new WorkerComparer());
                    if (index < 0)
                    {
                        return false;
                    }

                    currentTasks.RemoveAt(index);
                }

            }

            return true;
        }

        private static int GetMedian(int low, int high) => low + ((high - low) >> 1);
    }

    public class WorkerComparer : IComparer<int>
    {
        public int Compare(int worker, int require)
        {
            if (worker < require) return -1;
            if (worker == require) return 0;

            return 1;
        }
    }
}
