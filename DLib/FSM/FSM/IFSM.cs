using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    public interface IFSM/*<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable*/
    {
        //FSMState<TInput, TOutput>[] StateSet { get; }
        FSMAtomBase[] OutputSet { get; }
        FSMAtomBase[] InputSet { get; }
        Type OutputType { get; }
        Type InputType { get; }
    }
}
