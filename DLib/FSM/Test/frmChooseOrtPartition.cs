using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using FSM;
using LogicUtils;
using DecomposeLib;
using FSM.Representation;
using DevExpress.XtraGrid.Views.Grid;

namespace Test
{
    public partial class frmChooseOrtPartition : Form
    {
        public frmChooseOrtPartition()
        {
            InitializeComponent();
            InitGrid();
        }

        public IEnumerable<Partition<FSMState<StructAtom<string>, StructAtom<string>>>> SelectedPartitions
        {
            get
            {
                var indexes = gv.GetSelectedRows();
                if (indexes.Length > 0)
                {
                    var value = gv.GetRowCellValue(indexes[0], "Partitions") as PartitionsCollection<StructAtom<string>, StructAtom<string>>;
                    if (value != null)
                    {
                        return value.Items.ToArray();
                    }
                }
                //if (lbx.SelectedIndex >= 0)
                //{
                //    var value = lbx.SelectedItem as PartsCollection;
                //    if (value != null)
                //    {
                //        return value.Items.ToArray();
                //    }
                //}
                return null;
            }
        }

        private void InitGrid()
        {
            gv.OptionsView.AllowCellMerge = false;

            gv.OptionsCustomization.AllowColumnMoving = false;
            gv.OptionsCustomization.AllowGroup = false;
            gv.OptionsCustomization.AllowSort = true;
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gv.OptionsSelection.MultiSelect = false;
            gv.OptionsCustomization.AllowFilter = false;
            gv.OptionsBehavior.Editable = false;
        }

        private void SyncGrid(List<List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>>> partitions)
        {
            gv.Columns.Clear();

            if (partitions != null)
            {
                GridColumn column = new GridColumn();
                column.Caption = "Множество ортогональных разбиений";
                column.Width = 150;
                column.Name = "Partitions";
                column.FieldName = "Partitions";
                column.Fixed = FixedStyle.Left;
                column.VisibleIndex = 0;
                gv.Columns.Add(column);

                column = new GridColumn();
                column.Caption = "Оценка, %";
                column.Width = 30;
                column.Name = "Mark";
                column.FieldName = "Mark";
                column.OptionsColumn.FixedWidth = true;
                column.VisibleIndex = 1;
                gv.Columns.Add(column);

                var list = new List<KeyValuePair<double, PartitionsCollection<StructAtom<string>, StructAtom<string>>>>(
                    partitions.Select(
                        p => new KeyValuePair<double, PartitionsCollection<StructAtom<string>, StructAtom<string>>>(
                                 100 - p.SimpleCriteria(),
                                 new PartitionsCollection<StructAtom<string>, StructAtom<string>>(p)))
                    ).OrderByDescending(kvp => kvp.Key);

                gc.DataSource = FSMDataTableRepresenter.Convert(list);
            }
        }

        public DialogResult Show(List<List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>>> partitions)
        {
            if (partitions == null) throw new ArgumentNullException("partitions");

            //lbx.Items.Clear();
            //lbx.Items.AddRange(partitions.OrderBy(p => p.SimpleCriteria()).Select(ps => new PartsCollection(ps)).ToArray());
            //if (lbx.Items.Count > 0)
            //    lbx.SelectedIndex = 0;
            SyncGrid(partitions);
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
