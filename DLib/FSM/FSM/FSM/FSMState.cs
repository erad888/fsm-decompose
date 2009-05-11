using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{

    /// <summary>
    /// Состояние КА
    /// </summary>
    public class FSMState<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="fsm">КА</param>
        /// <param name="stateCore">Суть события</param>
        public FSMState(FiniteStateMachine<TInput, TOutput> fsm, Enum stateCore)
        {
            if (fsm == null) throw new ArgumentNullException("fsm");

            FSM = fsm;
            StateCore = stateCore;
            FSM.AddState(this);
        }

        /// <summary>
        /// Суть события
        /// </summary>
        public Enum StateCore { get; private set; }
        /// <summary>
        /// КА
        /// </summary>
        public FiniteStateMachine<TInput, TOutput> FSM { get; private set; }
        /// <summary>
        /// Исходящие дуги
        /// </summary>
        internal Dictionary<string, FSMAction<TInput, TOutput>> Outgoing = new Dictionary<string, FSMAction<TInput, TOutput>>();                

        /// <summary>
        /// Добавить исходящую дугу
        /// </summary>
        /// <param name="action">Суть действия, характеризующего дугу</param>
        /// <param name="destinationState">Состояние, в которое ведёт дуга</param>
        internal bool AddOutgoing(TInput action, FSMState<TInput, TOutput> destinationState)
        {
            return AddOutgoing(action, destinationState, null);
        }
        /// <summary>
        /// Добавить исходящую дугу
        /// </summary>
        /// <param name="action">Суть действия, характеризующего дугу</param>
        /// <param name="destinationState">Состояние, в которое ведёт дуга</param>
        /// <param name="output">Выходной элемент автомата</param>
        internal bool AddOutgoing(TInput action, FSMState<TInput, TOutput> destinationState, TOutput output)
        {
            return AddOutgoing(action, destinationState, output, 1.0);
        }

        internal bool AddOutgoing(TInput action, FSMState<TInput, TOutput> destinationState, TOutput output, double probability)
        {
            var act = new FSMAction<TInput, TOutput>(action, this);
            act.AddTransitionRes(destinationState, output, probability);
            bool result = false;
            if (!Outgoing.ContainsKey(act.Name))
            {
                if (output != null)
                    FSM.AddOutput(output);
                if (action != null)
                    FSM.AddInput(action);
                Outgoing.Add(act.Name, act);
                result = true;
            }
            else
            {
                Outgoing[act.Name].AddTransitionRes(destinationState, output, probability);
            }
            return result;
        }

        /// <summary>
        /// Возможен ли переход?
        /// </summary>
        /// <param name="initialEvent">Пока что будем принимать экшен, но, вообще по уму, нужно разделить понятия экшена и эвента,
        /// т.к. в общем случае они могут не совпадать</param>
        /// <returns></returns>
        public bool CanTransit(TInput initialEvent)
        {
            return Outgoing.ContainsKey(initialEvent.KeyName);
        }
        /// <summary>
        /// Переход в другое состояние
        /// </summary>
        /// <param name="initialEvent"></param>
        /// <exception cref="IndexOutOfRangeException">Переход невозможен</exception>
        /// <returns>В какое состояние перешлт</returns>
        public FSMState<TInput, TOutput> Transit(TInput initialEvent, out TOutput output, double probabilityLevel)
        {
            var key = initialEvent.KeyName;
            if (!Outgoing.ContainsKey(key))
                throw new IndexOutOfRangeException("initialEvent");
            return Outgoing[key].DoTransition(out output, probabilityLevel);
        }

        public override bool Equals(object obj)
        {
            var other = obj as FSMState<TInput, TOutput>;
            if(other == null)
                return false;

            return StateCore.Equals(other.StateCore);
        }

        public override int GetHashCode()
        {
            return StateCore.GetHashCode();
        }

        public override string ToString()
        {
            return StateCore.ToString();
        }
    }
}
