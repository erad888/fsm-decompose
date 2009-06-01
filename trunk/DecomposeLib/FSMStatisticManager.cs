using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSM;

namespace DecomposeLib
{
    public class FSMStatisticManager<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        public FSMStatisticManager(FiniteStateMachine<TInput, TOutput> fsm)
        {
            TargetFSM = fsm;
        }

        public FiniteStateMachine<TInput, TOutput> TargetFSM { get; set; }

        public StatisticsResult<TInput, TOutput> CollectStatistics(StatisticCollectCondition<TInput, TOutput> conditions)
        {
            if(conditions == null)
                throw new ArgumentNullException("conditions");
            if(conditions.InitialState == null)
                throw new ArgumentNullException("conditions.InitialState");
            if (TargetFSM.StateSet.FirstOrDefault(s => s.StateCore == conditions.InitialState.StateCore) == null)
                throw new ArgumentException("Не совместимое начальное состояние", "conditions.InitialState");

            StatisticsResult<TInput, TOutput> result = new StatisticsResult<TInput, TOutput>();
            for (int i = 0; i < conditions.RepeatsNumber; ++i)
            {
                TargetFSM.InitialState = conditions.InitialState;
                for (int j = 0; j < conditions.InputSequence.Count; ++j)
                {

                }
            }
            return result;
        }
    }

    public class StatisticCollectCondition<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        public StatisticCollectCondition()
        {
            InputSequence = new List<TInput>();
        }
        public StatisticCollectCondition(IEnumerable<TInput> inputSequence):this()
        {
            InputSequence.AddRange(inputSequence);
        }
        public List<TInput> InputSequence { get; private set; }
        public FSMState<TInput, TOutput> InitialState { get; set; }
        public int RepeatsNumber
        {
            get { return repeatsNumber; }
            set
            {
                if (value < 0)
                    throw new ArithmeticException("Число повторений должно быть положительным");

                repeatsNumber = value;
            }
        }
        private int repeatsNumber = 0;
    }

    public class StatisticsResult<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        public StatisticsResult()
        {
            TimeStamp = DateTime.Now;
            InputCollection = new List<TInput>();
            OutputFrequency = new Dictionary<TOutput, int>();
            StateFrequency = new Dictionary<FSMState<TInput, TOutput>, int>();
        }

        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<TInput> InputCollection { get; private set; }
        public Dictionary<TOutput, int> OutputFrequency { get; private set; }
        public Dictionary<FSMState<TInput, TOutput>, int> StateFrequency { get; private set; }
    }
}
