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
    public partial class frmPatitionsEdit : Form
    {
        public frmPatitionsEdit()
        {
            InitializeComponent();
        }

        public FiniteStateMachine<StructAtom<string>, StructAtom<string>> FSM { get; private set; }

        public DialogResult Show(FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsm)
        {
            FSM = fsm;
            Sync();
            return ShowDialog();
        }

        private void Sync()
        {
            pec.Init(FSM);
        }
    }
}
