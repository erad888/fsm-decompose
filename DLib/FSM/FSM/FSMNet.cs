﻿using System;
using System.Collections.Generic;
using System.Linq;
using FSM.FSMInfos;
using LogicUtils;

namespace FSM
{
    public class FSMNet<TInput, TOutput> : INetComponentInfosContainer, IFSM<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        #region
        public class NetComponent : FSM, IInformable
        {
            public NetComponent(ComponentFSM<TInput, TOutput> componentFSM)
            {
                if (componentFSM == null) throw new ArgumentNullException("componentFSM");

                FiniteStateMachine = componentFSM;
            }

            public ComponentFSM<TInput, TOutput> FiniteStateMachine { get; private set; }


            public virtual HashSet<TInput> Ksi(TInput input)
            {
                return FiniteStateMachine.DecomposeAlg.Ksi(FiniteStateMachine.OrderNumber, input);
            }
            public virtual HashSet<FSMState<TInput, TOutput>> F(IEnumerable<HashSet<FSMState<TInput, TOutput>>> stateSets)
            {
                return FiniteStateMachine.DecomposeAlg.F(FiniteStateMachine.OrderNumber, stateSets);
            }

            #region Implementation of IInformable

            public FSMInfo Info
            {
                get
                {
                    if (info == null)
                        info = new FSMInfo(this, No.ToString());
                    ++No;
                    return info;
                }
            }

            private FSMInfo info = null;

            public static int No = 0;

            #endregion
        }
        public delegate object FuncKsi(TInput input);
        public delegate object FuncF(params object[] As);
        public delegate TOutput FuncG(params object[] As);
        #endregion

        public FSMNet(FiniteStateMachine<TInput, TOutput> fsm)
        {
            this.FSM = fsm;

            NetComponent.No = 0;
        }

        private HashSet<TOutput> outputSet = new HashSet<TOutput>();
        private HashSet<TInput> inputSet = new HashSet<TInput>();
        public Dictionary<int, NetComponent> componentFSMs = new Dictionary<int, NetComponent>();

        private TOutput G(IEnumerable<HashSet<FSMState<TInput, TOutput>>> states, TInput input)
        {
            TOutput result = null;
            if (componentFSMs.Count > 0)
                result = componentFSMs.First().Value.FiniteStateMachine.DecomposeAlg.G(states, input);
            return result;
        }

        public FiniteStateMachine<TInput, TOutput> FSM { get; set; }
        public IDecompositionAlg<TInput, TOutput> DecomposeAlg { get; set; }

        public FSMState<TInput, TOutput> InitialState { get; set; }

        public void AddToEnd(NetComponent fsm)
        {
            if (fsm == null)
                throw new ArgumentNullException("fsm");
            if (componentFSMs.ContainsKey(fsm.FiniteStateMachine.OrderNumber))
                throw new ArgumentException();

            componentFSMs.Add(fsm.FiniteStateMachine.OrderNumber, fsm);
        }

        public TOutput ProcessInput(TInput input)
        {
            if (FSM.IsProbabilityMachine)
                componentFSMs.First().Value.FiniteStateMachine.DecomposeAlg.RefreshWorkSets();

            Dictionary<int, HashSet<FSMState<TInput, TOutput>>> componentOutputs = new Dictionary<int, HashSet<FSMState<TInput, TOutput>>>();
            for (int i = 0; i < componentFSMs.Count; i++)
            {
                // Вроде так должно быть
                componentOutputs.Add(i, componentFSMs[i].FiniteStateMachine.CurrentState);
            }

            Dictionary<int, HashSet<FSMState<TInput, TOutput>>> resultComponentsStates = new Dictionary<int, HashSet<FSMState<TInput, TOutput>>>();
            bool hasRejections = false;
            for (int i = 0; i < componentFSMs.Count; i++)
            {
                HashSet<FSMState<TInput, TOutput>> Z = componentFSMs[i].F(componentOutputs.Where(pi => pi.Key != i).Select(pi => pi.Value));
                HashSet<TInput> ZZ = componentFSMs[i].Ksi(input);

                var resultComponentState = componentFSMs[i].FiniteStateMachine.Sigma(Z, ZZ);
                //componentOutputs[i] = resultComponentState;


                //componentFSMs[i].FiniteStateMachine.CurrentState = resultComponentState;
                if (resultComponentState == null)
                {
                    hasRejections = true;
                    break;
                }
                resultComponentsStates.Add(i, resultComponentState);
            }

            TOutput result = null;
            if (!hasRejections)
            {
                foreach (var resultComponentsState in resultComponentsStates)
                {
                    componentFSMs[resultComponentsState.Key].FiniteStateMachine.CurrentState = resultComponentsState.Value;
                }
                result = G(componentOutputs.Values, input);
            }
            return result;
        }

