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
        public INetComponentInfosContainer LogicComponent { get; private set; }

        private void InitNetControl()
        {
            nc.Dock = DockStyle.Fill;
            this.Controls.Add(nc);
        }

        public void Show(INetComponentInfosContainer logicComponent)
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
    }
}
