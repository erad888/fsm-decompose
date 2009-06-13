using System.Collections.Generic;
using LogicUtils;

namespace FSM
{
    public interface IDecompositionAlg<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        HashSet<FSMState<TInput, TOutput>> F(int i, IEnumerable<HashSet<FSMState<TInput, TOutput>>> ts);
        HashSet<TInput> Ksi(int i, TInput input);
        HashSet<FSMState<TInput, TOutput>> Sigma(
            int i,
            HashSet<FSMState<TInput, TOutput>> alpha,
            HashSet<FSMState<TInput, TOutput>> beta,
            HashSet<TInput> gamma);
        TOutput G(IEnumerable<HashSet<FSMState<TInput, TOutput>>> ts, TInput input);

        FSMNet<TInput, TOutput> Solve();
        void AddPI(Partition<FSMState<TInput, TOutput>> pi);
        void RefreshWorkSets();

        FiniteStateMachine<TInput, TOutput> FSM { get; }
        Partition<FSMState<TInput, TOutput>>[] OrtPartitionsSet { get; }
        Dictionary<int, Partition<FSMState<TInput, TOutput>>> PIs { get; }
    }
}