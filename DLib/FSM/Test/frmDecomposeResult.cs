using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using FSM;
using FSM.FSMWinControls;
using DecomposeLib;
using ImportExport;

namespace Test
{
    public partial class frmDecomposeResult : Form
    {
        public frmDecomposeResult()
        {
            InitializeComponent();

            InitNetControl();
        }

        FSMNetControl nc = new FSMNetControl();
        public FSMNet<StructAtom<string>, StructAtom<string>> LogicComponent { get; private set; }

        private void InitNetControl()
        {
            nc.Dock = DockStyle.Fill;
            splitContainerControl1.Panel1.Controls.Add(nc);
            nc.SelectedBlockChanged += nc_SelectedBlockChanged;
            this.Shown += new EventHandler(frmDecomposeResult_Shown);
        }

        void frmDecomposeResult_Shown(object sender, EventArgs e)
        {
            nc.Invalidate();
        }

        void nc_SelectedBlockChanged(object sender, EventArgs e)
        {
            lbxc.Items.Clear();

            if (nc.SelectedBlock != null)
            {
                var netComponent = nc.SelectedBlock.Element as FSMNet<StructAtom<string>, StructAtom<string>>.NetComponent;
                if (netComponent != null)
                {
                    gcComponent.Text = "Подавтомат :  " + netComponent.Info.KeyName;
                    if (netComponent.FiniteStateMachine.DecomposeAlg.PIs.ContainsKey(netComponent.FiniteStateMachine.OrderNumber))
                    {
                        var pi = netComponent.FiniteStateMachine.DecomposeAlg.PIs[netComponent.FiniteStateMachine.OrderNumber];
                        if (pi != null)
                        {
                            foreach (var hashSet in pi)
                            {
                                string strItem = "{";
                                foreach (var state in hashSet)
                                {
                                    strItem += state.KeyName + "; ";
                                }
                                strItem += "}";

                                lbxc.Items.Add(strItem);
                            }
                        }

                        //netComponent.FiniteStateMachine.
                    }
                }
            }
        }

        public void Show(FSMNet<StructAtom<string>, StructAtom<string>> logicComponent)
        {
            if (logicComponent == null) throw new ArgumentNullException("logicComponent");

            LogicComponent = logicComponent;
            SyncLComponent();
            this.Show();
            nc.Invalidate();
        }

        private void SyncLComponent()
        {
            nc.LogicComponent = LogicComponent;
            nc.Invalidate();
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            //System.Xml.XmlDocument doc = new XmlDocument();
            //NetXmlWorker w = new NetXmlWorker(LogicComponent);
            //doc.AppendChild(w.CreateXmlNode(doc));
            //doc.Save("test.xml");
            //doc.Load("test.xml");
            //NetXmlWorker w = new NetXmlWorker();
            //w.ParseFromNode(doc.ChildNodes[0]);

            //nc.LogicComponent = w.Value as FSMNet<StructAtom<string>, StructAtom<string>>;
            //return;

            if (LogicComponent != null)
            {
                var frm = new frmStatistics();
                frm.Show(LogicComponent);
            }
            else
                MessageBox.Show("Не выбрана сеть для анализа", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsbtnSaveNet_Click(object sender, EventArgs e)
        {
            if (LogicComponent != null)
            {
                if (NetXmlWorker.SaveNetToFile(LogicComponent))
                    MessageBox.Show("Сеть сохранена", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Не выбрана сеть для сохранения", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsbtnSaveImage_Click(object sender, EventArgs e)
        {
            if (LogicComponent != null)
            {
                try
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "png-файл (*.png)|*.png";

                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        var fi = new System.IO.FileInfo(sfd.FileName);

                        Bitmap bitmap = new Bitmap(nc.Bounds.Width, nc.Bounds.Height);
                        nc.DrawToBitmap(bitmap, nc.Bounds);
                        bitmap.Save(fi.FullName);
                    }
                }
                catch (Exception exc)
                {
                }
            }
            else
                MessageBox.Show("Не выбрана сеть для сохранения", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsbtnLoadNet_Click(object sender, EventArgs e)
        {
            var net = NetXmlWorker.LoadNetFromFile();
            if (net != null)
            {
                LogicComponent = net;
                SyncLComponent();
            }
        }
    }
}
