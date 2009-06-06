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



            //var z1 = new StructAtom<string>("z1");

            //var w1 = new StructAtom<string>("w1");
            //var w2 = new StructAtom<string>("w2");
            //var w3 = new StructAtom<string>("w3");

            //FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsmA = new FiniteStateMachine<StructAtom<string>, StructAtom<string>>();
            //var a1 = new FSMState<StructAtom<string>, StructAtom<string>>(fsmA, States.a1);
            //var a2 = new FSMState<StructAtom<string>, StructAtom<string>>(fsmA, States.a2);
            //var a3 = new FSMState<StructAtom<string>, StructAtom<string>>(fsmA, States.a3);
            //fsmA.AddOutgoing(a1, z1, a2, w1);
            //fsmA.AddOutgoing(a2, z1, a3, w2);
            //fsmA.AddOutgoing(a3, z1, a1, w3);

            //FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsmB = new FiniteStateMachine<StructAtom<string>, StructAtom<string>>();
            //var b1 = new FSMState<StructAtom<string>, StructAtom<string>>(fsmB, States.b1);
            //var b2 = new FSMState<StructAtom<string>, StructAtom<string>>(fsmB, States.b2);
            //var b3 = new FSMState<StructAtom<string>, StructAtom<string>>(fsmB, States.b3);
            //fsmB.AddOutgoing(b1, z1, b3, w1);
            //fsmB.AddOutgoing(b3, z1, b2, w2);
            //fsmB.AddOutgoing(b2, z1, b1, w3);

            //var res = fsmA.IsIsomorphic(fsmB);
            //if(res != null)
            //    PrintCorrespondences(res);

            var z1 = new StructAtom<string>("z1");
            var z2 = new StructAtom<string>("z2");
            var z3 = new StructAtom<string>("z3");
            var z4 = new StructAtom<string>("z4");


            var w1 = new StructAtom<string>("w1");
            var w2 = new StructAtom<string>("w2");
            var w3 = new StructAtom<string>("w3");

            FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsm =
                new FiniteStateMachine<StructAtom<string>, StructAtom<string>>("b");

            var a1 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a1);
            var a2 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a2);
            var a3 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a3);
            var a4 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a4);
            var a5 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a5);
            var a6 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a6);

            fsm.AddState(a1);
            fsm.AddState(a2);
            fsm.AddState(a3);
            fsm.AddState(a4);
            fsm.AddState(a5);
            fsm.AddState(a6);

            //fsm.AddOutgoing(a1, z1, a1, w2, 0.5);
            fsm.AddOutgoing(a1, z1, a2, w1, 0.5);
            fsm.AddOutgoing(a1, z2, a6, w2);
            fsm.AddOutgoing(a1, z3, a6, w1);
            fsm.AddOutgoing(a1, z4, a2, w3);

            fsm.AddOutgoing(a2, z1, a5, w2);
            fsm.AddOutgoing(a2, z2, a1, w1);
            fsm.AddOutgoing(a2, z3, a1, w1);
            fsm.AddOutgoing(a2, z4, a5, w3);

            fsm.AddOutgoing(a3, z1, a1, w1);
            fsm.AddOutgoing(a3, z2, a5, w3);
            fsm.AddOutgoing(a3, z3, a5, w1);
            fsm.AddOutgoing(a3, z4, a1, w1);

            fsm.AddOutgoing(a4, z1, a6, w1);
            fsm.AddOutgoing(a4, z2, a2, w2);
            fsm.AddOutgoing(a4, z3, a2, w2);
            fsm.AddOutgoing(a4, z4, a6, w3);

            fsm.AddOutgoing(a5, z1, a1, w3);
            fsm.AddOutgoing(a5, z2, a1, w1);
            fsm.AddOutgoing(a5, z3, a2, w3);
            fsm.AddOutgoing(a5, z4, a4, w1);

            fsm.AddOutgoing(a6, z1, a2, w2);
            fsm.AddOutgoing(a6, z2, a6, w2);
            fsm.AddOutgoing(a6, z3, a5, w3);
            fsm.AddOutgoing(a6, z4, a3, w1);

            fsm.InitialState = a1;

            List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>> pis =
                new List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>>();

            var pi1 = new Partition<FSMState<StructAtom<string>, StructAtom<string>>>();
            pi1.Add(new[]
                        {
                            a1,
                            a2,
                            a3,
                            a4
                        });
            pi1.Add(new[]
                        {
                            a5,
                            a6
                        });

            var pi2 = new Partition<FSMState<StructAtom<string>, StructAtom<string>>>();
            pi2.Add(new[]
                        {
                            a1,
                            a2,
                            a5,
                            a6
                        });
            pi2.Add(new[]
                        {
                            a3,
                            a4
                        });

            var pi3 = new Partition<FSMState<StructAtom<string>, StructAtom<string>>>();
            pi3.Add(new[]
                        {
                            a1,
                            a3,
                            a5
                        });
            pi3.Add(new[]
                        {
                            a2,
                            a4,
                            a6
                        });

            DecompositionAlgorithm<StructAtom<string>, StructAtom<string>> alg =
                new DecompositionAlgorithm<StructAtom<string>, StructAtom<string>>(fsm, new[] {pi1, pi2, pi3});

            var net = alg.Solve();

            ProcessFSM(fsm);
            Console.WriteLine();
            ProcessFSM(net);

            var inputs = new StructAtom<string>[]
                             {
                                 z1,
                                 z2,
                                 z3,
                                 z4,
                                 z4,
                                 z3,
                                 z2,
                                 z1,
                                 z3,
                                 z2,
                                 z4,
                                 z1
                             };

            ProcessFSMLin(inputs, fsm, net);
            fsm.Randomize();
            ProcessFSMLin(inputs, fsm, net);


            HashSet<FSMState<StructAtom<string>, StructAtom<string>>> set = new HashSet<FSMState<StructAtom<string>, StructAtom<string>>>(new []
                                                          {
                                                              a1,
                                                              a2,
                                                              a3,
                                                              a4,
                                                              a5,
                                                              a6
                                                          });
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





            IEnumerable<Partition<FSMState<StructAtom<string>, StructAtom<string>>>> partitions =
                Partition<FSMState<StructAtom<string>, StructAtom<string>>>.GetAllPartitions(set, 2).Where(p => p.Count() >= 2 && p.Count() <= 4);
            List<List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>>> partsLists = Partition<FSMState<StructAtom<string>, StructAtom<string>>>.
                GetAllOrtPartitionSets(
                Partition<FSMState<StructAtom<string>, StructAtom<string>>>.FilterSamePartitions(partitions).ToArray(),
                new[] {pi1, pi2},
                set,
                2,
                3);
            //Console.WriteLine(Partition<FSMState<StructAtom<string>, StructAtom<string>>>.GetAllPartitions(set,1).Count().ToString());
            foreach (var partsList in partsLists.Take(100))
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
            Console.ReadKey();
        }

        private static void ProcessFSM<TInput, TOutput>(IFSM<TInput, TOutput> fsm)
            where TInput : FSMAtomBase, IStringKeyable
            where TOutput : FSMAtomBase, IStringKeyable
        {
            Console.WriteLine();
            Console.Write("\t");

            foreach (var state in fsm.StateSet)
            {
                Console.Write("{0}\t", state.StateCore.ToString());
            }

            Console.WriteLine();

            foreach (var input in fsm.InputSet)
            {
                Console.Write("{0}\t", input.KeyName);
                foreach (var state in fsm.StateSet)
                {
                    Console.Write("{0}({1})\t", fsm.ProcessInput(state, input), fsm.CurrentState);
                }
                Console.WriteLine();
            }
        }

        private static void ProcessFSMLin<TInput, TOutput>(TInput[] inputs, params IFSM<TInput, TOutput>[] fsms)
            where TInput : FSMAtomBase, IStringKeyable
            where TOutput : FSMAtomBase, IStringKeyable
        {
            Console.WriteLine();
            //Console.Write("\t{0}");
            //foreach (var fsm in fsms)
            //{
            //    Console.Write("{0}\t", fsm.);
            //}
            foreach (var input in inputs)
            {
                Console.Write("{0}\t", input);
                foreach (var fsm in fsms)
                {
                    var s = fsm.CurrentState;
                    Console.Write("({0}){1}({2})\t", s, fsm.ProcessInput(input), fsm.CurrentState);
                }
                Console.WriteLine();
            }
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

        private enum StateCores
        {
            a1 = 0,
            a2,
            a3,
            a4,
            a5,
            a6,
        }
    }
}
