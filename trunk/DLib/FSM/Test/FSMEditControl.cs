using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using FSM;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using FSM.Representation;
using DevExpress.XtraEditors;

namespace Test
{
    public partial class FSMEditControl : UserControl
    {
        public FSMEditControl()
        {
            InitializeComponent();
            
            InitGrid();
            InitRepItems();
            InitHandlers();
            InitListEdits();
        }

        private void InitListEdits()
        {
            leStates.CreationRule = s => s;
            leInput.CreationRule = i => i;
            leOutput.CreationRule = o => o;

            leStates.Caption = "Состояния";
            leInput.Caption = "Входные символы";
            leOutput.Caption = "Выходные символы";
        }

        private void InitGrid()
        {
            gvEdit.OptionsView.AllowCellMerge = true;

            gvEdit.OptionsCustomization.AllowColumnMoving = false;
            gvEdit.OptionsCustomization.AllowGroup = false;
            gvEdit.OptionsCustomization.AllowSort = false;
            gvEdit.OptionsView.ShowGroupPanel = false;

            //gridControl1.RepositoryItems.Add(transitionRepositoryItem);
            //foreach (var column in gvEdit.Columns)
            //{
            //    if ((column as GridColumn).Name != "Zs")
            //    {
            //        (column as GridColumn).ColumnEdit = transitionRepositoryItem;
            //    }
            //}
        }

        private void InitHandlers()
        {
            gvEdit.CellMerge += gvEdit_CellMerge;
            gvEdit.CustomRowCellEditForEditing += gvEdit_CustomRowCellEditForEditing;
            leStates.ItemAdded += leStates_ItemAdded;
            leStates.ItemRemoved += leStates_ItemRemoved;
            leInput.ItemAdded += leInput_ItemAdded;
            leInput.ItemRemoved += leInput_ItemRemoved;
            leOutput.ItemAdded += leOutput_ItemAdded;
            leOutput.ItemRemoved += leOutput_ItemRemoved;
        }

        void leOutput_ItemRemoved(object sender, TemplateEventArgs<object> e)
        {
            if (fsm.RemoveOutput(e.Value as string))
                SetFSMToView();
            else
                e.Cancel = true;
        }

        void leOutput_ItemAdded(object sender, TemplateEventArgs<object> e)
        {
            if (fsm.AddOutput(new StructAtom<string>(e.Value as string)))
                SetFSMToView();
            else
                e.Cancel = true;
        }

        void leInput_ItemRemoved(object sender, TemplateEventArgs<object> e)
        {
            if (fsm.RemoveInput(e.Value as string))
                SetFSMToView();
            else
                e.Cancel = true;
        }

        void leInput_ItemAdded(object sender, TemplateEventArgs<object> e)
        {
            if (fsm.AddInput(new StructAtom<string>(e.Value as string)))
                SetFSMToView();
            else
                e.Cancel = true;
        }

        void leStates_ItemRemoved(object sender, TemplateEventArgs<object> e)
        {
            if (fsm.RemoveState(e.Value))
                SetFSMToView();
            else
                e.Cancel = true;
        }

        void leStates_ItemAdded(object sender, TemplateEventArgs<object> e)
        {
            if(fsm.AddState(e.Value))
                SetFSMToView();
            else
                e.Cancel = true;
        }

        private void InitRepItems()
        {
            var plusBtn = new GridEditorButton();
            plusBtn.Tag = "plus";
            plusBtn.Kind = ButtonPredefines.Plus;

            var deleteBtn = new GridEditorButton();
            deleteBtn.Tag = "delete";
            deleteBtn.Kind = ButtonPredefines.Delete;

            var ellBtn = new GridEditorButton();
            ellBtn.Tag = "ell";
            ellBtn.Kind = ButtonPredefines.Ellipsis;
            ellBtn.IsLeft = true;

            transitionRepositoryItem.BeginInit();
            transitionRepositoryItem.ButtonClick += transitionRepositoryItem_ButtonClick;

            transitionRepositoryItem.Buttons.AddRange(new[]{ellBtn, deleteBtn});

            transitionRepositoryItem.Name = "transitionRepositoryItem";
            transitionRepositoryItem.TextEditStyle = TextEditStyles.DisableTextEditor;
            transitionRepositoryItem.EndInit();


            nonTransitionRepositoryItem.BeginInit();
            nonTransitionRepositoryItem.ButtonClick += nonTransitionRepositoryItem_ButtonClick;

            nonTransitionRepositoryItem.Buttons.Add(plusBtn);
            
            nonTransitionRepositoryItem.Name = "nonTransitionRepositoryItem";
            nonTransitionRepositoryItem.TextEditStyle = TextEditStyles.DisableTextEditor;
            nonTransitionRepositoryItem.EndInit();
        }

