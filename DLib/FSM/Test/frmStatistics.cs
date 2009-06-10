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
using FSM;

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
        public IFSM<StructAtom<string>, StructAtom<string>> TargetEntity { get; private set; }

        public void Show(IFSM<StructAtom<string>, StructAtom<string>> target)
        {
            if (target == null) throw new ArgumentNullException("target");

            TargetEntity = target;
            SyncInitialState();
            this.Show();
        }

        private void Init()
        {
            seRepeatsNumber.Properties.MinValue = 1;
            seRepeatsNumber.Properties.Increment = 1;
            seRepeatsNumber.Properties.MaxValue = 100000;
            cbxInputSequence.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Ellipsis));
            cbxInputSequence.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cbxInputSequence.Properties.ButtonClick += Properties_ButtonClick;
        }

        void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Ellipsis:
                    EllipsisHandle();
                    break;
            }
        }

        private void SyncInitialState()
        {
            cbxInitialState.Properties.Items.Clear();
            cbxInitialState.Properties.Items.AddRange(TargetEntity.StateSet);

            if (cbxInitialState.Properties.Items.Count > 0)
                cbxInitialState.SelectedIndex = 0;
        }

        private void EllipsisHandle()
        {
            // Тестовая последовательность
            //var tst = new InputCollection(TargetEntity.InputSet);
            //tst.Items.AddRange(TargetEntity.InputSet);
            //tst.Items.AddRange(TargetEntity.InputSet);
            //cbxInputSequence.Properties.Items.Add(tst);

            var frm = new frmInputSeqEdit();
            if (frm.Show(TargetEntity.InputSet) == System.Windows.Forms.DialogResult.OK)
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
            ClearResultSection();

            var stat = CollectStat();

            if (chc.Series.Count > 0)
            {
                var s = chc.Series[0];
                s.Points.Clear();
                
                s.Points.AddRange(stat.StateFrequency.Select(sf => new SeriesPoint(sf.Key.KeyName, new double[] {sf.Value})).ToArray());

                lblRejectionCountValue.Text = stat.RejectionCount.ToString();
            }
        }

        private void ClearResultSection()
        {
            lblRejectionCountValue.Text = 0.ToString();
            lblTimeValue.Text = 0.ToString();
        }

        private StatisticsResult<StructAtom<string>, StructAtom<string>> CollectStat()
        {
            if(TargetEntity == null)
                throw new NullReferenceException();

            var inputSec = cbxInputSequence.SelectedItem as InputCollection;
            if(inputSec == null)
                throw new NullReferenceException();

            var initState = cbxInitialState.SelectedItem as FSMState<StructAtom<string>, StructAtom<string>>;
            if(initState == null)
                throw new NullReferenceException();

            int repeats = (int)seRepeatsNumber.Value;

            var statisticManager = new FSMStatisticManager<StructAtom<string>, StructAtom<string>>(TargetEntity);
            var result = statisticManager.CollectStatistics(new StatisticCollectCondition<StructAtom<string>, StructAtom<string>>(inputSec.Items) { RepeatsNumber = repeats, InitialState = initState});

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
    }
}
