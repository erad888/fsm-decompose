using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DecomposeLib;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using FSM;
using System.Drawing.Imaging;

namespace Test
{
    public partial class frmStatistics : Form
    {
        public frmStatistics()
        {
            InitializeComponent();
            Init();
        }

        //private List<StructAtom<string>> InputSequence = new List<StructAtom<string>>();
        public FSMNet<StructAtom<string>, StructAtom<string>> TargetNet { get; private set; }

        public void Show(FSMNet<StructAtom<string>, StructAtom<string>> target)
        {
            if (target == null) throw new ArgumentNullException("target");

            TargetNet = target;
            SyncInitialState();
            this.Show();
        }

        private void Init()
        {
            seRepeatsNumber.Properties.MinValue = 1;
            seRepeatsNumber.Properties.Increment = 1;
            seRepeatsNumber.Properties.MaxValue = 100000;
            cbxInputSequence.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Plus));
            cbxInputSequence.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cbxInputSequence.Properties.ButtonClick += Properties_ButtonClick;

            tcCharts.HeaderButtons = TabButtons.Close;
            tcCharts.CloseButtonClick += new EventHandler(tcCharts_CloseButtonClick);
            tcCharts.SelectedPageChanged += new TabPageChangedEventHandler(tcCharts_SelectedPageChanged);
        }

        void tcCharts_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            var ctp = e.Page as ChartTabPage;
            if(ctp != null)
            {
                lblNetRejectionCountValue.Text = ctp.NetResults.RejectionCount.ToString();
                lblNetTimeValue.Text = ctp.NetResults.WorkTime.ToString();
                lblFSMRejectionCountValue.Text = ctp.FSMResults.RejectionCount.ToString();
                lblFSMTimeValue.Text = ctp.FSMResults.WorkTime.ToString();
                lblCountOfRepeatsValue.Text = ctp.NetResults.Conditions.RepeatsNumber.ToString();
            }
        }

        void tcCharts_CloseButtonClick(object sender, EventArgs e)
        {
            if(tcCharts.SelectedTabPage != null)
                tcCharts.TabPages.Remove(tcCharts.SelectedTabPage);
        }

        void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Ellipsis:
                case ButtonPredefines.Plus:
                    EllipsisHandle();
                    break;
            }
        }

        private void SyncInitialState()
        {
            cbxInitialState.Properties.Items.Clear();
            cbxInitialState.Properties.Items.AddRange(TargetNet.StateSet);

            if (cbxInitialState.Properties.Items.Count > 0)
                cbxInitialState.SelectedIndex = 0;
        }

        private void EllipsisHandle()
        {
            var frm = new frmInputSeqEdit();
            if (frm.Show(TargetNet.InputSet) == System.Windows.Forms.DialogResult.OK)
            {
                if (frm.Items.Count > 0)
                {
                    var sec = new InputCollection(frm.Items);

                    cbxInputSequence.Properties.Items.Add(sec);

                    if (cbxInputSequence.Properties.Items.Count > 0)
                        cbxInputSequence.SelectedIndex = 0;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ClearResultSection();

                int seed = DateTime.Now.Millisecond;

                TargetNet.SetRandomTicket(seed);
                var netStat = CollectNetStat();

                if (!chbxSyncronize.Checked)
                    seed = DateTime.Now.Millisecond;

                TargetNet.FSM.SetRandomTicket(seed);
                var fsmStat = CollectFSMStat();

                var tp = new ChartTabPage();
                tp.Text = (tcCharts.TabPages.Count + 1).ToString();

                tp.NetResults = netStat;
                tp.Net = TargetNet;
                tp.FSMResults = fsmStat;
                tp.FSM = TargetNet.FSM;
                tp.SyncData();

                tp.chartControlStates.ContextMenuStrip = cmsCharts1;
                tp.chartControlOutputs.ContextMenuStrip = cmsCharts2;

                tcCharts.TabPages.Add(tp);
                tcCharts.SelectedTabPage = tp;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearResultSection()
        {
            lblNetRejectionCountValue.Text = 0.ToString();
            lblNetTimeValue.Text = 0.ToString();
        }

        private StatisticCollectCondition<StructAtom<string>, StructAtom<string>> GetConditions()
        {
            if (TargetNet == null)
                throw new NullReferenceException();

            var inputSec = cbxInputSequence.SelectedItem as InputCollection;
            if (inputSec == null)
                throw new NullReferenceException("Не задана входная последовательность");

            var initState = cbxInitialState.SelectedItem as FSMState<StructAtom<string>, StructAtom<string>>;
            if (initState == null)
                throw new NullReferenceException("Не указано начальное состояние");

            int repeats = (int)seRepeatsNumber.Value;

            return new StatisticCollectCondition<StructAtom<string>, StructAtom<string>>(inputSec.Items) { RepeatsNumber = repeats, InitialState = initState };
        }

        private StatisticsResult<StructAtom<string>, StructAtom<string>> CollectNetStat()
        {
            var conditions = GetConditions();

            var statisticManager = new FSMStatisticManager<StructAtom<string>, StructAtom<string>>(TargetNet);
            var result = statisticManager.CollectStatistics(conditions);

            return result;
        }

        private StatisticsResult<StructAtom<string>, StructAtom<string>> CollectFSMStat()
        {
            var conditions = GetConditions();

            var statisticManager = new FSMStatisticManager<StructAtom<string>, StructAtom<string>>(TargetNet.FSM);
            var result = statisticManager.CollectStatistics(conditions);

            return result;
        }

        private class InputCollection
        {
            public InputCollection()
            {
            }

            public InputCollection(IEnumerable<StructAtom<string>> items)
            {
                Items.AddRange(items);
            }

            public List<StructAtom<string>> Items = new List<StructAtom<string>>();

            public override string ToString()
            {
                const int cnstMax = 4;

                string result = string.Empty;
                //foreach (var item in Items.Take(Math.Min(Items.Count, cnstMax)))
                //{
                //    result += item.KeyName + "; ";
                //}
                //if (Items.Count > cnstMax)
                //    result += "...";

                foreach (var item in Items)
                {
                    result += item.KeyName + "; ";
                }

                return result;
            }
        }

        private void tsmiSaveToFile1_Click(object sender, EventArgs e)
        {
            if (tcCharts.SelectedTabPage != null)
            {
                if (SaveChartToFile((tcCharts.SelectedTabPage as ChartTabPage).chartControlStates))
                    MessageBox.Show("Файл успешно сохранён", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiSaveToFile2_Click(object sender, EventArgs e)
        {
            if (tcCharts.SelectedTabPage != null)
            {
                if (SaveChartToFile((tcCharts.SelectedTabPage as ChartTabPage).chartControlOutputs))
                    MessageBox.Show("Файл успешно сохранён", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool SaveChartToFile(ChartControl chartControl)
        {
            if (chartControl == null) throw new ArgumentNullException("chartControl");

            bool result = false;

            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "bmp-файл (*.bmp)|*.bmp|jpeg-файл (*.jpeg)|*.jpeg|png-файл (*.png)|*.png";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var fi = new System.IO.FileInfo(sfd.FileName);
                    ImageFormat format = null;
                    switch (fi.Extension)
                    {
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        case ".jpeg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                    }
                    if (format != null)
                    {
                        chartControl.ExportToImage(fi.FullName, format);
                        result = true;
                    }
                }
            }
            catch (Exception exc)
            {
                result = false;
            }

            return result;
        }
    }
}
