using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    public class FSMNet<TInput, TOutput>: IFSM
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        #region
        public class NetComponent
        {
            public ComponentFSM<TInput, TOutput> FiniteStateMachine { get; set; }
            public FuncKsi Ksi {get; set;}
            public FuncF F{get; set;}
        }
        public delegate object FuncKsi(TInput input);
        public delegate object FuncF(params object[] As);
        public delegate TOutput FuncG(params object[] As);
        #endregion

        private HashSet<TOutput> outputSet = new HashSet<TOutput>();
        private HashSet<TInput> inputSet = new HashSet<TInput>();
        private Dictionary<int, NetComponent> componentFSMs = new Dictionary<int, NetComponent>();
        public FuncG G { get; set; }
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
            throw new NotImplementedException();
        }

        #region IFSM<TInput,TOutput> Members

        public FSMAtomBase[] OutputSet
        {
            get { throw new NotImplementedException(); }
        }

        public FSMAtomBase[] InputSet
        {
            get { throw new NotImplementedException(); }
        }

        public Type OutputType
        {
            get { throw new NotImplementedException(); }
        }

        public Type InputType
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