        public TOutput ProcessInput(FSMState<TInput, TOutput> state, TInput input)
        {
            var oldStates = new Dictionary<int, HashSet<FSMState<TInput, TOutput>>>();
            for (int i = 0; i < componentFSMs.Count; i++)
            {
                // Вроде так должно быть
                oldStates.Add(i, componentFSMs[i].FiniteStateMachine.CurrentState);
            }

            foreach (var componentFSM in componentFSMs)
            {
                componentFSM.Value.FiniteStateMachine.InitialState = state;
            }

            var result = ProcessInput(input);

            foreach (var pair in oldStates)
            {
                componentFSMs[pair.Key].FiniteStateMachine.CurrentState = pair.Value;
            }

            return result;
        }

        public FSMState<TInput, TOutput> CurrentState
        {
            get { return componentFSMs.Select(c => c.Value.FiniteStateMachine.CurrentState).Intersect().First(); }
            set
            {
                foreach (var componentFSM in componentFSMs)
                {
                    componentFSM.Value.FiniteStateMachine.InitialState = value;
                }
            }
        }

        #region IFSM<TInput,TOutput> Members

        public FSMState<TInput, TOutput>[] StateSet
        {
            get
            {
                if (componentFSMs.Count > 0)
                {
                    return componentFSMs.First().Value.FiniteStateMachine.DecomposeAlg.FSM.StateSet;
                }
                return new FSMState<TInput, TOutput>[0];
            }
        }
        public TInput[] InputSet
        {
            get
            {
                if (componentFSMs.Count > 0)
                {
                    return componentFSMs.First().Value.FiniteStateMachine.DecomposeAlg.FSM.InputSet;
                }
                return new TInput[0];
            }
        }
        public TOutput[] OutputSet
        {
            get
            {
                if (componentFSMs.Count > 0)
                {
                    return componentFSMs.First().Value.FiniteStateMachine.DecomposeAlg.FSM.OutputSet;
                }
                return new TOutput[0];
            }
        }

        public Type OutputType
        {
            get { return typeof(TOutput); }
        }
        public Type InputType
        {
            get { return typeof(TInput); }
        }

        public FSMState<TInput, TOutput> Sigma(FSMState<TInput, TOutput> state, TInput input, double p)
        {
            throw new NotImplementedException();
        }

        public TOutput Lambda(FSMState<TInput, TOutput> state, TInput input, double p)
        {
            throw new NotImplementedException();
        }

        public void Randomize()
        {
            var c = componentFSMs.Values.FirstOrDefault();
            if (c != null)
            {
                c.FiniteStateMachine.DecomposeAlg.FSM.Randomize();
            }
        }

        public void SetRandomTicket(int seed)
        {
            var c = componentFSMs.Values.FirstOrDefault();
            if (c != null)
            {
                c.FiniteStateMachine.DecomposeAlg.FSM.SetRandomTicket(seed);
            }
        }

        public double Random
        {
            get
            {
                var c = componentFSMs.Values.FirstOrDefault();
                if(c == null)
                    throw new NullReferenceException("FSMNet.Random");
                return c.FiniteStateMachine.DecomposeAlg.FSM.Random;
            }
            set
            {
                var c = componentFSMs.Values.FirstOrDefault();
                if (c == null)
                    throw new NullReferenceException("FSMNet.Random");
                c.FiniteStateMachine.DecomposeAlg.FSM.Random = value;
            }
        }

        #endregion

        #region Implementation of INetComponentInfosContainer

        public IEnumerable<FSMInfo> Components
        {
            get { return componentFSMs.Select(c => c.Value.Info); }
        }

        #endregion
    }
}
