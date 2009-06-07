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
    public partial class frmOrtPartitionSetEdit : Form
    {
        public frmOrtPartitionSetEdit()
        {
            InitializeComponent();
        }

        private List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>> partitions = new List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>>();
        public IEnumerable<Partition<FSMState<StructAtom<string>, StructAtom<string>>>> Partitions
        {
            get { return partitions.ToArray(); }
        }
        public FiniteStateMachine<StructAtom<string>, StructAtom<string>> FSM { get; private set; }

        public DialogResult Show(FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsm)
        {
            if (fsm == null) throw new ArgumentNullException("fsm");

            btnOK.Enabled = false;
            this.FSM = fsm;
            return ShowDialog();
        }

        private void SyncPartitions()
        {
            lbxPartitions.Items.Clear();
            lbxPartitions.Items.AddRange(partitions.ToArray());
            if (CheckOrtPartitions())
            {
                btnOK.Enabled = true;
            }
            else
            {
                if (partitions.Count > 1)
                {
                    var partsListList = Partition<FSMState<StructAtom<string>, StructAtom<string>>>.
                        GetAllOrtPartitionSets(
                        Partition<FSMState<StructAtom<string>, StructAtom<string>>>.FilterSamePartitions(
                            Partition<FSMState<StructAtom<string>, StructAtom<string>>>.GetAllPartitions(
                                new HashSet<FSMState<StructAtom<string>, StructAtom<string>>>(FSM.StateSet),
                                1).Where(p => p.Count() >= 1 && p.Count() <= 3)
                            ).ToArray(),
                        partitions.ToArray(),
                        new HashSet<FSMState<StructAtom<string>, StructAtom<string>>>(FSM.StateSet),
                        partitions.Count,
                        partitions.Count + 1);

                    var frm = new frmChooseOrtPartition();
                    if (frm.Show(partsListList) == System.Windows.Forms.DialogResult.OK)
                    {
                        partitions.Clear();
                        partitions.AddRange(frm.SelectedPartitions);
                        SyncPartitions();
                    }
                }
            }
        }

        private bool CheckOrtPartitions()
        {
            return Partition<FSMState<StructAtom<string>, StructAtom<string>>>.IsOrtPartitionSet(partitions.ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmPatitionEdit();
            if (frm.Show(FSM) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    var part = frm.Partition;
                    if (part != null)
                    {
                        var exPart = partitions.FirstOrDefault(p => p.AreSame(part));
                        if (exPart == null)
                        {
                            partitions.Add(part);
                            SyncPartitions();
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbxPartitions.SelectedIndex >= 0)
            {
                var part = lbxPartitions.SelectedItem as Partition<FSMState<StructAtom<string>, StructAtom<string>>>;
                if (part != null)
                {
                    var exPart = partitions.FirstOrDefault(p => p.AreSame(part));
                    if (exPart != null)
                    {
                        if (partitions.Remove(exPart))
                        {
                            SyncPartitions();
                        }
                    }
                }
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
