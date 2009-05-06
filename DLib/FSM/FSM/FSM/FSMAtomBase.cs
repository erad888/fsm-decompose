﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    public class FSMAtomBase : IStringKeyable
    {
        #region IStringKeyable Members

        public virtual string KeyName
        {
            get { return this.ToString(); }
        }

        #endregion
    }
}
