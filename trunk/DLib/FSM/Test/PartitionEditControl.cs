using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FSM;
using LogicUtils;

namespace Test
{
    public partial class PartitionEditControl : UserControl
    {
        public PartitionEditControl()
        {
            InitializeComponent();
        }

        public FiniteStateMachine<StructAtom<string>, StructAtom<string>> FSM { get; private set; }
        public Partition<FSMState<StructAtom<string>, StructAtom<string>>> Partition
        {
            get
            {
                var res = new Partition<FSMState<StructAtom<string>, StructAtom<string>>>();
                foreach (var block in blocks.Values)
                {
                    res.Add(block);
                }
                if (FSM.StateSet.Except(res.UnionOfParts()).Count() > 0)
                    throw new InvalidDataException("Разбиение не завершено");
                return res;
            }
        }
        private Dictionary<string, List<FSMState<StructAtom<string>, StructAtom<string>>>> blocks = new Dictionary<string, List<FSMState<StructAtom<string>, StructAtom<string>>>>();

        public void Init(FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsm)
        {
            if (fsm == null) throw new ArgumentNullException("fsm");
            FSM = fsm;
            lbxBlocks.SelectedValueChanged += lbxBlocks_SelectedValueChanged;
            SyncStates();
        }

        void lbxBlocks_SelectedValueChanged(object sender, EventArgs e)
        {
            SyncTempStates();
        }

        private void SyncBlocks()
        {
            lbxBlocks.Items.Clear();
            lbxBlocks.Items.AddRange(blocks.Keys.ToArray());
            if (lbxBlocks.Items.Count > 0)
            {
                lbxBlocks.SelectedIndex = lbxBlocks.Items.Count - 1;
            }
        }

        private List<FSMState<StructAtom<string>, StructAtom<string>>> GetSelectedBlock()
        {
            List<FSMState<StructAtom<string>, StructAtom<string>>> result = null;
            if (lbxBlocks.SelectedIndex >= 0)
            {
                var selectedBlockName = lbxBlocks.SelectedItem as string;
                if (!string.IsNullOrEmpty(selectedBlockName))
                {
                    if (blocks.ContainsKey(selectedBlockName))
                    {
                        result = blocks[selectedBlockName];
                    }
                }
            }
            return result;
        }

        private void SyncTempStates()
        {
            var block = GetSelectedBlock();
            if (block != null)
            {
                lbxTempStates.Items.Clear();
                lbxTempStates.Items.AddRange(block.ToArray());

                if (lbxTempStates.Items.Count > 0)
                    lbxTempStates.SelectedIndex = 0;
            }
        }

        private void SyncStates()
        {
            lbxStates.Items.Clear();
            lbxStates.Items.AddRange(GetAvailableStates().ToArray());
            if (lbxStates.Items.Count > 0)
                lbxStates.SelectedIndex = 0;
        }

        private IEnumerable<FSMState<StructAtom<string>, StructAtom<string>>> GetAvailableStates()
        {
            var usedStates = new List<FSMState<StructAtom<string>, StructAtom<string>>>();

            foreach (var block in blocks.Values)
            {
                usedStates.AddRange(block);
            }

            return FSM.StateSet.Except(usedStates);
        }

        private void btnToTemp_Click(object sender, EventArgs e)
        {
            if (lbxBlocks.SelectedIndex >= 0)
            {
                var block = GetSelectedBlock();
                if (block != null)
                {
                    var value = lbxStates.SelectedItem as FSMState<StructAtom<string>, StructAtom<string>>;
                    if (value != null)
                    {
                        block.Add(value);
                        SyncStates();
                        SyncTempStates();
                    }
                }
            }
        }

        private void btnAllToTemp_Click(object sender, EventArgs e)
        {
            var block = GetSelectedBlock();
            if(block != null)
            {
                block.AddRange(GetAvailableStates());
                SyncStates();
                SyncTempStates();
            }
        }

        private void btnFromTemp_Click(object sender, EventArgs e)
        {
            if (lbxTempStates.SelectedIndex >= 0)
            {
                var block = GetSelectedBlock();
                if (block != null)
                {
                    var value = lbxTempStates.SelectedItem as FSMState<StructAtom<string>, StructAtom<string>>;
                    if (value != null)
                    {
                        if (block.Remove(value))
                        {
                            SyncTempStates();
                            SyncStates();
                        }
                    }
                }
            }
        }

        private void btnAllFromTemp_Click(object sender, EventArgs e)
        {
            var block = GetSelectedBlock();
            if (block != null)
            {
                block.Clear();
                SyncTempStates();
                SyncStates();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            blocks.Add("Блок " + (blocks.Count+1).ToString(), new List<FSMState<StructAtom<string>, StructAtom<string>>>());
            SyncBlocks();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbxBlocks.SelectedIndex >= 0)
            {
                var selectedBlockName = lbxBlocks.SelectedItem as string;
                if (!string.IsNullOrEmpty(selectedBlockName))
                {
                    if (blocks.ContainsKey(selectedBlockName))
                    {
                        if (blocks.Remove(selectedBlockName))
                        {
                            SyncBlocks();
                            SyncStates();
                        }
                    }
                }
            }
        }
    }
}
