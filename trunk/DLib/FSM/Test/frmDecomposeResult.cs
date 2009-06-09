using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FSM;
using FSM.FSMWinControls;
using DecomposeLib;

namespace Test
{
    public partial class frmDecomposeResult : Form
    {
        public frmDecomposeResult()
        {
            InitializeComponent();

            InitNetControl();
        }

        FSMNetControl nc = new FSMNetControl();
        public FSMNet<StructAtom<string>, StructAtom<string>> LogicComponent { get; private set; }

        private void InitNetControl()
        {
            nc.Dock = DockStyle.Fill;
            splitContainerControl1.Panel1.Controls.Add(nc);
        }

        public void Show(FSMNet<StructAtom<string>, StructAtom<string>> logicComponent)
        {
            if (logicComponent == null) throw new ArgumentNullException("logicComponent");

            LogicComponent = logicComponent;
            SyncLComponent();
            this.Show();
        }

        private void SyncLComponent()
        {
            nc.LogicComponent = LogicComponent;
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            var frm = new frmStatistics();
            frm.Show(LogicComponent);
        }
    }
}
