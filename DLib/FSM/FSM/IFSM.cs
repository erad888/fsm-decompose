﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    public interface IFSM<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        FSMState<TInput, TOutput>[] StateSet { get; }
        
        //FSMAtomBase[] OutputSet { get; }
        TInput[] InputSet { get; }
        //Type OutputType { get; }
        //Type InputType { get; }

        TOutput ProcessInput(TInput input);
        TOutput ProcessInput(FSMState<TInput, TOutput> state, TInput input);
        FSMState<TInput, TOutput> CurrentState { get; }
    }
}