using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FSM;

namespace Test
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Enum x1 = X.x1; Enum x2 = X.x2; Enum x3 = X.x3;

            //TODO: Добавить средства для добавления отношений типа ksi: Z -> X
            FiniteStateMachine<StructAtom<Enum>, StructAtom<Enum>> S1 = new FiniteStateMachine<StructAtom<Enum>, StructAtom<Enum>>();
            FSMState<StructAtom<Enum>, StructAtom<Enum>> b1 = new FSMState<StructAtom<Enum>, StructAtom<Enum>>(S1, B.b1);
            FSMState<StructAtom<Enum>, StructAtom<Enum>> b2 = new FSMState<StructAtom<Enum>, StructAtom<Enum>>(S1, B.b2);
            FSMState<StructAtom<Enum>, StructAtom<Enum>> b3 = new FSMState<StructAtom<Enum>, StructAtom<Enum>>(S1, B.b3);

            S1.AddOutgoing(b1, new StructAtom<Enum>(x1), b1, (StructAtom<Enum>)b1.StateCore);
            S1.AddOutgoing(b1, new StructAtom<Enum>(x2), b3);
            S1.AddOutgoing(b1, new StructAtom<Enum>(x3), b3);

            S1.AddOutgoing(b2, new StructAtom<Enum>(x1), b1);
            S1.AddOutgoing(b2, new StructAtom<Enum>(x2), b2);
            S1.AddOutgoing(b2, new StructAtom<Enum>(x3), b2);

            S1.AddOutgoing(b3, new StructAtom<Enum>(x1), b3);
            S1.AddOutgoing(b3, new StructAtom<Enum>(x2), b3);
            S1.AddOutgoing(b3, new StructAtom<Enum>(x3), b1);
        }

        enum B
        {
            b1,
            b2,
            b3
        }

        enum X
        {
            x1,
            x2,
            x3
        }
    }
}
