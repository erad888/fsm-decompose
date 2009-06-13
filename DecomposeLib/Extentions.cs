using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSM;
using LogicUtils;

namespace DecomposeLib
{
    public static class Extentions
    {
        public static double SimpleCriteria(this Partition<FSMState<StructAtom<string>, StructAtom<string>>> partition)
        {
            int N = partition.UnionOfParts().Count;
            return partition.Select(b => b.AsEnumerable()).SimpleCriteria(N);
        }

        public static double SimpleCriteria(this List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>> partitions)
        {
            if (partitions.Count == 0)
                return 0;

            double sum = 0;
            foreach (var partition in partitions)
            {
                sum += partition.SimpleCriteria();
            }
            return sum / partitions.Count;
        }

        public static double SimpleCriteria<T>(this IEnumerable<IEnumerable<T>> partition, double N)
        {
            double n = partition.Count();

            if (n == 0)
                return 0;

            double avr = (double)N / n;

            double res = 0;
            foreach (var block in partition)
            {
                res += Math.Abs(avr - block.Count());
            }

            double max = 2 * (n * N - n * n + n - N) / n;

            return (res / max) * 100;
        }
    }
}
