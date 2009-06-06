using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using FSM;
using FSM.Representation;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Test
{
    public partial class frmTransitionsEdit : Form
    {
        public frmTransitionsEdit()
        {
            InitializeComponent();
            Init(splitContainerControl1.Panel1);
            InitGrid();
        }

        public void Init(Control control)
        {
            control.Controls.Add(transitionPie);
            //this.Controls.Add(transitionPie);
            transitionPie.Dock = DockStyle.Fill;
        }

        public DialogResult Show(Transition<StructAtom<string>, StructAtom<string>> transition)
        {
            //DataChanged = false;
            Transition = transition;
            PopulateChart();
            PopulateGrid();
            InitRepItems();
            this.ShowDialog();
            return System.Windows.Forms.DialogResult.OK;
        }

        private void InitGrid()
        {
            gvTransitions.OptionsView.AllowCellMerge = false;

            gvTransitions.OptionsCustomization.AllowColumnMoving = false;
            gvTransitions.OptionsCustomization.AllowGroup = false;
            gvTransitions.OptionsCustomization.AllowSort = false;
            gvTransitions.OptionsView.ShowGroupPanel = false;

            gvTransitions.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(gvTransitions_CustomRowCellEditForEditing);
        }

        void gvTransitions_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            var value = gvTransitions.GetRowCellValue(e.RowHandle, e.Column);
            if (value != DBNull.Value)
            {
                switch (e.Column.Name)
                {
                    case "DestinationState":
                        e.RepositoryItem = DestStateRepositoryItem;
                        break;
                    case "Output":
                        e.RepositoryItem = OutputRepositoryItem;
                        break;
                    case "Probability":
                        e.RepositoryItem = ProbabilityRepositoryItem;
                        break;
                }
            }
            else
            {
                e.RepositoryItem = EmptyCellRepositoryItem;
            }
            foreach (var button in (e.RepositoryItem as RepositoryItemButtonEdit).Buttons)
            {
                if(button is GridEditorButton)
                    (button as GridEditorButton).SetCell(e.RowHandle, e.Column);
            }
        }

        private void InitRepItems()
        {
            if (Transition == null)
                throw new NullReferenceException("Transition");

            OutputRepositoryItem.BeginInit();
            //OutputRepositoryItem.Items.AddRange(Transition.destinationStates.Select(t => t.Output).ToArray());
            OutputRepositoryItem.Items.AddRange(Transition.OwnerFSM.OutputSet.ToArray());
            OutputRepositoryItem.Buttons.Add(new GridEditorButton(ButtonPredefines.Combo));
            OutputRepositoryItem.Buttons.Add(EllButton);
            OutputRepositoryItem.Buttons.Add(DeleteButton);
            OutputRepositoryItem.ButtonPressed += RepositoryItem_ButtonPressed;
            OutputRepositoryItem.TextEditStyle = TextEditStyles.DisableTextEditor;
            OutputRepositoryItem.EndInit();

            DestStateRepositoryItem.BeginInit();
            //DestStateRepositoryItem.Items.AddRange(Transition.destinationStates.Select(t => t.DestState).ToArray());
            DestStateRepositoryItem.Items.AddRange(Transition.OwnerFSM.StateSet.ToArray());
            DestStateRepositoryItem.Buttons.Add(new GridEditorButton(ButtonPredefines.Combo));
            DestStateRepositoryItem.Buttons.Add(EllButton);
            DestStateRepositoryItem.Buttons.Add(DeleteButton);
            DestStateRepositoryItem.ButtonPressed += RepositoryItem_ButtonPressed;
            DestStateRepositoryItem.TextEditStyle = TextEditStyles.DisableTextEditor;
            DestStateRepositoryItem.EndInit();

            ProbabilityRepositoryItem.BeginInit();
            ProbabilityRepositoryItem.EditFormat.FormatType = FormatType.Numeric;
            ProbabilityRepositoryItem.Buttons.Add(new GridEditorButton());
            ProbabilityRepositoryItem.Buttons.Add(EllButton);
            ProbabilityRepositoryItem.Buttons.Add(DeleteButton);
            ProbabilityRepositoryItem.Increment = (decimal)0.1;
            ProbabilityRepositoryItem.MinValue = 0;
            ProbabilityRepositoryItem.MaxValue = 1;
            ProbabilityRepositoryItem.ButtonPressed += RepositoryItem_ButtonPressed;
            //ProbabilityRepositoryItem.TextEditStyle = TextEditStyles.DisableTextEditor;
            ProbabilityRepositoryItem.Validating += ProbabilityRepositoryItem_Validating;
            ProbabilityRepositoryItem.EndInit();

            EmptyCellRepositoryItem.BeginInit();
            EmptyCellRepositoryItem.EditFormat.FormatType = FormatType.Numeric;
            EmptyCellRepositoryItem.Buttons.Add(EllButton);
            EmptyCellRepositoryItem.ButtonPressed += RepositoryItem_ButtonPressed;
            EmptyCellRepositoryItem.EndInit();

            gvTransitions.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gvTransitions_CellValueChanged);
        }

        void gvTransitions_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                var gv = sender as GridView;
                if (gv != null)
                {
                    string trResKey = gv.GetRowCellValue(e.RowHandle, "Key") as string;
                    var trRes = Transition.destinationStates.FirstOrDefault(d => d.KeyName == trResKey);
                    if (trRes != null)
                    {
                        var state =
                            gv.GetRowCellValue(e.RowHandle, "DestinationState") as
                            FSMState<StructAtom<string>, StructAtom<string>>;
                        var output = gv.GetRowCellValue(e.RowHandle, "Output") as StructAtom<string>;
                        var probability = (double)gv.GetRowCellValue(e.RowHandle, "Probability");

                        if (state != null && output != null && probability != null)
                        {
                            if (trRes.ChangeValues(state, output, probability))
                            {
                                DataChangedNotify();
                                PopulateChart();
                            }
                            UpdateGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Изменение значения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateGrid();
            }
        }


        void ProbabilityRepositoryItem_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = (sender as SpinEdit).Value <= 0 || (sender as SpinEdit).Value > 1;
        }

        void RepositoryItem_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Delete:
                    DeleteHandler();
                    break;
                case ButtonPredefines.Ellipsis:
                    EllHandler();
                    break;
                case ButtonPredefines.Plus:
                    EllHandler();
                    break;
            }
        }


        private void EllHandler()
        {
            var frm = new TransitionResEdit();
            try
            {
                var destValue = gvTransitions.GetRowCellValue(EllButton.RowHandle, "DestinationState");
                var outValue = gvTransitions.GetRowCellValue(EllButton.RowHandle, "Output");
                var prob = gvTransitions.GetRowCellValue(EllButton.RowHandle, "Probability");

                double availableProb = Transition.ProbabilityOfReject;
                if (destValue != DBNull.Value && outValue != DBNull.Value && prob != DBNull.Value)
                {
                    frm.StateKey = (destValue as FSMState<StructAtom<string>, StructAtom<string>>).KeyName;
                    frm.OutputKey = (outValue as StructAtom<string>).KeyName;
                    frm.Probability = (double)prob;
                    availableProb = (double)prob;
                }

                if (frm.Show(availableProb, Transition.OwnerFSM) ==
                    System.Windows.Forms.DialogResult.OK)
                {
                    if (Transition.AddDestination(frm.TransRes.DestState, frm.TransRes.Output, frm.TransRes.Probability))
                    {
                        DataChangedNotify();
                        UpdateGrid();
                        PopulateChart();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Добавление перехода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteHandler()
        {
            var ds = gvTransitions.GetRowCellValue(DeleteButton.RowHandle, "DestinationState");// as FSMState<StructAtom<string>, StructAtom<string>>;
            var output = gvTransitions.GetRowCellValue(DeleteButton.RowHandle, "Output");
            if (ds != null && output != null)
            {
                var trRes = Transition.destinationStates.FirstOrDefault(t => t.DestState.Equals(ds) && t.Output.Equals(output));
                if (trRes != null)
                {
                    Transition.destinationStates.Remove(trRes);

                    UpdateGrid();
                    PopulateChart();
                    DataChangedNotify();
                }
            }
        }

        public event EventHandler<EventArgs> DataChanged;
        private void DataChangedNotify()
        {
            if (DataChanged != null)
                DataChanged(this, EventArgs.Empty);
        }

        //public bool DataChanged { get; private set; }

        private Transition<StructAtom<string>, StructAtom<string>> Transition = null;

        GridEditorButton PlusButton = new GridEditorButton(ButtonPredefines.Plus);
        GridEditorButton DeleteButton = new GridEditorButton(ButtonPredefines.Delete);
        GridEditorButton EllButton = new GridEditorButton(ButtonPredefines.Ellipsis);

        RepositoryItemComboBox OutputRepositoryItem = new RepositoryItemComboBox();
        RepositoryItemComboBox DestStateRepositoryItem = new RepositoryItemComboBox();
        RepositoryItemSpinEdit ProbabilityRepositoryItem = new RepositoryItemSpinEdit();
        RepositoryItemButtonEdit EmptyCellRepositoryItem = new RepositoryItemButtonEdit();

        private void PopulateGrid()
        {
            GridColumn gc = new GridColumn();
            gc.Name = "DestinationState";
            gc.Caption = "Результирующее состояние";
            gc.FieldName = "DestinationState";
            gc.VisibleIndex = 0;
            gvTransitions.Columns.Add(gc);

            gc = new GridColumn();
            gc.Name = "Output";
            gc.Caption = "Выходной символ";
            gc.FieldName = "Output";
            gc.VisibleIndex = 1;
            gvTransitions.Columns.Add(gc);

            gc = new GridColumn();
            gc.Name = "Probability";
            gc.Caption = "Вероятность";
            gc.FieldName = "Probability";
            gc.VisibleIndex = 2;
            gvTransitions.Columns.Add(gc);

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            gcTransitions.DataSource = FSMDataTableRepresenter.Convert(Transition);
        }

        public void PopulateChart()
        {
            try
            {
                Series series = null;


                for (int i = 0; i < transitionPie.Series.Count; ++i)
                {
                    if (transitionPie.Series[i].Name == "probabilities")
                    {
                        series = transitionPie.Series[i];
                        series.Points.Clear();
                        break;
                    }
                }

                if (series == null)
                {
                    series = new Series("probabilities", ViewType.Pie);
                    transitionPie.Series.Add(series);
                }

                series.ArgumentScaleType = ScaleType.Qualitative;
                series.ValueScaleType = ScaleType.Numerical;

                double probability = 0;
                foreach (var destinationState in Transition.destinationStates)
                {
                    probability += destinationState.Probability;
                    series.Points.Add(new SeriesPoint(destinationState.ToString(), new[] { destinationState.Probability }));
                }
                if (probability < 1)
                    series.Points.Add(new SeriesPoint("Блокировка", new[] { 1 - probability }));

                //transitionPie.Legend.Visible = false;

                // Specify a data filter to explode points.
                SeriesPointFilter filter = new SeriesPointFilter(SeriesPointKey.Value_1,
                                                                 DataFilterCondition.GreaterThanOrEqual, 10);
                ((PieSeriesView)series.View).ExplodedPointsFilters.Add(filter);
                ((PieSeriesView)series.View).ExplodeMode = PieExplodeMode.UseFilters;

                // Specify how series points are located in a pie.
                series.SeriesPointsSorting = SortingMode.Ascending;
                series.SeriesPointsSortingKey = SeriesPointKey.Value_1;
                ((PieSeriesView)series.View).Rotation = 90;

                // Specify label behavior.
                ((PieSeriesLabel)series.Label).Position = PieSeriesLabelPosition.Inside; //TwoColumns;
                ((PiePointOptions)series.PointOptions).PointView = PointView.ArgumentAndValues;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        ChartControl transitionPie = new ChartControl();
    }
}
