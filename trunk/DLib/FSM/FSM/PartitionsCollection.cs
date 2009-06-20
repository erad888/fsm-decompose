using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicUtils;

namespace FSM
{
    public class PartitionsCollection<TInput, TOutput>
        where TInput : FSMAtomBase, IStringKeyable
        where TOutput : FSMAtomBase, IStringKeyable
    {
        public PartitionsCollection(IEnumerable<Partition<FSMState<TInput, TOutput>>> items)
        {
            Items = items;
        }

        public IEnumerable<Partition<FSMState<TInput, TOutput>>> Items { get; private set; }

        public override string ToString()
        {
            StringBuilder sbResult = new StringBuilder("{ ");
            foreach (var item in Items)
            {
                sbResult.Append("{" + item.ToString() + "}; ");
            }
            sbResult.Append("}");
            return sbResult.ToString();
        }
    }
}
