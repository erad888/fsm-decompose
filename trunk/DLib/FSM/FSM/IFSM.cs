using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicUtils;

namespace FSM
{
    public interface IFSM<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        FSMState<TInput, TOutput>[] StateSet { get; }
        
        TOutput[] OutputSet { get; }
        TInput[] InputSet { get; }
        Type OutputType { get; }
        Type InputType { get; }

        TOutput ProcessInput(TInput input);
        TOutput ProcessInput(FSMState<TInput, TOutput> state, TInput input);
        FSMState<TInput, TOutput> CurrentState { get; set; }

        FSMState<TInput, TOutput> Sigma(FSMState<TInput, TOutput> state, TInput input, double p);
        TOutput Lambda(FSMState<TInput, TOutput> state, TInput input, double p);

        void Randomize();
    }
}
