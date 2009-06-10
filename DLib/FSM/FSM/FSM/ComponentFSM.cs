using System;
using System.Collections.Generic;
using System.Linq;
using LogicUtils;

namespace FSM
{
    public class ComponentFSM<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        #region Constructors

        public ComponentFSM(IDecompositionAlg<TInput, TOutput> alg, Partition<FSMState<TInput, TOutput>> pi, FSMState<TInput, TOutput> initialState, int orderNumber)
        {
            OrderNumber = orderNumber;
            DecomposeAlg = alg;
            PI = pi;
            InitialState = initialState;
        }

        #endregion

        #region Properties
        public int OrderNumber { get; private set; }
        internal IDecompositionAlg<TInput, TOutput> DecomposeAlg { get; set; }

        public Partition<FSMState<TInput, TOutput>> PI { get; private set; }
        public HashSet<FSMState<TInput, TOutput>> CurrentState
        {
            get { return currentState; }
            set
            {
                if (PI == null)
                    throw new NullReferenceException();

                //var stateBlock = PI.FirstOrDefault(b => b.Except(value).Count() > 0);
                var stateBlock = PI.FirstOrDefault(b => b.Except(value).Count() == 0);
                if (stateBlock != null)
                {
                    //currentState = value;
                    currentState = stateBlock;
                }
                else
                {
                }
                if(!stateBlock.AreSame(value))
                {
                }
            }
        }
        private HashSet<FSMState<TInput, TOutput>> currentState = null;
        public FSMState<TInput, TOutput> InitialState
        {
            get { return initialState; }
            set
            {
                if (PI == null)
                    throw new NullReferenceException();

                var stateBlock = PI.FirstOrDefault(b => b.Contains(value));
                if (stateBlock != null)
                {
                    initialState = value;
                    CurrentState = stateBlock;
                }
                else
                {
                }
            }
        }
        private FSMState<TInput, TOutput> initialState = null;
        #endregion

        #region Fields

        #endregion

        #region Methods
        public HashSet<FSMState<TInput, TOutput>> Sigma(HashSet<FSMState<TInput, TOutput>> stateSet, HashSet<TInput> inputSet)
        {
            return DecomposeAlg.Sigma(OrderNumber, CurrentState, stateSet, inputSet);
        }

        #endregion
    }
}