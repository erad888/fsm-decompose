using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    public class FSMTransitionEventArgs<TInput, TOutput> : EventArgs
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        public FSMTransitionEventArgs(FSMState<TInput, TOutput> fromState, FSMState<TInput, TOutput> toState):
            this(fromState, toState, null)
        {
        }

        public FSMTransitionEventArgs(FSMState<TInput, TOutput> fromState, FSMState<TInput, TOutput> toState, TOutput output)
        {
            FromState = fromState;
            ToState = toState;
            Output = output;
        }

        public FSMState<TInput, TOutput> FromState { get; private set; }
        public FSMState<TInput, TOutput> ToState { get; private set; }
        public TOutput Output { get; private set; }
    }
}
