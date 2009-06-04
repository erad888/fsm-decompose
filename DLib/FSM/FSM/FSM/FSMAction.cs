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
            : this(actionCore, fromState)
        {
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="actionCore">Суть действия</param>
        /// <param name="fromState">Откуда ведёт дуга</param>
        public FSMAction(TInput actionCore, FSMState<TInput, TOutput> fromState)
        {
            if (actionCore == null) throw new ArgumentNullException("actionCore");
            if (fromState == null) throw new ArgumentNullException("fromState");
            FromState = fromState;
            ActionCore = actionCore;
        }

        public bool AddTransitionRes(FSMState<TInput, TOutput> destState, TOutput output, double probability)
        {
            if (destState == null) throw new ArgumentNullException("destState");

            if ((probability <= 0) || (probability > 1)) throw new ArgumentException("Probability must be in (0;1]", "probability");

            double available = 0;
            foreach (var pair in SubTransitions)
            {
                available += pair.Value;
            }

            if (probability + available > 1) throw new ArgumentException("Sum probability must be in (0;1]", "probability");

            bool result = false;
            var transRes = new TransitionRes<TInput, TOutput>()
            {
                DestState = destState,
                Output = output
            };
            if (!SubTransitions.ContainsKey(transRes))
            {
                SubTransitions.Add(transRes, probability);
                result = true;
            }
            return result;
        }

        public TransitionRes<TInput, TOutput> GetTransRes(double probability)
        {
            TransitionRes<TInput, TOutput> result = null;
            double sum = 0.0;
            foreach (var pair in SubTransitions)
            {
                if ((probability >= sum) && (probability <= sum + pair.Value))
                {
                    result = pair.Key;
                    break;
                }
                sum += pair.Value;
            }
            return result;
        }

        private Dictionary<TransitionRes<TInput, TOutput>, double> SubTransitions = new Dictionary<TransitionRes<TInput, TOutput>, double>();

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
        //public FSMState<TInput, TOutput> ToState { get; private set; }
        /// <summary>
        /// Выходной символ
        /// </summary>
        //public TOutput Output { get; private set; }

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
        internal FSMState<TInput, TOutput> DoTransition(out TOutput output, double probability)
        {
            var trR = GetTransRes(probability);

            NotifyTransitionPerformed(FromState, trR.DestState, trR.Output);
            output = trR.Output;
            return trR.DestState;
        }
    }


    public class TransitionRes<TInput, TOutput> : IStringKeyable
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        public TransitionRes()
        {
            
        }

        public TransitionRes(Transition<TInput, TOutput> Transition)
        {
            this.Transition = Transition;
        }

        public FSMState<TInput, TOutput> DestState { get; set; }
        public TOutput Output { get; set; }
        public double Probability { get; set; }

        public Transition<TInput, TOutput> Transition { get; set; }

        public bool RemoveFromTransition()
        {
            if (Transition == null)
                throw new NullReferenceException("Transition");

            bool result = false;
            if (Transition.destinationStates.Contains(this))
            {
                result = Transition.destinationStates.Remove(this);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            var other = obj as TransitionRes<TInput, TOutput>;
            if (other == null)
                return false;
            return KeyName == other.KeyName;
        }

        public override int GetHashCode()
        {
            return KeyName.GetHashCode();
        }

        public override string ToString()
        {
            return "(" + DestState.StateCore + ", " + Output.KeyName + ") - " + Probability;
        }

        #region Implementation of IStringKeyable

        public string KeyName
        {
            get { return DestState.StateCore + Output.KeyName; }
        }

        #endregion
    }
}
