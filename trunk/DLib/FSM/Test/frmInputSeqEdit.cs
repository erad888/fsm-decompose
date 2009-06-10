using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using FSM;
using FSM.Representation;
using DevExpress.XtraGrid.Columns;

namespace Test
{
    public partial class frmInputSeqEdit : Form
    {
        public frmInputSeqEdit()
        {
            InitializeComponent();
            Init();
            InitRepItems();
        }

        RepositoryItemComboBox CbxRepositoryItem = new RepositoryItemComboBox();
        RepositoryItemComboBox EmptyCbxRepositoryItem = new RepositoryItemComboBox();
        GridEditorButton DeleteButton = new GridEditorButton(ButtonPredefines.Delete);

        public List<StructAtom<string>> Items = new List<StructAtom<string>>();
        private List<StructAtom<string>> AvailableInputs = new List<StructAtom<string>>();

        public DialogResult Show(IEnumerable<StructAtom<string>> availableInputs)
        {
            AvailableInputs.AddRange(availableInputs);

            CbxRepositoryItem.Items.AddRange(availableInputs.ToArray());
            EmptyCbxRepositoryItem.Items.AddRange(availableInputs.ToArray());
            SyncItems();

            ShowDialog();

            return DialogResult;
        }

        private void Init()
        {
            DeleteButton.Tag = "Delete";
            InitGrid();
        }

        private void InitGrid()
        {
            gv.OptionsView.AllowCellMerge = false;

            gv.OptionsCustomization.AllowColumnMoving = false;
            gv.OptionsCustomization.AllowGroup = false;
            gv.OptionsCustomization.AllowSort = false;
            gv.OptionsView.ShowGroupPanel = false;

            gv.CustomRowCellEditForEditing += gv_CustomRowCellEditForEditing;
            gv.CellValueChanged += gv_CellValueChanged;

            var column = new GridColumn();
            column.Name = "Order";
            column.FieldName = column.Name;
            column.Caption = "№";
            column.VisibleIndex = 0;
            column.Width = 20;
            column.OptionsColumn.AllowEdit = false;
            gv.Columns.Add(column);

            column = new GridColumn();
            column.Name = "Input";
            column.FieldName = column.Name;
            column.Caption = "Входной символ";
            column.VisibleIndex = 0;
            gv.Columns.Add(column);
        }

        void gv_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var orderVal = (gv.GetRowCellValue(e.RowHandle, "Order"));
            StructAtom<string> newValue = gv.GetRowCellValue(e.RowHandle, "Input") as StructAtom<string>;
            if (newValue != null)
            {
                if (orderVal != DBNull.Value)
                {
                    int order = (int)orderVal;
                    Items[order] = newValue;
                }
                else
                {
                    Items.Add(newValue);
                }

                SyncItems();
            }
        }

        private void CheckOrder(int order)
        {
            if(order < 0 || order > Items.Count - 1)
                throw new IndexOutOfRangeException();
        }

        void gv_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            var res = gv.GetRowCellValue(e.RowHandle, e.Column);

            if (e.Column.Name == "Input")
            {
                if (res == DBNull.Value)
                    e.RepositoryItem = EmptyCbxRepositoryItem;
                else
                    e.RepositoryItem = CbxRepositoryItem;

                var ri = e.RepositoryItem as RepositoryItemButtonEdit;

                if (ri != null)
                {
                    foreach (var button in ri.Buttons)
                    {
                        var gbtn = button as GridEditorButton;
                        if (gbtn != null)
                            gbtn.SetCell(e.RowHandle, e.Column);
                    }
                }
            }
        }

        private void InitRepItems()
        {
            CbxRepositoryItem.Buttons.Add(DeleteButton);
            CbxRepositoryItem.ButtonClick += CbxRepositoryItem_ButtonClick;
        }

        void CbxRepositoryItem_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Delete:
                    {
                        DeleteHandler(DeleteButton);
                    }
                    break;
            }
        }

        private void SyncItems()
        {
            gc.DataSource = FSMDataTableRepresenter.Convert(Items);
        }

        private void DeleteHandler(GridEditorButton gridEditorButton)
        {
            int orderNumber = (int)(gv.GetRowCellValue(gridEditorButton.RowHandle, "Order"));
            StructAtom<string> value = gv.GetRowCellValue(gridEditorButton.RowHandle, "Input") as StructAtom<string>;

            if (value != null)
            {
                Items.RemoveAt(orderNumber);
                SyncItems();
            }
        }

        private void tsbtnLoad_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {

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

        private void tsbtnClearAll_Click(object sender, EventArgs e)
        {
            Items.Clear();
            SyncItems();
        }
    }
}
