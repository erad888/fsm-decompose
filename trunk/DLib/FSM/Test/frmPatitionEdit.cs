using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FSM;
using LogicUtils;

namespace Test
{
    public partial class frmPatitionEdit : Form
    {
        public frmPatitionEdit()
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

        public Partition<FSMState<StructAtom<string>, StructAtom<string>>> Partition{get; private set;}

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Partition = pec.Partition;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                MessageBox.Show("Формирование разбиения не завершено. Все состояния автомата должны быть распределены по блокам разбиения.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
