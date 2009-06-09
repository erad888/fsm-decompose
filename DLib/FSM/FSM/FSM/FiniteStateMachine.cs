using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LogicUtils;

namespace FSM
{
    public abstract class FSM //: IFSM
    {
    }

    /// <summary>
    /// Конечный автомат
    /// </summary>
    public /*abstract*/ class FiniteStateMachine<TInput, TOutput> : FSM, IFSM<TInput, TOutput>, IStringKeyable
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public FiniteStateMachine(string KeyName)
        {
            this.KeyName = KeyName;
        }

        /// <summary>
        /// Начальное состояние
        /// </summary>
        public FSMState<TInput, TOutput> InitialState
        {
            get { return initialState; }
            set
            {
                initialState = value;
                Reset();
            }
        }
        private FSMState<TInput, TOutput> initialState = null;
        /// <summary>
        /// Текущее состояние
        /// </summary>
        public FSMState<TInput, TOutput> CurrentState { get; set; }

        /// <summary>
        /// Состояние изменилось
        /// </summary>
        public event EventHandler<FSMTransitionEventArgs<TInput, TOutput>> StateChanging;
        protected void NotifyStateChanging(FSMState<TInput, TOutput> fromState, FSMState<TInput, TOutput> toState)
        {
            if (StateChanging != null)
            {
                StateChanging(this, new FSMTransitionEventArgs<TInput, TOutput>(fromState, toState));
            }
        }

        public FSMState<TInput, TOutput>[] StateSet
        {
            get { return stateSet.ToArray(); }
        }
        public TOutput[] OutputSet
        {
            get { return outputSet.ToArray(); }
        }
        public TInput[] InputSet
        {
            get { return inputSet.ToArray(); }
        }
        public Type OutputType
        {
            get { return typeof(TOutput); }
        }
        public Type InputType
        {
            get { return typeof(TInput); }
        }

        private HashSet<FSMState<TInput, TOutput>> stateSet = new HashSet<FSMState<TInput, TOutput>>();
        private HashSet<TOutput> outputSet = new HashSet<TOutput>();
        private HashSet<TInput> inputSet = new HashSet<TInput>();
        /// <summary>
        /// Добавить состояние
        /// </summary>
        /// <param name="state">Состояние</param>
        /// <returns></returns>
        public bool AddState(FSMState<TInput, TOutput> state)
        {
            bool result = false;
            if (state.FSM == this)
            {
                if (stateSet.FirstOrDefault(s => s.StateCore == state.StateCore) == null)
                    result = stateSet.Add(state);
            }
            if(result)
                SyncInitialState();
            return result;
        }

        public bool AddState(object stateCore)
        {
            bool result = false;
            var st = stateSet.FirstOrDefault(s => s.StateCore.Equals(stateCore));
            if (st == null)
            {
                var state = new FSMState<TInput, TOutput>(this, stateCore);
                result = stateSet.FirstOrDefault(s => s.StateCore == stateCore) != null;
            }
            if(result)
                SyncInitialState();
            return result;
        }

        /// <summary>
        /// Добавить выходной символ
        /// </summary>
        /// <param name="output">Выходной символ</param>
        /// <returns></returns>
        public bool AddOutput(TOutput output)
        {
            if (output == null) throw new ArgumentNullException("output");

            bool result = false;

            var value = outputSet.FirstOrDefault(s => s.KeyName == output.KeyName);
            if (value == null)
                result = outputSet.Add(output);

            return result;
        }
        /// <summary>
        /// Добавить входной символ
        /// </summary>
        /// <param name="input">Входной символ</param>
        /// <returns></returns>
        public bool AddInput(TInput input)
        {
            if (input == null) throw new ArgumentNullException("input");
            
            bool result = false;

            var value = inputSet.FirstOrDefault(s => s.KeyName == input.KeyName);
            if (value == null)
                result = inputSet.Add(input);

            return result;
        }

