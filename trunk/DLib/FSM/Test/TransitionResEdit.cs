using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using FSM;

namespace Test
{
    public partial class TransitionResEdit : Form
    {
        public TransitionResEdit()
        {
            InitializeComponent();
            seProbability.Properties.Increment = (decimal)0.1;
            Probability = -1;
        }

        private void seProbability_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = seProbability.Value <= 0 || (double)seProbability.Value > RemainderOfProbability;
        }

        public double RemainderOfProbability { get; private set; }
        public string StateKey { get; set; }
        public string OutputKey { get; set; }
        public double Probability { get; set; }

        public DialogResult Show(double remainderOfProbability, IFSM<StructAtom<string>, StructAtom<string>> fsm)
        {
            if (fsm == null) throw new ArgumentNullException("fsm");
            if (remainderOfProbability <= 0)
                throw new ArgumentException("Некоректный остаток вероятности", "remainderOfProbability");

            if (fsm.OutputSet.Count() == 0)
                throw new ArgumentException("Множество выходных символов пусто", "fsm");
            if (fsm.StateSet.Count() == 0)
                throw new ArgumentException("Множество состояний пусто", "fsm");

            RemainderOfProbability = remainderOfProbability;
            PopulateComboBoxes(fsm);
            if (Probability < 0 || Probability > 1)
                seProbability.Value = (decimal)RemainderOfProbability;
            else
                seProbability.Value = (decimal)Probability;

            seProbability.Properties.MinValue = 0;
            seProbability.Properties.MaxValue = seProbability.Value;

            ShowDialog();
            return DialogResult;
        }

        private void PopulateComboBoxes(IFSM<StructAtom<string>, StructAtom<string>> fsm)
        {
            cbxDestState.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cbxOutput.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cbxDestState.Properties.Items.AddRange(fsm.StateSet);
            cbxOutput.Properties.Items.AddRange(fsm.OutputSet);

            var selectedState = fsm.StateSet.FirstOrDefault(s => s.KeyName == StateKey);
            var selectedOutput = fsm.OutputSet.FirstOrDefault(o => o.KeyName == OutputKey);
            
            if (selectedState != null)
                cbxDestState.SelectedItem = selectedState;
            else
                cbxDestState.SelectedIndex = 0;

            if (selectedOutput != null)
                cbxOutput.SelectedItem = selectedOutput;
            else
                cbxOutput.SelectedIndex = 0;
        }

        public TransitionRes<StructAtom<string>, StructAtom<string>> TransRes
        {
            get
            {
                TransitionRes<StructAtom<string>, StructAtom<string>> result =
                    new TransitionRes<StructAtom<string>, StructAtom<string>>();

                result.DestState = cbxDestState.SelectedItem as FSMState<StructAtom<string>, StructAtom<string>>;
                result.Output = cbxOutput.SelectedItem as StructAtom<string>;
                result.Probability = (double)seProbability.Value;

                return result;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
