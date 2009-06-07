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
    public partial class frmChooseOrtPartition : Form
    {
        public frmChooseOrtPartition()
        {
            InitializeComponent();
        }

        public IEnumerable<Partition<FSMState<StructAtom<string>, StructAtom<string>>>> SelectedPartitions
        {
            get
            {
                if (lbx.SelectedIndex >= 0)
                {
                    var value = lbx.SelectedItem as PartsCollection;
                    if (value != null)
                    {
                        return value.Items.ToArray();
                    }
                }
                return null;
            }
        }

        public DialogResult Show(List<List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>>> partitions)
        {
            if (partitions == null) throw new ArgumentNullException("partitions");

            lbx.Items.Clear();
            lbx.Items.AddRange(partitions.Select(ps => new PartsCollection(ps)).ToArray());
            if (lbx.Items.Count > 0)
                lbx.SelectedIndex = 0;
            return ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SelectedPartitions != null)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Необходимо выбрать одно из множеств разбиений.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        class PartsCollection
        {
            public PartsCollection(IEnumerable<Partition<FSMState<StructAtom<string>, StructAtom<string>>>> items)
            {
                Items = items;
            }

            public IEnumerable<Partition<FSMState<StructAtom<string>, StructAtom<string>>>> Items { get; private set; }

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
}
