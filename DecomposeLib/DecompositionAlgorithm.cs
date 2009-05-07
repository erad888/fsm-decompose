using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSM;
using LogicUtils;

namespace DecomposeLib
{
    public class DecompositionAlgorithm<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        public DecompositionAlgorithm(FiniteStateMachine<TInput, TOutput> fsm, IEnumerable<Partition<FSMState<TInput, TOutput>>> partitions)
        {
            FSM = fsm;
            PIs = new Dictionary<int, Partition<FSMState<TInput, TOutput>>>();
            int i = 0;
            foreach (var partition in partitions)
            {
                PIs.Add(i, partition);
                ++i;
            }
        }

        public FiniteStateMachine<TInput, TOutput> FSM { get; private set; }
        private Dictionary<int, Partition<FSMState<TInput, TOutput>>> PIs = null;
        private Dictionary<int, Partition<FSMState<TInput, TOutput>>> EPSs = new Dictionary<int, Partition<FSMState<TInput, TOutput>>>();
        private Dictionary<int, Partition<FSMState<TInput, TOutput>>> TAUs = new Dictionary<int, Partition<FSMState<TInput, TOutput>>>();
        private Dictionary<int, Partition<TInput>> Ns = new Dictionary<int, Partition<TInput>>();
        List<List<HashSet<FSMState<TInput, TOutput>>>> TTs = new List<List<HashSet<FSMState<TInput, TOutput>>>>();

        private HashSet<FSMState<TInput, TOutput>> F(FSMState<TInput, TOutput> a, TInput z, Partition<FSMState<TInput,TOutput>> pi)
        {
            return pi.GetBlock(FSM.Sigma(a, z));
        }
        private void SolveTAUs()
        {
            foreach (var pi in PIs)
            {
                Partition<FSMState<TInput, TOutput>> p = new Partition<FSMState<TInput, TOutput>>();
                p.DivideIntoBlocks(FSM.StateSet, (a) =>
                                                     {
                                                         string result = string.Empty;
                                                         foreach (var z in FSM.InputSet)
                                                         {
                                                             result += F(a, z, pi.Value).ToString();
                                                         }
                                                         return string.Empty;
                                                     }
                    );
                TAUs.Add(pi.Key, p);
            }
            if (PIs.Count != TAUs.Count)
                throw new ArithmeticException();
        }
        private void SolveNs()
        {
            foreach (var pi in PIs)
            {
                Partition<TInput> p = new Partition<TInput>();
                p.DivideIntoBlocks(FSM.InputSet, (z) =>
                                                     {
                                                         string result = string.Empty;
                                                         foreach (var a in FSM.StateSet)
                                                         {
                                                             result += F(a, z, pi.Value).ToString();
                                                         }
                                                         return result;
                                                     }
                    );
                Ns.Add(pi.Key, p);
            }
            if (PIs.Count != Ns.Count)
                throw new ArithmeticException();
        }
        private void SolveEPSs()
        {
            List<List<Partition<FSMState<TInput, TOutput>>>> combs =
                (new List<Partition<FSMState<TInput, TOutput>>>(PIs.Values)).GetSubsets();

            foreach (var pi in PIs)
            {
                var tau = TAUs[pi.Key];
                foreach (var comb in combs)
                {
                    if (Partition<FSMState<TInput, TOutput>>.Intersect(comb.ToArray()).LessThen(tau))
                    {
                        var eps = Partition<FSMState<TInput, TOutput>>.Intersect(
                                comb.Except(new[] { pi.Value }).ToArray());
                        if (!eps.IsEmpty)
                        {
                            EPSs.Add(
                                pi.Key,
                                eps
                                );
                            break;
                        }
                    }
                }
            }
            if(PIs.Count != EPSs.Count)
                throw new ArithmeticException();
        }

        private HashSet<FSMState<TInput, TOutput>> Sigma(
            int i,
            HashSet<FSMState<TInput, TOutput>> alpha,
            HashSet<FSMState<TInput, TOutput>> beta,
            HashSet<TInput> gamma)
        {
            HashSet<FSMState<TInput, TOutput>> r = alpha;
            if (!EPSs[i].IsEmpty)
            {
                r = new HashSet<FSMState<TInput, TOutput>>(alpha.Intersect(beta));
                if (r.Count == 0)
                    return null;
            }
            return PIs[i].GetBlock(FSM.Sigma(r.First(), gamma.First()));
        }

        private void SolveTTs(IEnumerable<Partition<FSMState<TInput, TOutput>>> pis)
        {
            List<List<HashSet<FSMState<TInput, TOutput>>>> Ts = fRec(pis);
            foreach (var t in Ts)
            {
                HashSet<FSMState<TInput, TOutput>> ti = t.Intersect();
                if (ti.Count > 0)
                {
                    TTs.Add(t);
                }
            }
        }

        private HashSet<FSMState<TInput, TOutput>> Fi(IEnumerable<HashSet<FSMState<TInput, TOutput>>> ts, int i)
        {
            HashSet<FSMState<TInput, TOutput>> result = null;
            HashSet<FSMState<TInput, TOutput>> tIntersect = ts.Intersect();
            if (tIntersect.Count > 0)
            {
                result = EPSs[i].FirstOrDefault(b => tIntersect.IsSubsetOf(b));
            }
            return result;
        }

        private List<List<HashSet<FSMState<TInput, TOutput>>>> fRec(IEnumerable<Partition<FSMState<TInput, TOutput>>> items)
        {
            List<List<HashSet<FSMState<TInput, TOutput>>>> result = new List<List<HashSet<FSMState<TInput, TOutput>>>>();
            if (items.Count() > 0)
            {
                List<List<HashSet<FSMState<TInput, TOutput>>>> a = fRec(items.Skip(1));
                foreach (var hashSet in items.First())
                {
                    foreach (var innerArray in a)
                    {
                        List<HashSet<FSMState<TInput, TOutput>>> newLst = new List<HashSet<FSMState<TInput, TOutput>>>(innerArray);
                        newLst.Add(hashSet);
                        result.Add(newLst);
                    }
                }
            }
            return result;
        }
    }
}
