using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicUtils;

namespace FSM
{
    public class FSMAtomBase : IStringKeyable
    {
        public static bool operator ==(FSMAtomBase a, FSMAtomBase b)
        {
            if (object.ReferenceEquals(a, null))
            {
                return object.ReferenceEquals(b, null);
            }
            else if (object.ReferenceEquals(b, null))
                return false;

            return a.KeyName == b.KeyName;
        }
        public static bool operator !=(FSMAtomBase a, FSMAtomBase b)
        {
            return !(a == b);
        }

        #region IStringKeyable Members

        public virtual string KeyName
        {
            get { return this.ToString(); }
        }

        #endregion
    }
}
