using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FSM;
using LogicUtils;

namespace Test
{
    public partial class PartitionsEditControl : UserControl
    {
        public PartitionsEditControl()
        {
            InitializeComponent();
        }

        public FiniteStateMachine<StructAtom<string>, StructAtom<string>> FSM { get; private set; }
        private List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>> partitions = new List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>>();

        public void Init(FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsm)
        {
            if (fsm == null) throw new ArgumentNullException("fsm");
            FSM = fsm;
            lbxStates.Items.AddRange(GetAvailableStates().ToArray());
            lePartitions.ItemAdded += lePartitions_ItemAdded;
            lePartitions.ItemRemoved += lePartitions_ItemRemoved;
            lePartitions.CreationRule = name => new Partition<FSMState<StructAtom<string>, StructAtom<string>>>() { KeyName = name };
        }

        void lePartitions_ItemRemoved(object sender, TemplateEventArgs<object> e)
        {
            var part = e.Value as Partition<FSMState<StructAtom<string>, StructAtom<string>>>;
            if (part != null)
            {
                var exPart = partitions.FirstOrDefault(p => p.KeyName == part.KeyName);
                if (exPart != null)
                {
                    if (partitions.Remove(exPart))
                        SyncPartitionsWithView();
                    else
                        e.Cancel = true;
                }
                else
                    e.Cancel = true;
            }
        }

        void lePartitions_ItemAdded(object sender, TemplateEventArgs<object> e)
        {
            var part = e.Value as Partition<FSMState<StructAtom<string>, StructAtom<string>>>;
            if (part != null)
            {
                var exPart = partitions.FirstOrDefault(p => p.KeyName == part.KeyName);
                if (exPart == null)
                {
                    partitions.Add(part);
                    SyncPartitionsWithView();
                }
                else
                    e.Cancel = true;
            }
            else
                e.Cancel = true;
        }

        private void SyncPartitionsWithView()
        {
            lePartitions.SaveSelectedPosition();
            lePartitions.Items.Clear();
            lePartitions.Items.AddRange(partitions.ToArray());
            lePartitions.RestoreSelectedPosition();
        }

        private IEnumerable<FSMState<StructAtom<string>, StructAtom<string>>> GetAvailableStates()
        {
            var usedStates = new List<FSMState<StructAtom<string>, StructAtom<string>>>();

            foreach (var partition in partitions)
            {
                usedStates.AddRange(partition.UnionOfParts());
            }

            return FSM.StateSet.Except(usedStates);
        }

        private void btnToTemp_Click(object sender, EventArgs e)
        {

        }

        private void btnAllToTemp_Click(object sender, EventArgs e)
        {

        }

        private void btnFromTemp_Click(object sender, EventArgs e)
        {

        }

        private void btnAllFromTemp_Click(object sender, EventArgs e)
        {

        }
    }
}
