using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DecomposeLib;
using DevExpress.XtraCharts;
using DevExpress.XtraTab;
using FSM;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Test
{
    public partial class ChartTabPage : XtraTabPage
    {
        public ChartTabPage()
        {
            InitializeComponent();
            Init();
        }
        
        public ChartTabPage(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }

        SplitContainerControl splitContainer = new SplitContainerControl();
        
        public ChartControl chartControlStates = new ChartControl();
        public ChartControl chartControlOutputs = new ChartControl();

        public IFSM<StructAtom<string>, StructAtom<string>> FSM { get; set; }
        public StatisticsResult<StructAtom<string>, StructAtom<string>> FSMResults { get; set; }

        public IFSM<StructAtom<string>, StructAtom<string>> Net { get; set; }
        public StatisticsResult<StructAtom<string>, StructAtom<string>> NetResults { get; set; }

        public void SyncData()
        {
            for (int i = 0; i < chartControlStates.Series.Count; ++i)
            {
                var s = chartControlStates.Series[i];
                s.Points.Clear();
                switch (s.Name)
                {
                    case "serNetStates":
                        s.Points.AddRange(NetResults.StateFrequency.Select(sf => new SeriesPoint(sf.Key.KeyName, new double[] { sf.Value })).ToArray());
                        break;
                    case "serFSMStates":
                        s.Points.AddRange(FSMResults.StateFrequency.Select(sf => new SeriesPoint(sf.Key.KeyName, new double[] { sf.Value })).ToArray());
                        break;
                }
            }

            for (int i = 0; i < chartControlOutputs.Series.Count; ++i)
            {
                var s = chartControlOutputs.Series[i];
                s.Points.Clear();
                switch (s.Name)
                {
                    case "serNetOutputs":
                        s.Points.AddRange(NetResults.OutputFrequency.Select(sf => new SeriesPoint(sf.Key.KeyName, new double[] { sf.Value })).ToArray());
                        break;
                    case "serFSMOutputs":
                        s.Points.AddRange(FSMResults.OutputFrequency.Select(sf => new SeriesPoint(sf.Key.KeyName, new double[] { sf.Value })).ToArray());
                        break;
                }
            }
        }

        private void Init()
        {
            splitContainer.Horizontal = false;
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.LookAndFeel.UseDefaultLookAndFeel = false;
            splitContainer.LookAndFeel.UseWindowsXPTheme = true;

            Controls.Add(splitContainer);

            InitChart();
        }

        private void InitChart()
        {
            chartControlStates.Legend.Visible = true;
            chartControlStates.Location = new System.Drawing.Point(0, 0);
            chartControlStates.Name = "chartControlStates";
            
            Series seriesStates = new Series();
            seriesStates.Name = "serNetStates";
            seriesStates.LegendText = "Сеть";
            seriesStates.PointOptionsTypeName = "PointOptions";
            chartControlStates.Series.Add(seriesStates);
            seriesStates = new Series();
            seriesStates.Name = "serFSMStates";
            seriesStates.LegendText = "Автомат";
            seriesStates.PointOptionsTypeName = "PointOptions";
            chartControlStates.Series.Add(seriesStates);

            chartControlStates.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            chartControlStates.Dock = DockStyle.Fill;
            chartControlStates.Text = "Статистика состояний";
            splitContainer.Panel1.Controls.Add(chartControlStates);


            chartControlOutputs.Legend.Visible = true;
            chartControlOutputs.Location = new System.Drawing.Point(0, 0);
            chartControlOutputs.Name = "chartControlOutputs";
            
            Series seriesOutputs = new Series();
            seriesOutputs.Name = "serNetOutputs";
            seriesOutputs.LegendText = "Сеть";
            seriesOutputs.PointOptionsTypeName = "PointOptions";
            chartControlOutputs.Series.Add(seriesOutputs);

            seriesOutputs = new Series();
            seriesOutputs.Name = "serFSMOutputs";
            seriesOutputs.LegendText = "Автомат";
            seriesOutputs.PointOptionsTypeName = "PointOptions";
            chartControlOutputs.Series.Add(seriesOutputs);

            chartControlOutputs.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            chartControlOutputs.Dock = DockStyle.Fill;
            chartControlOutputs.Text = "Статистика выходных символов";
            splitContainer.Panel2.Controls.Add(chartControlOutputs);
        }
    }
}
