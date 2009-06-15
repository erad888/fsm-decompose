using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicUtils;

namespace LogicUtils
{
    public class Partition<T>:IEnumerable<HashSet<T>>
    {
        #region static
        public static Partition<T> GetSingleElementPartition(HashSet<T> set)
        {
            Partition<T> result = new Partition<T>();
            foreach (var element in set)
            {
                result.Add(element);
            }
            return result;
        }
        public static Partition<T> GetMaxElementPartition(HashSet<T> set)
        {
            Partition<T> result = new Partition<T>();
            result.Add(set);
            return result;
        }

        public static IEnumerable<Partition<T>> FilterSamePartitions(IEnumerable<Partition<T>> partitions)
        {
            List<Partition<T>> result = new List<Partition<T>>(partitions);
            int i = 0;
            while (i < result.Count)
            {
                Partition<T> currentOriginal = result[i];
                int j = i + 1;
                while (j < result.Count)
                {
                    if(currentOriginal.AreSame(result[j]))
                        result.RemoveAt(j);
                    ++j;
                }
                ++i;
            }
            return result;
        }

        public static Partition<T> Intersect(Partition<T> firstPartition, Partition<T> secondPartition)
        {
            Partition<T> result = new Partition<T>();
            foreach (var firstBlock in firstPartition.items)
            {
                foreach (var secondBlock in secondPartition.items)
                {
                    var res = firstBlock.Intersect(secondBlock);
                    if (res.Count() > 0)
                        result.Add(res);
                }
            }
            return result;
        }
        public static Partition<T> Intersect(params Partition<T>[] partitions)
        {
            Partition<T> result = new Partition<T>();
            if (partitions.Length > 0)
            {
                result = partitions[0];
                for (int i = 1; i < partitions.Length; i++)
                {
                    result = Intersect(result, partitions[i]);
                }
            }
            return result;
        }

        public static bool IsOrtPartitionSet(params Partition<T>[] partitions)
        {
            var sep = GetSingleElementPartition(partitions[0].UnionOfParts());
            return Intersect(partitions).AreSame(sep);
        }

        public static bool IsOrtPartitionSet(HashSet<T> set, params Partition<T>[] partitions)
        {
            var sep = GetSingleElementPartition(set);
            return Intersect(partitions).AreSame(sep);
        }

        public static List<Partition<T>> GetAllPartitions(HashSet<T> set, int minBlockSize)
        {
            return GetAllPartitionsRec(set, minBlockSize);
        }

        private static List<Partition<T>> GetAllPartitionsRec(HashSet<T> set, int minBlockSize)
        {
            List<Partition<T>> result = new List<Partition<T>>();
            bool isSetIncluded = false;
            if (set.Count == minBlockSize)
                result.Add(new Partition<T>(set));
            else
            {
                List<HashSet<T>> subsets = set.GetSubsets(minBlockSize, set.Count);
                foreach (var subset in subsets)
                {
                    HashSet<T> restSet = new HashSet<T>(set.Except(subset));
                    //
                    if (restSet.Count < minBlockSize)
                    {
                        if (!isSetIncluded)
                        {
                            result.Add(new Partition<T>(set));
                            isSetIncluded = true;
                        }
                        continue;
                    }
                    //
                    List<Partition<T>> innerPartitions = GetAllPartitionsRec(restSet, minBlockSize);
                    foreach (var innerPartition in innerPartitions)
                    {
                        innerPartition.Add(subset);
                        result.Add(innerPartition);
                    }
                }
            }
            return result;
        }

        public static List<List<Partition<T>>> GetAllOrtPartitionSets(Partition<T>[] partitions, HashSet<T> genuieSet, int minPartitionsCountInSet, int maxPartitionsCountInSet)
        {
            if (minPartitionsCountInSet >= maxPartitionsCountInSet) throw new ArgumentException("min >= max");
            if (minPartitionsCountInSet <= 1) throw new ArgumentException("min is too low (<=1)");
            if (maxPartitionsCountInSet >= partitions.Count()) throw new ArgumentException("max is too high (>= elements count)");

            HashSet<Partition<T>> partitionsSet = new HashSet<Partition<T>>(partitions);
            List<List<Partition<T>>> result = new List<List<Partition<T>>>();
            List<List<Partition<T>>> allCombs = new List<List<Partition<T>>>();
            for (int i = minPartitionsCountInSet; i <= maxPartitionsCountInSet; i++)
            {
                allCombs.AddRange(partitionsSet.GetSubsets(i).Select(s => new List<Partition<T>>(s)));
            }
            foreach (var comb in allCombs)
            {
                if(IsOrtPartitionSet(genuieSet, comb.ToArray()))
                    result.Add(comb);
            }
            return result;
        }

