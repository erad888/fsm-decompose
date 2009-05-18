using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    public interface INetComponentInfosContainer
    {
        IEnumerable<FSMInfo> Components { get; }
    }
}