        public bool RemoveInput(string inputKeyName)
        {
            if (string.IsNullOrEmpty(inputKeyName)) throw new ArgumentNullException("inputKeyName");

            var input = inputSet.FirstOrDefault(s => s.KeyName == inputKeyName);
            if (input == null)
                return false;
            return RemoveInput(input);
        }

        public bool RemoveInput(TInput input)
        {
            bool result = false;
            if (inputSet.Contains(input))
            {
                try
                {
                    // Удаляем все переходы, в которых участвует данный входной сигнал
                    var tr = Transitions.Values.FirstOrDefault(t => t.Input.KeyName == input.KeyName);
                    while (tr != null)
                    {
                        Transitions.Remove(tr.ToString());
                        tr = Transitions.Values.FirstOrDefault(t => t.Input.KeyName == input.KeyName);
                    }

                    // Удаляет входной сигнал
                    inputSet.Remove(input);
                    result = true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return result;
        }

        public bool RemoveOutput(string outputKeyName)
        {
            if (string.IsNullOrEmpty(outputKeyName)) throw new ArgumentNullException("outputKeyName");

            var output = outputSet.FirstOrDefault(s => s.KeyName == outputKeyName);
            if (output == null)
                return false;
            return RemoveOutput(output);
        }

        public bool RemoveOutput(TOutput output)
        {
            bool result = false;
            if (outputSet.Contains(output))
            {
                try
                {
                    // Удаляем все переходы, которые ведут к удаляемому символу
                    foreach (var transition in Transitions.Values)
                    {
                        TransitionRes<TInput, TOutput> dest =
                            transition.destinationStates.FirstOrDefault(ds => ds.Output.KeyName == output.KeyName);
                        while (dest != null)
                        {
                            transition.destinationStates.Remove(dest);
                            dest = transition.destinationStates.FirstOrDefault(
                                ds => ds.Output.KeyName == output.KeyName);
                        }
                    }

                    // Чистим пустые переходы
                    var tr = Transitions.Values.FirstOrDefault(t => t.destinationStates.Count == 0);
                    while (tr != null)
                    {
                        Transitions.Remove(tr.ToString());
                        tr = Transitions.Values.FirstOrDefault(t => t.destinationStates.Count == 0);
                    }

                    // Собсно мочим сам выходной символ
                    outputSet.Remove(output);
                    result = true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return result;
        }

        public bool RemoveState(object StateCore)
        {
            var state = stateSet.FirstOrDefault(s => s.StateCore == StateCore);
            if (state == null)
                return false;
            return RemoveState(state);
        }

        public bool RemoveState(FSMState<TInput, TOutput> state)
        {
            bool result = false;
            if (stateSet.Contains(state))
            {
                try
                {
                    // Удаляем все переходы, которые ведут в удаляемое состояние
                    foreach (var transition in Transitions.Values)
                    {
                        TransitionRes<TInput, TOutput> destState =
                            transition.destinationStates.FirstOrDefault(ds => ds.DestState.StateCore == state.StateCore);
                        while (destState != null)
                        {
                            transition.destinationStates.Remove(destState);
                            destState = transition.destinationStates.FirstOrDefault(
                                ds => ds.DestState.StateCore == state.StateCore);
                        }
                    }

                    // Чистим пустые переходы
                    var tr = Transitions.Values.FirstOrDefault(t => t.destinationStates.Count == 0);
                    while (tr != null)
                    {
                        Transitions.Remove(tr.ToString());
                        tr = Transitions.Values.FirstOrDefault(t => t.destinationStates.Count == 0);
                    }

                    // Удаляем все переходы, исходящие из удаляемого состояния
                    var tr1 = Transitions.Values.FirstOrDefault(t => t.SourceState.StateCore == state.StateCore);
                    while (tr1 != null)
                    {
                        Transitions.Remove(tr1.ToString());
                        tr1 = Transitions.Values.FirstOrDefault(t => t.SourceState.StateCore == state.StateCore);
                    }

                    // Собсно мочим само состояние
                    stateSet.Remove(state);
                    state.FSM = null;
                    state.Outgoing.Clear();
                    result = true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            if (result)
                SyncInitialState();
            return result;
        }

        private void SyncInitialState()
        {
            if (!stateSet.Contains(InitialState))
                InitialState = stateSet.FirstOrDefault();
        }

        public bool AddOutgoing(FSMState<TInput, TOutput> sourceState, TInput action, FSMState<TInput, TOutput> destinationState, TOutput output)
        {
            return AddOutgoing(sourceState, action, destinationState, output, 1);
        }

        public bool AddOutgoing(FSMState<TInput, TOutput> sourceState, TInput action, FSMState<TInput, TOutput> destinationState, TOutput output, double probability)
        {
            if ((probability <= 0) || (probability > 1)) throw new ArgumentException("Probability must be in (0;1]", "probability");

            bool result = false;
            var st = stateSet.FirstOrDefault(s => s.StateCore == sourceState.StateCore);
            if (st != null)
            {
                Transition<TInput, TOutput> transition = new Transition<TInput, TOutput>(this)
                {
                    SourceState = sourceState,
                    Input = action,
                    //DestinationState = destinationState,
                    //Output = output
                };
                transition.AddDestination(destinationState, output, probability);
                if (!Transitions.ContainsKey(transition.ToString()))
                {
                    if (st.AddOutgoing(action, destinationState, output, probability))
                    {
                        Transitions.Add(transition.ToString(), transition);
                        result = true;
                    }
                }
                else
                {
                    if (st.AddOutgoing(action, destinationState, output, probability))
                        result = Transitions[transition.ToString()].AddDestination(destinationState, output, probability);
                }
            }
            return result;
        }

        public bool AddOutgoing(FSMState<TInput, TOutput> sourceState, string actionKeyName)
        {
            var input = inputSet.FirstOrDefault(i => i.KeyName == actionKeyName);
            if (input != null)
                return AddOutgoing(sourceState, input);
            return false;
        }

        public bool AddOutgoing(FSMState<TInput, TOutput> sourceState, TInput action)
        {
            bool result = false;
            var st = stateSet.FirstOrDefault(s => s.StateCore == sourceState.StateCore);
            if (st != null)
            {
                Transition<TInput, TOutput> transition = new Transition<TInput, TOutput>(this)
                {
                    SourceState = sourceState,
                    Input = action
                };
                if (!Transitions.ContainsKey(transition.ToString()))
                {
                    Transitions.Add(transition.ToString(), transition);
                    result = true;
                }
            }
            return result;
        }

        public bool AddOutgoing(FSMState<TInput, TOutput> sourceState, TInput action, FSMState<TInput, TOutput> destinationState)
        {
            return AddOutgoing(sourceState, action, destinationState, null);
        }

        public bool AddOutgoing(object sourceState, TInput action, object destinationState, TOutput output)
        {
            var sState = stateSet.FirstOrDefault(s => s.StateCore == sourceState);
            var dState = stateSet.FirstOrDefault(s => s.StateCore == destinationState);

            bool result = false;
            if (sState != null && dState != null)
                result = AddOutgoing(sState, action, dState, output);

            return result;
        }

        public bool AddOutgoing(object sourceState, TInput action, object destinationState)
        {
            return AddOutgoing(sourceState, action, destinationState, null);
        }

        public Dictionary<string, Transition<TInput, TOutput>> Transitions = new Dictionary<string, Transition<TInput, TOutput>>();

        /// <summary>
        /// Возможен ли переход?
        /// </summary>
        /// <param name="initialEvent">Объект для обработки</param>
        /// <returns></returns>
        public bool CanProcessMessage(TInput initialEvent)
        {
            return CurrentState.CanTransit(initialEvent);
        }
        /// <summary>
        /// Обработать сообщение
        /// </summary>
        /// <param name="initialEvent">Объект для обработки</param>
        /// <param name="output">Выход</param>
        /// <returns></returns>
        public bool ProcessMessage(TInput initialEvent, out TOutput output)
        {
            bool result = true;
            TOutput tempOutput = null;
            try
            {
                var oldState = CurrentState;
                var newState = CurrentState.Transit(initialEvent, out tempOutput, random);

                if (newState != null)
                {
                    CurrentState = newState;
                    NotifyStateChanging(oldState, newState);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            output = tempOutput;
            return result;
        }

        public TOutput ProcessInput(TInput input)
        {
            TOutput output = null;
            ProcessMessage(input, out output);
            return output;
        }

        public TOutput ProcessInput(FSMState<TInput, TOutput> state, TInput input)
        {
            var oldState = CurrentState;
            CurrentState = state;
            var result = ProcessInput(input);
            CurrentState = oldState;
            return result;
        }

        public FSMState<TInput, TOutput> Sigma(FSMState<TInput, TOutput> a, TInput z)
        {
            FSMState<TInput, TOutput> result = null;
            var thisA = StateSet.FirstOrDefault(s => s.StateCore == a.StateCore);
            if (thisA == null)
                throw new NullReferenceException();
            if (thisA.Outgoing.ContainsKey(z.KeyName))
            {
                var tr = thisA.Outgoing[z.KeyName].GetTransRes(random);
                if (tr != null)
                    result = tr.DestState;
            }
            return result;
        }

        public TOutput Lambda(FSMState<TInput, TOutput> a, TInput z)
        {
            TOutput result = null;
            var thisA = StateSet.FirstOrDefault(s => s.StateCore == a.StateCore);
            if (thisA == null)
                throw new NullReferenceException();
            if (thisA.Outgoing.ContainsKey(z.KeyName))
            {
                var tr = thisA.Outgoing[z.KeyName].GetTransRes(random);
                if (tr != null)
                    result = tr.Output;
            }
            return result;
        }

        public FSMState<TInput, TOutput> Sigma(FSMState<TInput, TOutput> state, TInput input, double p)
        {
            FSMState<TInput, TOutput> result = null;
            var oldRandom = random;
            random = p;
            result = Sigma(state, input);
            random = oldRandom;
            return result;
        }

        public TOutput Lambda(FSMState<TInput, TOutput> state, TInput input, double p)
        {
            TOutput result = null;
            var oldRandom = random;
            random = p;
            result = Lambda(state, input);
            random = oldRandom;
            return result;
        }


        /// <summary>
        /// Сбросить автомат
        /// </summary>
        protected void Reset()
        {
            CurrentState = InitialState;
        }

        public void Randomize()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            random = rnd.NextDouble();
        }

        private double random = 0;

        public override string ToString()
        {
            return KeyName;
        }

        #region Isomorphic
        public bool IsSubMachineOf(FiniteStateMachine<TInput, TOutput> other)
        {
            //TODO: Проверить
            bool result = false;
            if (this.StateSet.IsSubsetOf(other.StateSet))
            {
                if (this.InputSet.IsSubsetOf(other.InputSet))
                {
                    if (this.OutputSet.IsSubsetOf(other.OutputSet))
                    {
                        bool transitionOk = true;
                        foreach (var a in stateSet)
                        {
                            foreach (var z in inputSet)
                            {
                                var otherTrans = other.Transitions.FirstOrDefault(tr => (tr.Value.SourceState.StateCore == a.StateCore) &&
                                    (tr.Value.Input.KeyName == z.KeyName));
                                var trans = Transitions.FirstOrDefault(tr => (tr.Value.SourceState.StateCore == a.StateCore) &&
                                    (tr.Value.Input.KeyName == z.KeyName));

                                bool flagOut = otherTrans.Value.GetDestination(random).Output.KeyName == trans.Value.GetDestination(random).Output.KeyName;
                                //bool flagSt = otherTrans.Value.DestinationState.StateCore == trans.Value.DestinationState.StateCore;
                                bool flagSt = otherTrans.Value.GetDestination(random).DestState.StateCore == trans.Value.GetDestination(random).DestState.StateCore;
                                transitionOk = flagSt && flagOut;

                                if (!transitionOk)
                                    break;
                            }

                            if (!transitionOk)
                                break;
                        }
                        result = transitionOk;
                    }
                }
            }
            return result;
        }

        public IsomorphicInfo IsIsomorphic(FiniteStateMachine<TInput, TOutput> other)
        {
            BidirectionalDictionary<FSMState<TInput, TOutput>, FSMState<TInput, TOutput>> statesCorrespondence = new BidirectionalDictionary<FSMState<TInput, TOutput>, FSMState<TInput, TOutput>>();
            BidirectionalDictionary<TInput, TInput> inputCorrespondence = new BidirectionalDictionary<TInput, TInput>();
            BidirectionalDictionary<TOutput, TOutput> outputCorrespondence = new BidirectionalDictionary<TOutput, TOutput>();

            // У изоморфных автоматов должно совпадать:
            //      - число состояний
            //      - величина входного алфавита
            //      - величина выходного автомата
            bool resultFlag = this.stateSet.Count == other.stateSet.Count &&
                this.inputSet.Count == other.inputSet.Count &&
                this.outputSet.Count == other.outputSet.Count;

            IsomorphicInfo result = null;

            if (resultFlag)
            {
                EventableDictionary<FSMState<TInput, TOutput>, StateInfo> ThisStatistics =
                    new EventableDictionary<FSMState<TInput, TOutput>, StateInfo>(stateSet.Count);
                EventableDictionary<FSMState<TInput, TOutput>, StateInfo> OtherStatistics =
                    new EventableDictionary<FSMState<TInput, TOutput>, StateInfo>(other.stateSet.Count);

                CalcStats(stateSet, ThisStatistics);
                CalcStats(other.stateSet, OtherStatistics);

                foreach (var statState in ThisStatistics)
                {
                    foreach (var statOtherState in OtherStatistics)
                    {
                        if (statState.Value.InputCount == statOtherState.Value.InputCount &&
                            statState.Value.LoopCount == statOtherState.Value.LoopCount &&
                            statState.Value.OutputCount == statOtherState.Value.OutputCount)
                        {
                            statState.Value.Potential.Add(statOtherState.Key);
                            statOtherState.Value.Potential.Add(statState.Key);
                        }
                    }
                    if (statState.Value.Potential.Count == 0)
                    {
                        // Если у какого-нибудь состояния нет потенциальных вариантов на замену, то наша затея - фигня.
                        resultFlag = false;
                        break;
                    }
                }

                if (resultFlag)
                {
                    result = new IsomorphicInfo();

                    // Запихиваем в соответствия те пары состояний, про которые уже всё понятно
                    foreach (var statItem in ThisStatistics)
                    {
                        if (statItem.Value.Potential.Count == 1)
                        {
                            if (!statesCorrespondence.ExistsFirst(statItem.Key) &&
                                !statesCorrespondence.ExistsSecond(statItem.Value.Potential[0]))
                                statesCorrespondence.AddAssociation(statItem.Key, statItem.Value.Potential[0]);
                            else
                            {
                                result = null;
                                break;
                            }
                        }
                    }

                    if (result != null)
                    {
                        result.As.AddRange(
                            stateSet.Select(
                                s => ThisStatistics.Where(ss => ss.Key.StateCore == s.StateCore).First().Value));
                        result.Bs.AddRange(
                            other.stateSet.Select(
                                s => OtherStatistics.Where(ss => ss.Key.StateCore == s.StateCore).First().Value));
                        result.Zs.AddRange(inputSet.Select(i => new InputInfo(i)));
                        result.Xs.AddRange(other.inputSet.Select(i => new InputInfo(i)));

                        if (!RecursiveInput(
                                 new List<InputInfo>(inputSet.Select(i => new InputInfo(i))),
                                 new List<InputInfo>(other.inputSet.Select(i => new InputInfo(i))),
                                 result))
                        {
                            result = null;
                        }
                    }
                }
            }
            return result;
        }

        private bool RecursiveState(
            List<StateInfo> As,
            List<StateInfo> Bs,
            IsomorphicInfo isomorphicInfo)
        {
            bool result = false;
            if (As.Count > 0)
            {
                var a = As[0];
                var b = a.GetFirstPotential(Bs);
                if (b != null)
                {
                    isomorphicInfo.StatesCorrespondence.AddAssociation(a.State, b.State);
                    result = RecursiveState(new List<StateInfo>(As.Where(s => s.State.StateCore != a.State.StateCore)),//Skip(1)),
                                   new List<StateInfo>(Bs.Where(s => s.State.StateCore != b.State.StateCore)),
                                   isomorphicInfo);
                    if (!result)
                    {
                        a.Rejected.Add(b.State);
                        isomorphicInfo.StatesCorrespondence.RemoveAssociationFirst(a.State);
                        foreach (var aa in As.Skip(1))
                        {
                            aa.Rejected.Clear();
                        }
                        result = RecursiveState(As, Bs, isomorphicInfo);
                    }
                }
            }
            else
            {
                if (isomorphicInfo.StatesCorrespondence.Count() == isomorphicInfo.As.Count)
                {
                    result = CheckCorrespondence(isomorphicInfo);
                }
            }
            return result;
        }

        private bool RecursiveInput(
            List<InputInfo> Zs,
            List<InputInfo> Xs,
            IsomorphicInfo isomorphicInfo)
        {
            bool result = false;
            if (Zs.Count > 0)
            {
                var z = Zs[0];
                var x = z.GetFirst(Xs);
                if (x != null)
                {
                    isomorphicInfo.InputCorrespondence.AddAssociation(z, x);
                    result = RecursiveInput(
                        new List<InputInfo>(Zs.Where(i => i.Input != z.Input)),//.Skip(1)),
                        new List<InputInfo>(Xs.Where(i => i.Input != x.Input)),
                        isomorphicInfo);
                    if (!result)
                    {
                        z.Rejected.Add(x.Input);
                        isomorphicInfo.InputCorrespondence.RemoveAssociationFirst(z);
                        foreach (var zz in Zs.Skip(1))
                        {
                            zz.Rejected.Clear();
                        }
                        result = RecursiveInput(Zs, Xs, isomorphicInfo);
                    }
                }
            }
            else
            {
                result = RecursiveState(
                    isomorphicInfo.As,
                    isomorphicInfo.Bs,
                    isomorphicInfo);
            }
            return result;
        }

        private bool CheckCorrespondence(IsomorphicInfo isomorphicInfo)
        {
            bool result = true;
            foreach (var a in isomorphicInfo.As)
            {
                foreach (var outgoingPair in a.State.Outgoing)
                {
                    var isOk = isomorphicInfo.StatesCorrespondence.GetSecond(outgoingPair.Value.GetTransRes(random).DestState) ==
                               isomorphicInfo.StatesCorrespondence.GetSecond(outgoingPair.Value.FromState).Outgoing.
                                   Where(
                                   o =>
                                   o.Value.ActionCore ==
                                   isomorphicInfo.InputCorrespondence.GetSecond(
                                       new InputInfo(outgoingPair.Value.ActionCore)).Input).FirstOrDefault().Value.GetTransRes(random).DestState;

                    if (isOk)
                    {
                        var w = outgoingPair.Value.GetTransRes(random).Output;
                        var w1 =
                            isomorphicInfo.StatesCorrespondence.GetSecond(a.State).Outgoing.Where(
                                o =>
                                o.Value.ActionCore ==
                                isomorphicInfo.InputCorrespondence.GetSecond(
                                    new InputInfo(outgoingPair.Value.ActionCore)).Input).FirstOrDefault().Value.GetTransRes(random).Output;
                        isomorphicInfo.OutputCorrespondence.AddAssociation(w, w1);
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
                if (!result)
                    break;
            }
            return result;
        }

        private void CalcStats(IEnumerable<FSMState<TInput, TOutput>> states, EventableDictionary<FSMState<TInput, TOutput>, StateInfo> statistics)
        {
            foreach (var state in states)
            {
                StateInfo thisInfo = new StateInfo(state);
                statistics.TryAdd(state, ref thisInfo);
                foreach (var outgoing in state.Outgoing)
                {
                    StateInfo info = new StateInfo(outgoing.Value.GetTransRes(random).DestState);
                    var destState = outgoing.Value.GetTransRes(random).DestState;
                    if (!statistics.TryAdd(destState, ref info))
                        info = statistics[destState];
                    ++info.InputCount;
                    if (destState.StateCore == state.StateCore)
                        ++info.LoopCount;
                    //thisInfo = info;
                }
                thisInfo.OutputCount = state.Outgoing.Count;
            }
        }

        public class InputInfo
        {
            public InputInfo(TInput input)
            {
                Input = input;
            }
            public TInput Input { get; private set; }
            public List<TInput> Rejected = new List<TInput>();

            public InputInfo GetFirst(IEnumerable<InputInfo> Potential)
            {
                return Potential.FirstOrDefault(s => !Rejected.Contains(s.Input));
            }

            public override int GetHashCode()
            {
                return Input.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                var other = obj as InputInfo;
                if(other == null)
                    return false;
                return Input.Equals(other.Input);
            }

            public override string ToString()
            {
                return Input.ToString();
            }
        }

        public class StateInfo
        {
            public StateInfo(FSMState<TInput, TOutput> state)
            {
                State = state;
            }

            public FSMState<TInput, TOutput> State { get; private set; }

            public int InputCount { get; set; }
            public int OutputCount { get; set; }
            public int LoopCount { get; set; }
            public List<FSMState<TInput, TOutput>> Potential = new List<FSMState<TInput, TOutput>>();
            public List<FSMState<TInput, TOutput>> Rejected = new List<FSMState<TInput, TOutput>>();

            public bool AddRejected(FSMState<TInput, TOutput> rejectedState)
            {
                bool result = false;
                var rs = Rejected.FirstOrDefault(s => s.StateCore == rejectedState.StateCore);
                if (rs == null)
                {
                    var ps = Potential.FirstOrDefault(s => s.StateCore == rejectedState.StateCore);
                    if (ps != null)
                        Potential.Remove(ps);
                    Rejected.Add(rejectedState);
                    result = true;
                }
                return result;
            }
            //public FSMState<TInput, TOutput> GetFirstPotential(IEnumerable<FSMState<TInput, TOutput>> statesOccupied)
            //{
            //}

            public StateInfo GetFirstPotential(IEnumerable<StateInfo> AvailableStates)
            {
                StateInfo result = null;
                if (Potential.Count > 0)
                {
                    result = AvailableStates.Where(s => Potential.Contains(s.State) && !Rejected.Contains(s.State)).FirstOrDefault();
                }
                return result;
            }

            public override int GetHashCode()
            {
                return State.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                var other = obj as StateInfo;
                if (other == null)
                    return false;
                return State.Equals(other.State);
            }
        }

        public class IsomorphicInfo
        {
            public IsomorphicInfo()
            {
                As = new List<StateInfo>();
                Bs = new List<StateInfo>();
                Zs = new List<InputInfo>();
                Xs = new List<InputInfo>();

                StatesCorrespondence = new BidirectionalDictionary<FSMState<TInput, TOutput>, FSMState<TInput, TOutput>>();
                InputCorrespondence = new BidirectionalDictionary<InputInfo, InputInfo>();
                //InputCorrespondence = new BidirectionalDictionary<TInput, TInput>();
                OutputCorrespondence = new BidirectionalDictionary<TOutput, TOutput>();
            }
            public List<StateInfo> As { get; set; }
            public List<StateInfo> Bs { get; set; }
            public List<InputInfo> Zs { get; set; }
            public List<InputInfo> Xs { get; set; }

            public BidirectionalDictionary<FSMState<TInput, TOutput>, FSMState<TInput, TOutput>> StatesCorrespondence {get; set;}
            public BidirectionalDictionary<InputInfo, InputInfo> InputCorrespondence { get; set; }
            //public BidirectionalDictionary<TInput, TInput> InputCorrespondence { get; set; }
            public BidirectionalDictionary<TOutput, TOutput> OutputCorrespondence { get; set; }
        }

        #endregion

        #region IStringKeyable Members

        public string KeyName { get; private set; }

        #endregion
    }

    public class Transition<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        public Transition(IFSM<TInput, TOutput> fsm)
        {
            OwnerFSM = fsm;
        }
        public IFSM<TInput, TOutput> OwnerFSM { get; private set; }
        public FSMState<TInput, TOutput> SourceState { get; set; }
        //public FSMState<TInput, TOutput> DestinationState { get; set; }
        public TInput Input { get; set; }
        //public TOutput Output { get; set; }

        public List<TransitionRes<TInput, TOutput>> destinationStates = new List<TransitionRes<TInput, TOutput>>();

        public TransitionRes<TInput, TOutput> GetDestination(double probability)
        {
            TransitionRes<TInput, TOutput> result = null;
            double sum = 0.0;
            foreach (var destinationState in destinationStates)
            {
                if ((probability >= sum) && (probability <= sum + destinationState.Probability))
                {
                    result = destinationState;
                    break;
                }
                sum += destinationState.Probability;
            }
            return result;
        }

        public bool AddDestination(FSMState<TInput, TOutput> state, TOutput output, double probability)
        {
            if (state == null) throw new ArgumentNullException("state");

            if ((probability <= 0) || (probability > 1)) throw new ArgumentException("Probability must be in (0;1]", "probability");

            TransitionRes<TInput, TOutput> tr = new TransitionRes<TInput, TOutput>(this)
            {
                DestState = state,
                Output = output,
                Probability = probability
            };
            bool result = true;
            if (!destinationStates.Contains(tr))
            {
                double available = 0;
                foreach (var destinationState in destinationStates)
                {
                    available += destinationState.Probability;
                }

                if (probability + available > 1) throw new ArgumentException("Sum probability must be in (0;1]", "probability");

                destinationStates.Add(tr);
            }
            else
            {
                var v = destinationStates.First(d => d.KeyName == tr.KeyName);

                double available = 0;
                foreach (var destinationState in destinationStates)
                {
                    if (destinationState.KeyName != v.KeyName)
                        available += destinationState.Probability;
                    else
                        available += probability;
                }

                if (available > 1) throw new ArgumentException("Sum probability must be in (0;1]", "probability");

                v.Probability = probability;
            }
            return result;
        }

        public double ProbabilityOfReject
        {
            get
            {
                double result = 0;
                foreach (var destinationState in destinationStates)
                {
                    result += destinationState.Probability;
                }
                return 1 - result;
            }
        }

        public override string ToString()
        {
            //string result = string.Empty;
            //foreach (var destinationState in destinationStates)
            //{
            //    result += destinationState.ToString() + "; ";
            //}
            return SourceState.StateCore.ToString() + " " + Input.KeyName;// +" : " + result;
        }
    }
}
