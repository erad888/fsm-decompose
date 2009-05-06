using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicUtils
{
    public static class ArrayExtensions
    {
        public static bool IsSubsetOf<T>(this IEnumerable<T> array, IEnumerable<T> other)
        {
            bool result = true;
            foreach (var item in array)
            {
                result = other.Contains(item);
                if(!result)
                    break;
            }
            return result;
        }

        private static List<HashSet<T>> gen<T>(T[] set, T[] subset, int rest, int start, int subsetSize)
        {
            List<HashSet<T>> result = new List<HashSet<T>>();
            if (rest == 0)
                result.Add(new HashSet<T>(subset));
            else
            {
                for (int i = start; i < set.Length - rest + 1; ++i)
                {
                    subset[subsetSize - rest] = set[i];
                    result.AddRange(gen(set, subset, rest - 1, i + 1, subsetSize));
                }
            }
            return result;
        }
        private static List<List<T>> genLst<T>(T[] set, T[] subset, int rest, int start, int subsetSize)
        {
            List<List<T>> result = new List<List<T>>();
            if (rest == 0)
                result.Add(new List<T>(subset));
            else
            {
                for (int i = start; i < set.Length - rest + 1; ++i)
                {
                    subset[subsetSize - rest] = set[i];
                    result.AddRange(genLst(set, subset, rest - 1, i + 1, subsetSize));
                }
            }
            return result;
        }
        public static List<List<T>> GetSubsets<T>(this List<T> set, int k)
        {
            return genLst(set.ToArray(), new T[k], k, 0, k);
        }
        public static List<HashSet<T>> GetSubsets<T>(this HashSet<T> set, int k)
        {
            return gen(set.ToArray(), new T[k], k, 0, k);
        }
        public static List<List<T>> GetSubsets<T>(this List<T> set, int minSubsetSize, int maxSubsetSize)
        {
            if (minSubsetSize >= maxSubsetSize) throw new ArgumentException("min >= max");
            if (minSubsetSize < 1) throw new ArgumentException("min is too low (<1)");
            if (maxSubsetSize > set.Count()) throw new ArgumentException("max is too high (> elements count)");
            List<List<T>> result = new List<List<T>>();
            for (int i = minSubsetSize; i <= maxSubsetSize; i++)
            {
                result.AddRange(set.GetSubsets(i));
            }
            return result;
        }
        public static List<List<T>> GetSubsets<T>(this List<T> set)
        {
            return set.GetSubsets(1, set.Count);
        }

        public static List<HashSet<T>> GetSubsets<T>(this HashSet<T> set, int minSubsetSize, int maxSubsetSize)
        {
            if (minSubsetSize >= maxSubsetSize) throw new ArgumentException("min >= max");
            if (minSubsetSize < 1) throw new ArgumentException("min is too low (<1)");
            if (maxSubsetSize > set.Count()) throw new ArgumentException("max is too high (> elements count)");
            List<HashSet<T>> result = new List<HashSet<T>>();
            for (int i = minSubsetSize; i <= maxSubsetSize; i++)
            {
                result.AddRange(set.GetSubsets(i));
            }
            return result;
        }
        public static List<HashSet<T>> GetSubsets<T>(this HashSet<T> set)
        {
            return set.GetSubsets(1, set.Count);
            //List<HashSet<T>> result = new List<HashSet<T>>();
            //for (int i = 1; i <= set.Count; i++)
            //{
            //    result.AddRange(set.GetSubsets(i));
            //}
            //return result;
        }
        public static bool AreSame<T>(this HashSet<T> set, HashSet<T> otherSet)
        {
            bool result = set.Count == otherSet.Count;
            if (result)
            {
                foreach (var t in set)
                {
                    if (!otherSet.Contains(t))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        //public static bool IsSubsetOf(this Array array, Array other)
        //{
        //    bool result = true;
        //    foreach (var item in array)
        //    {
        //        bool finded = false;
        //        foreach (var otherItem in other)
        //        {
        //            if (otherItem.Equals(item))
        //            {
        //                finded = true;
        //                break;
        //            }
        //        }
        //        if (!finded)
        //        {
        //            result = false;
        //            break;
        //        }
        //    }
        //    return result;
        //}
    }
}
