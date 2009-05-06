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
        public class ComponentFSM
        {
            public FSM FiniteStateMachine { get; set; }
            public FuncKsi Ksi {get; set;}
            public FuncF F{get; set;}
        }
        public delegate object FuncKsi(TInput input);
        public delegate object FuncF(params object[] As);
        public delegate TOutput FuncG(params object[] As);
        #endregion

        private HashSet<TOutput> outputSet = new HashSet<TOutput>();
        private HashSet<TInput> inputSet = new HashSet<TInput>();
        private List<ComponentFSM> componentFSMs = new List<ComponentFSM>();
        public FuncG G { get; set; }

        public bool AddComponent(FSM finiteStateMachine, FuncKsi ksi, FuncF f)
        {
            bool result = true;
            return result;
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