        public static List<List<Partition<T>>> GetAllOrtPartitionSets(Partition<T>[] partitions, Partition<T>[] fixedPartitions, HashSet<T> genuieSet, int minPartitionsCountInSet, int maxPartitionsCountInSet)
        {
            if (minPartitionsCountInSet >= maxPartitionsCountInSet) throw new ArgumentException("min >= max");
            //if (minPartitionsCountInSet <= 1) throw new ArgumentException("min is too low (<=1)");
            if (minPartitionsCountInSet < 1) throw new ArgumentException("min is too low (<1)");
            if (maxPartitionsCountInSet >= partitions.Count()) throw new ArgumentException("max is too high (>= elements count)");

            HashSet<Partition<T>> partitionsSet = new HashSet<Partition<T>>(partitions);
            partitionsSet.ExceptWith(fixedPartitions);
            List<List<Partition<T>>> result = new List<List<Partition<T>>>();
            List<List<Partition<T>>> allCombs = new List<List<Partition<T>>>();
            for (int i = minPartitionsCountInSet-fixedPartitions.Length; i <= maxPartitionsCountInSet-fixedPartitions.Length; i++)
            {
                allCombs.AddRange(partitionsSet.GetSubsets(i).Select(s => new List<Partition<T>>(s)));
            }
            foreach (var comb in allCombs)
            {
                var test = new List<Partition<T>>(comb.Union(fixedPartitions));
                if (IsOrtPartitionSet(genuieSet, test.ToArray()))
                    result.Add(test);
            }
            return result;
        }

        //private static List<HashSet<T>> gen(T[] set, T[] subset, int rest, int start, int subsetSize)
        //{
        //    List<HashSet<T>> result = new List<HashSet<T>>();
        //    if(rest == 0)
        //        result.Add(new HashSet<T>(subset));
        //    else
        //    {
        //        for (int i = start; i < set.Length - rest + 1; ++i)
        //        {
        //            subset[subsetSize - rest] = set[i];
        //            result.AddRange(gen(set, subset, rest - 1, i + 1, subsetSize));
        //        }
        //    }
        //    return result;
        //}
        //public static List<HashSet<T>> aaa(HashSet<T> set, int k)
        //{
        //    return gen(set.ToArray(), new T[k], k, 0, k);
        //}

        #endregion

        public Partition()
        {
            
        }

        public Partition(IEnumerable<T> firstSubSet)
        {
            Add(firstSubSet);
        }

        private List<HashSet<T>> items = new List<HashSet<T>>();
        public IEnumerable<T> this[int index]
        {
            get { return items[index].ToArray(); }
        }
        public int GetIndexOfGroup(T element)
        {
            int result = -1;
            for (int i = 0; i < items.Count; ++i)
            {
                if (items[i].Contains(element))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public void DivideIntoBlocks(IEnumerable<T> set, Func<T, string> selector)
        {
            Dictionary<string, List<T>> dict = new Dictionary<string, List<T>>();
            foreach (var item in set)
            {
                string itemKey = selector(item);
                if(!dict.ContainsKey(itemKey))
                    dict.Add(itemKey, new List<T>());
                dict[itemKey].Add(item);
            }

            foreach (var pair in dict)
            {
                items.Add(new HashSet<T>(pair.Value));
            }
        }

        public HashSet<T> GetBlock(T element)
        {
            HashSet<T> result = null;
            for (int i = 0; i < items.Count; ++i)
            {
                if (items[i].Contains(element))
                {
                    result = items[i];
                    break;
                }
            }
            return result;
        }

        public IEnumerable<T> Add(IEnumerable<T> elements)
        {
            var result = new HashSet<T>();
            foreach (var element in elements)
            {
                if (GetIndexOfGroup(element) == -1)
                {
                    result.Add(element);
                }
            }
            if (result.Count > 0)
            {
                items.Add(result);
            }
            return result.ToArray();
        }

        public bool Add(T element)
        {
            bool result = false;
            if (GetIndexOfGroup(element) == -1)
            {
                var newSet = new HashSet<T>();
                newSet.Add(element);
                items.Add(newSet);
                result = true;
            }
            return result;
        }

        public bool Add(int groupIndex, T element)
        {
            if(groupIndex < 0 || groupIndex >= items.Count)
                throw new IndexOutOfRangeException();

            bool result = false;
            if (GetIndexOfGroup(element) == -1)
            {
                items[groupIndex].Add(element);
                result = true;
            }
            return result;
        }

        public bool LessThen(Partition<T> otherPartition)
        {
            bool result = true;
            foreach (var block in items)
            {
                var otherBlock = otherPartition.items.FirstOrDefault(b => block.IsSubsetOf(b));
                if (otherBlock != null)
                {
                    //
                }
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public bool IsEmpty
        {
            get { return items.Count == 0; }
        }

        public HashSet<T> UnionOfParts()
        {
            HashSet<T> result = new HashSet<T>();
            foreach (var item in items)
                result.UnionWith(item);
            return result;
        }

        public bool IsPartitionOf(HashSet<T> set)
        {
            var union = UnionOfParts();
            var result = set.Count == union.Count;
            if (result)
            {
                foreach (var item in set)
                {
                    if (!union.Contains(item))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = string.Empty;

            for (int i = 0; i < items.Count; i++)
            {
                foreach (var t in items[i])
                {
                    result += t.ToString() + " ";
                }
                if (i != items.Count - 1)
                    result += ", ";
            }
            return result;
        }

        public bool AreSame(Partition<T> other)
        {
            bool result = items.Count == other.items.Count;
            if (result)
            {
                foreach (var block in items)
                {
                    if (other.items.FirstOrDefault(hs => hs.AreSame(block)) == null)
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        #region Implementation of IEnumerable

        public IEnumerator<HashSet<T>> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
