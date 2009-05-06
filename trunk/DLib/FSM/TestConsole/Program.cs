using System;
using System.Collections.Generic;
using System.Linq;
using DecomposeLib;
using FSM;
using LogicUtils;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //As.Add(new StateInfo("a1"));
            //As.Add(new StateInfo("a2"));
            //As.Add(new StateInfo("a3"));

            //Bs.Add(new StateInfo("b1"));
            //Bs.Add(new StateInfo("b2"));
            //Bs.Add(new StateInfo("b3"));

            //Rec(As, Bs, Correspondences);

            var z1 = new StructAtom<string>("z1");

            var w1 = new StructAtom<string>("w1");
            var w2 = new StructAtom<string>("w2");
            var w3 = new StructAtom<string>("w3");

            FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsmA = new FiniteStateMachine<StructAtom<string>, StructAtom<string>>();
            var a1 = new FSMState<StructAtom<string>, StructAtom<string>>(fsmA, States.a1);
            var a2 = new FSMState<StructAtom<string>, StructAtom<string>>(fsmA, States.a2);
            var a3 = new FSMState<StructAtom<string>, StructAtom<string>>(fsmA, States.a3);
            fsmA.AddOutgoing(a1, z1, a2, w1);
            fsmA.AddOutgoing(a2, z1, a3, w2);
            fsmA.AddOutgoing(a3, z1, a1, w3);

            FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsmB = new FiniteStateMachine<StructAtom<string>, StructAtom<string>>();
            var b1 = new FSMState<StructAtom<string>, StructAtom<string>>(fsmB, States.b1);
            var b2 = new FSMState<StructAtom<string>, StructAtom<string>>(fsmB, States.b2);
            var b3 = new FSMState<StructAtom<string>, StructAtom<string>>(fsmB, States.b3);
            fsmB.AddOutgoing(b1, z1, b3, w1);
            fsmB.AddOutgoing(b3, z1, b2, w2);
            fsmB.AddOutgoing(b2, z1, b1, w3);

            var res = fsmA.IsIsomorphic(fsmB);
            if(res != null)
                PrintCorrespondences(res);

            Console.ReadKey();
        }

        private static void PrintCorrespondences(FiniteStateMachine<StructAtom<string>, StructAtom<string>>.IsomorphicInfo info)
        {
            Console.WriteLine("Состояния:");
            foreach (var statePair in info.StatesCorrespondence)
            {
                Console.WriteLine("{0} - {1}", statePair.Key, statePair.Value);
            }
            Console.WriteLine();

            Console.WriteLine("Входы:");
            foreach (var inputPair in info.InputCorrespondence)
            {
                Console.WriteLine("{0} - {1}", inputPair.Key, inputPair.Value);
            }
            Console.WriteLine();

            Console.WriteLine("Выходы:");
            foreach (var outputPair in info.OutputCorrespondence)
            {
                Console.WriteLine("{0} - {1}", outputPair.Key, outputPair.Value);
            }
            Console.WriteLine("----------");



            HashSet<int> set = new HashSet<int>(new int[] {1, 2, 3, 4, 5, 6});
            var res = set.GetSubsets();
            foreach (var re in res)
            {
                foreach (var i in re)
                {
                    Console.Write(" {0}", i);
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------");


            IEnumerable<Partition<int>> partitions = Partition<int>.GetAllPartitions(set, 2).Where(p => p.Count() >= 2 && p.Count() <= 4);
            List<List<Partition<int>>> partsLists = Partition<int>.GetAllOrtPartitionSets(Partition<int>.FilterSamePartitions(partitions).ToArray(), set, 2, 3);
            foreach (var partsList in partsLists)
            {
                foreach (var partition in partsList)
                {
                    foreach (var hashSet in partition)
                    {
                        foreach (var item in hashSet)
                        {
                            Console.Write("{0}", item);
                        }
                        Console.Write(" ");
                    }
                    Console.Write("\t");
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
        }

        private static void Rec(List<StateInfo> As, List<StateInfo> Bs, BidirectionalDictionary<StateInfo, StateInfo> Correspondences)
        {
            if (As.Count > 0)
            {
                var a = As[0];
                var b = a.GetFirst(Bs);
                if (b != null)
                {
                    //Console.WriteLine("{0} - {1}", a, b);
                    Correspondences.AddAssociation(a, b);
                    Rec(new List<StateInfo>(As.Skip(1)), new List<StateInfo>(Bs.Where(s => s.State != b.State)), Correspondences);
                    a.Rejected.Add(b.State);
                    Correspondences.RemoveAssociationFirst(a);
                    foreach (var aa in As.Skip(1))
                    {
                        aa.Rejected.Clear();
                    }
                    Rec(As, Bs, Correspondences);
                }
            }
            else
            {
                Console.WriteLine("--------");
                foreach (var pair in Correspondences)
                {
                    Console.WriteLine("{0} - {1}", pair.Key.State, pair.Value.State);
                }
                Console.WriteLine("--------");
            }
        }

        private static List<StateInfo> As = new List<StateInfo>();
        private static List<StateInfo> Bs = new List<StateInfo>();

        private static BidirectionalDictionary<StateInfo, StateInfo> Correspondences = new BidirectionalDictionary<StateInfo, StateInfo>();

        private class StateInfo
        {
            public StateInfo(string state)
            {
                State = state;
            }
            public string State = string.Empty;
            public List<string> Rejected = new List<string>();

            public StateInfo GetFirst(IEnumerable<StateInfo> Potential)
            {
                return Potential.FirstOrDefault(s => !Rejected.Contains(s.State));
            }

            public override string ToString()
            {
                return State;
            }
        }

        private enum States
        {
            a1,
            a2,
            a3,
            b1,
            b2,
            b3,
        }
    }
}
