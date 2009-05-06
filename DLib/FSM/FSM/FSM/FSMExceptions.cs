using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{

    [global::System.Serializable]
    public class NonAcceptableInitialStateException : Exception
    {
        public NonAcceptableInitialStateException() { }
        public NonAcceptableInitialStateException(string message) : base(message) { }
        public NonAcceptableInitialStateException(string message, Exception inner) : base(message, inner) { }
        protected NonAcceptableInitialStateException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public NonAcceptableInitialStateException(PersistentState state)
        {
            State = state;
        }

        public PersistentState State { get; private set; }
    }
}
