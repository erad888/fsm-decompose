using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    /// <summary>
    /// Действие/дуга
    /// </summary>
    public class FSMAction<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="actionCore">Суть действия</param>
        /// <param name="fromState">Откуда ведёт дуга</param>
        /// <param name="toState">Куда ведёт дуга</param>
        public FSMAction(TInput actionCore, FSMState<TInput, TOutput> fromState, FSMState<TInput, TOutput> toState)
            : this(actionCore, fromState, toState, null)
        {
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="actionCore">Суть действия</param>
        /// <param name="fromState">Откуда ведёт дуга</param>
        /// <param name="toState">Куда ведёт дуга</param>
        /// <param name="output">Выходной символ</param>
        public FSMAction(TInput actionCore, FSMState<TInput, TOutput> fromState, FSMState<TInput, TOutput> toState, TOutput output)
        {
            if (actionCore == null) throw new ArgumentNullException("actionCore");
            if (fromState == null) throw new ArgumentNullException("fromState");
            if (toState == null) throw new ArgumentNullException("toState");

            if (fromState.FSM == toState.FSM)
            {
                FromState = fromState;
                ToState = toState;
                ActionCore = actionCore;
                Output = output;
            }
        }

        /// <summary>
        /// Ключевое имя действия
        /// </summary>
        public string Name
        {
            get
            {
                return ActionCore.KeyName;
            }
        }
        /// <summary>
        /// Суть действия
        /// </summary>
        public TInput ActionCore { get; private set; }
        /// <summary>
        /// Начало дуги
        /// </summary>
        public FSMState<TInput, TOutput> FromState { get; private set; }
        /// <summary>
        /// Конец дуги
        /// </summary>
        public FSMState<TInput, TOutput> ToState { get; private set; }
        /// <summary>
        /// Выходной символ
        /// </summary>
        public TOutput Output { get; private set; }

        /// <summary>
        /// Осуществлён переход
        /// </summary>
        public event EventHandler<FSMTransitionEventArgs<TInput, TOutput>> TransitionPerformed;
        protected void NotifyTransitionPerformed(FSMState<TInput, TOutput> From, FSMState<TInput, TOutput> To, TOutput output)
        {
            if (TransitionPerformed != null)
            {
                TransitionPerformed(this, new FSMTransitionEventArgs<TInput, TOutput>(From, To, output));
            }
        }

        /// <summary>
        /// Осуществить переход по дуге
        /// </summary>
        /// <returns>Куда перешли</returns>
        internal FSMState<TInput, TOutput> DoTransition(out TOutput output)
        {
            if (ToState == null)
                throw new NullReferenceException("ToState");
            NotifyTransitionPerformed(FromState, ToState, Output);
            output = Output;
            return ToState;
        }
    }

}
