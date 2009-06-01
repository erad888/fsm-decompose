using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSM;

namespace DecomposeLib
{
    /// <summary>
    /// Менеджер сбора статистики для конечного атвомата
    /// </summary>
    /// <typeparam name="TInput">Тип входных символов автомата</typeparam>
    /// <typeparam name="TOutput">Тип выходных символов автомата</typeparam>
    public class FSMStatisticManager<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="fsm">Конечный автомат для исследования</param>
        public FSMStatisticManager(IFSM<TInput, TOutput> fsm)
        {
            TargetFSM = fsm;
        }

        /// <summary>
        /// Целевой автомат, для которого нужно собрать статситику
        /// </summary>
        public IFSM<TInput, TOutput> TargetFSM { get; set; }

        /// <summary>
        /// Собрать статистику
        /// </summary>
        /// <param name="conditions">Условия сбора статистики</param>
        /// <returns>Результаты сбора статистики</returns>
        public StatisticsResult<TInput, TOutput> CollectStatistics(StatisticCollectCondition<TInput, TOutput> conditions)
        {
            if(conditions == null)
                throw new ArgumentNullException("conditions");
            if(conditions.InitialState == null)
                throw new ArgumentNullException("conditions.InitialState");
            if (TargetFSM.StateSet.FirstOrDefault(s => s.StateCore == conditions.InitialState.StateCore) == null)
                throw new ArgumentException("Не совместимое начальное состояние", "conditions.InitialState");

            StatisticsResult<TInput, TOutput> result = new StatisticsResult<TInput, TOutput>(conditions);

            for (int i = 0; i < conditions.RepeatsNumber; ++i)
            {
                TargetFSM.InitialState = conditions.InitialState;
                result.ProcessData(TargetFSM.CurrentState);
                for (int j = 0; j < conditions.InputSequence.Count; ++j)
                {
                    TOutput output = TargetFSM.ProcessInput(conditions.InputSequence[j]);
                    result.ProcessData(TargetFSM.CurrentState, output);
                }
            }
            return result;
        }
    }

    /// <summary>
    /// Условия сбора статистики
    /// </summary>
    /// <typeparam name="TInput">Тип входных символов автомата</typeparam>
    /// <typeparam name="TOutput">Тип выходных символов автомата</typeparam>
    public class StatisticCollectCondition<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public StatisticCollectCondition()
        {
            InputSequence = new List<TInput>();
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="inputSequence">Число повторений эксперимента</param>
        public StatisticCollectCondition(IEnumerable<TInput> inputSequence):this()
        {
            InputSequence.AddRange(inputSequence);
        }
        /// <summary>
        /// Входная последовательность символов
        /// </summary>
        public List<TInput> InputSequence { get; private set; }
        /// <summary>
        /// Начальное состояние
        /// </summary>
        public FSMState<TInput, TOutput> InitialState { get; set; }
        /// <summary>
        /// Число повторений эксперимента
        /// </summary>
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
    /// <summary>
    /// Результаты сбора статистики
    /// </summary>
    /// <typeparam name="TInput">Тип входных символов автомата</typeparam>
    /// <typeparam name="TOutput">Тип выходных символов автомата</typeparam>
    public class StatisticsResult<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="conditions">Условия проведения эксперимента</param>
        public StatisticsResult(StatisticCollectCondition<TInput, TOutput> conditions)
        {
            TimeStamp = DateTime.Now;
            Conditions = conditions;
            OutputFrequency = new Dictionary<TOutput, int>();
            StateFrequency = new Dictionary<FSMState<TInput, TOutput>, int>();
            RejectionCount = 0;
        }
        /// <summary>
        /// Имя результата
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата проведения эксперимента
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// Условия проведения эксперимента
        /// </summary>
        public StatisticCollectCondition<TInput, TOutput> Conditions{ get; private set; }
        /// <summary>
        /// Частотный словарь выходных символов за всё время проведения исследования
        /// </summary>
        public Dictionary<TOutput, int> OutputFrequency { get; private set; }
        /// <summary>
        /// Частотный словарь состояний автомата за всё время проведения исследования
        /// </summary>
        public Dictionary<FSMState<TInput, TOutput>, int> StateFrequency { get; private set; }
        /// <summary>
        /// Число отказов (несрабатываний) автомата
        /// </summary>
        public int RejectionCount { get; private set; }

        /// <summary>
        /// Обработать данные
        /// </summary>
        /// <param name="state">Состояние автомата</param>
        public void ProcessData(FSMState<TInput, TOutput> state)
        {
            if (!StateFrequency.ContainsKey(state))
                StateFrequency.Add(state, 1);
            ++StateFrequency[state];
        }
        /// <summary>
        /// Обработать данные
        /// </summary>
        /// <param name="output">Выходной символ автомата</param>
        public void ProcessData(TOutput output)
        {
            if (!OutputFrequency.ContainsKey(output))
                OutputFrequency.Add(output, 1);
            ++OutputFrequency[output];
        }
        /// <summary>
        /// Обработать данные
        /// </summary>
        /// <param name="state">Состояние автомата</param>
        /// <param name="output">Выходной символ автомата</param>
        public void ProcessData(FSMState<TInput, TOutput> state, TOutput output)
        {
            if (output != null)
            {
                ProcessData(state);
                ProcessData(output);
            }
            else
                ++RejectionCount;
        }
    }
}