        void nonTransitionRepositoryItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridEditorButton gridButton = null;
            foreach (var b in nonTransitionRepositoryItem.Buttons)
            {
                gridButton = b as GridEditorButton;
                if (gridButton != null)
                {
                    if (gridButton.Tag == e.Button.Tag)
                        break;
                    else
                        gridButton = null;
                }
            }

            if (gridButton != null)
            {
                switch (gridButton.Tag as string)
                {
                    case "plus":
                        PlusHandler(gridButton);
                        break;
                }
            }
        }

        void transitionRepositoryItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridEditorButton gridButton = null;
            foreach (var b in transitionRepositoryItem.Buttons)
            {
                gridButton = b as GridEditorButton;
                if (gridButton != null)
                {
                    if (gridButton.Tag == e.Button.Tag)
                        break;
                    else
                        gridButton = null;
                }
            }

            if (gridButton != null)
            {
                var ob = gvEdit.GetRowCellValue(gridButton.RowHandle, gridButton.Column);
                var tr = ob as TransitionRes<StructAtom<string>, StructAtom<string>>;
                if (tr != null)
                {
                    switch (gridButton.Tag as string)
                    {
                        case "ell":
                            EllHandler(tr, gridButton);
                            break;
                        case "delete":
                            DeleteHandler(tr, gridButton);
                            break;
                    }
                }
                else
                {
                    switch (gridButton.Tag as string)
                    {
                        case "plus":
                            PlusHandler(gridButton);
                            break;
                    }
                }
            }
        }

        private void EllHandler(TransitionRes<StructAtom<string>, StructAtom<string>> transitionRes, GridEditorButton button)
        {
            frmTransitionEdit frm = new frmTransitionEdit();
            frm.DataChanged += frm_DataChanged;
            frm.Show(transitionRes.Transition);
        }

        void frm_DataChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void PlusHandler(GridEditorButton button)
        {
            var state = fsm.StateSet.FirstOrDefault(s => s.ToString() == button.Column.FieldName);
            var cg = gvEdit.Columns["Zs"];
            var v = gvEdit.GetRowCellValue(button.RowHandle, cg);
            var input = v as string;

            if (state != null && input != null)
            {
                frmTransitionEdit frm = new frmTransitionEdit();
                frm.DataChanged += frm_DataChanged;

                var trans = fsm.Transitions.Values.FirstOrDefault(tr => tr.Input.KeyName == input && tr.SourceState.StateCore == state.StateCore);
                if (trans != null)
                {
                    frm.Show(trans);
                }
                else
                {
                    fsm.AddOutgoing(state, input);
                    trans = fsm.Transitions.Values.FirstOrDefault(tr => tr.Input.KeyName == input && tr.SourceState.StateCore == state.StateCore);
                    if (trans != null)
                    {
                        if (frm.Show(trans) != System.Windows.Forms.DialogResult.OK)
                        {
                        }
                        if(trans.destinationStates.Count == 0)
                        {
                            if (fsm.Transitions.Remove(trans.ToString()))
                            {
                                UpdateGrid();
                            }
                            else
                            {
                                Debug.WriteLine("Не удаётся откатить добавленый переход.");
                            }
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Переход какбэ добавился и какбэ не добавился!");
                    }
                }
            }
        }

        private void DeleteHandler(TransitionRes<StructAtom<string>, StructAtom<string>> transitionRes, GridEditorButton button)
        {
            if (transitionRes.RemoveFromTransition())
            {
                UpdateGrid();
            }
        }

        private void SetButtonParams(RepositoryItemButtonEdit repositoryItemButtonEdit, int rowHandle, GridColumn column)
        {
            foreach (var button in repositoryItemButtonEdit.Buttons)
            {
                var gridButton = button as GridEditorButton;
                if (gridButton != null)
                    gridButton.SetCell(rowHandle, column);
            }
        }

        void gvEdit_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.Name != "Zs")
            {
                var value = gvEdit.GetRowCellValue(e.RowHandle, e.Column);
                if (value != DBNull.Value)
                {
                    SetButtonParams(transitionRepositoryItem, e.RowHandle, e.Column);
                    e.RepositoryItem = transitionRepositoryItem;
                }
                else
                {
                    SetButtonParams(nonTransitionRepositoryItem, e.RowHandle, e.Column);
                    e.RepositoryItem = nonTransitionRepositoryItem;
                }
            }
        }

        void gvEdit_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            var first = gvEdit.GetRowCellValue(e.RowHandle1, e.Column);
            var second = gvEdit.GetRowCellValue(e.RowHandle2, e.Column);
            if (first != null)
                e.Merge = first.Equals(second) && e.Column.Name == "Zs";
            if (!e.Merge)
            {
                //var firstColVal1 = gvEdit.GetRowCellValue(e.RowHandle1, "Zs");
                //var firstColVal2 = gvEdit.GetRowCellValue(e.RowHandle2, "Zs");
                //e.Merge = firstColVal1.Equals(firstColVal2) && (first == DBNull.Value || second == DBNull.Value);
            }
            e.Handled = true;
        }

        public FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsm { get; set; }

        private RepositoryItemButtonEdit transitionRepositoryItem = new RepositoryItemButtonEdit();
        private RepositoryItemButtonEdit nonTransitionRepositoryItem = new RepositoryItemButtonEdit();

        private DataTable DataTable { get; set; }

        public void SetFSMToView()
        {
            gvEdit.Columns.Clear();

            if (fsm != null)
            {
                GridColumn gc = new GridColumn();
                gc.Caption = "z/a";
                gc.Width = 50;
                gc.Name = "Zs";
                gc.FieldName = "Zs";
                gc.Fixed = FixedStyle.Left;
                gc.VisibleIndex = 0;
                //gc.Visible = true;
                gvEdit.Columns.Add(gc);


                for (int i = 0; i < fsm.StateSet.Length; ++i )
                {
                    var state = fsm.StateSet[i];
                    gc = new GridColumn();
                    gc.Caption = state.ToString();
                    gc.Name = state.KeyName;//ToString();
                    gc.VisibleIndex = i + 1;
                    gc.FieldName = state.ToString();

                    //gc.ColumnEdit = transitionRepositoryItem;

                    gvEdit.Columns.Add(gc);
                }

                leStates.SaveSelectedPosition();
                leStates.Items.Clear();
                leStates.Items.AddRange(fsm.StateSet.Select(s => s.StateCore));
                leStates.SyncControl();
                leStates.RestoreSelectedPosition();

                leInput.SaveSelectedPosition();
                leInput.Items.Clear();
                leInput.Items.AddRange(fsm.InputSet.Select(i => i.KeyName as object));
                leInput.SyncControl();
                leInput.RestoreSelectedPosition();

                leOutput.SaveSelectedPosition();
                leOutput.Items.Clear();
                leOutput.Items.AddRange(fsm.OutputSet.Select(o => o.KeyName as object));
                leOutput.SyncControl();
                leOutput.RestoreSelectedPosition();
            }
            else
            {
                leStates.Items.Clear();
                leStates.SyncControl();
                leInput.Items.Clear();
                leInput.SyncControl();
                leOutput.Items.Clear();
                leOutput.SyncControl();
            }

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            if (fsm != null)
            {
                var dt = FSMDataTableRepresenter.Convert(fsm);
                gridControl1.DataSource = dt;
                DataTable = dt;
            }
            else
            {
                gridControl1.DataSource = null;
                DataTable = null;
            }
        }
    }
}
