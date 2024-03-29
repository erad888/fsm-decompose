﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DecomposeLib;
using FSM;
using LogicUtils;
using ImportExport;

namespace Test
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            
            InitListEdit(leFSMs);

            tbxFSMName.Validated += tbxFSMName_Validated;
            
            SetEnabledStatus(false);
        }

        void tbxFSMName_Validated(object sender, EventArgs e)
        {
            if (fsmEditControl.fsm != null)
            {
                if (tbxFSMName.Text.Trim() != string.Empty)
                {
                    var f = FSMs.FirstOrDefault(s => s.KeyName == tbxFSMName.Text.Trim());
                    if (f == null || f == fsmEditControl.fsm)
                        fsmEditControl.fsm.KeyName = tbxFSMName.Text.Trim();
                    else
                        MessageBox.Show("Автомат с таким именем уже существует", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                UpdateFSMList();
            }
        }

        private void SetEnabledStatus(bool value)
        {
            fsmEditControl.Enabled = value;
            tbxFSMName.Enabled = value;
            btnDecompose.Enabled = value;
            tsbtnSaveFSM.Enabled = value;
            tsbtnToExcel.Enabled = value;
            DecomposeToolStripMenuItem.Enabled = value;
            ExportToExcelToolStripMenuItem.Enabled = value;
        }

        private void InitListEdit(ListEdit le)
        {
            le.CreationRule = s => new FiniteStateMachine<StructAtom<string>, StructAtom<string>>(s);
            le.ItemAdded += le_ItemAdded;
            le.ItemRemoved += le_ItemRemoved;
            le.SelectedValueChanged += le_SelectedValueChanged;
            le.gcMain.Text = "Список автоматов";
        }

        void le_SelectedValueChanged(object sender, TemplateEventArgs<object> e)
        {
            var fsm = e.Value as FiniteStateMachine<StructAtom<string>, StructAtom<string>>;
            fsmEditControl.fsm = fsm;
            fsmEditControl.SetFSMToView();
            if (fsm != null)
            {
                label1.Text = "Выбранный автомат";
                tbxFSMName.Text = fsm.KeyName;
                gcFSMEdit.Text = "    Автомат :  " + fsm.KeyName;
            }
            else
            {
                label1.Text = "Создайте или загрузите автомат.";
                tbxFSMName.Text = string.Empty;
                gcFSMEdit.Text = string.Empty;
            }
            SetEnabledStatus(fsmEditControl.fsm != null);
        }

        private void UpdateFSMList()
        {
            try
            {
                leFSMs.SaveSelectedPosition();
                leFSMs.Items.Clear();
                leFSMs.Items.AddRange(FSMs.ToArray());
                leFSMs.SyncControl();
                leFSMs.RestoreSelectedPosition();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка обновления окна: " + exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        List<FiniteStateMachine<StructAtom<string>, StructAtom<string>>> FSMs = new List<FiniteStateMachine<StructAtom<string>, StructAtom<string>>>();

        void le_ItemRemoved(object sender, TemplateEventArgs<object> e)
        {
            var fsm = e.Value as FiniteStateMachine<StructAtom<string>, StructAtom<string>>;
            if (fsm != null)
            {
                var f = FSMs.FirstOrDefault(s => s.KeyName == fsm.KeyName);
                if (f != null)
                {
                    if (FSMs.Remove(f))
                    {
                        UpdateFSMList();
                    }
                    else
                        e.Cancel = true;
                }
                else
                    e.Cancel = true;
            }
        }

        void le_ItemAdded(object sender, TemplateEventArgs<object> e)
        {
            var fsm = e.Value as FiniteStateMachine<StructAtom<string>, StructAtom<string>>;
            if (fsm != null)
            {
                var f = FSMs.FirstOrDefault(s => s.KeyName == fsm.KeyName);
                if (f == null)
                {
                    FSMs.Add(fsm);
                    UpdateFSMList();
                }
                else
                    e.Cancel = true;
            }
            else
                e.Cancel = true;
        }

        //public FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsm = new FiniteStateMachine<StructAtom<string>, StructAtom<string>>("fsm");

        //private void InitTestFSM()
        //{
        //    var z1 = new StructAtom<string>("z1");
        //    var z2 = new StructAtom<string>("z2");
        //    var z3 = new StructAtom<string>("z3");
        //    var z4 = new StructAtom<string>("z4");


        //    var w1 = new StructAtom<string>("w1");
        //    var w2 = new StructAtom<string>("w2");
        //    var w3 = new StructAtom<string>("w3");

        //    var a1 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a1.ToString());
        //    var a2 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a2.ToString());
        //    var a3 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a3.ToString());
        //    var a4 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a4.ToString());
        //    var a5 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a5.ToString());
        //    var a6 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a6.ToString());

        //    fsm.AddState(a1);
        //    fsm.AddState(a2);
        //    fsm.AddState(a3);
        //    fsm.AddState(a4);
        //    fsm.AddState(a5);
        //    fsm.AddState(a6);
        //    //
        //    fsm.AddOutgoing(a1, z1, a1, w2, 0.5);
        //    fsm.AddOutgoing(a1, z1, a2, w1, 0.5);
            
        //    fsm.AddOutgoing(a1, z2, a6, w2);
            
        //    fsm.AddOutgoing(a1, z3, a6, w1);
            
        //    fsm.AddOutgoing(a1, z4, a2, w3);
        //    //
        //    fsm.AddOutgoing(a2, z1, a5, w2, 0.3);
        //    fsm.AddOutgoing(a2, z1, a1, w2, 0.2);
        //    fsm.AddOutgoing(a2, z1, a2, w2, 0.3);

        //    fsm.AddOutgoing(a2, z2, a1, w1, 0.2);
        //    fsm.AddOutgoing(a2, z2, a2, w2, 0.2);
        //    fsm.AddOutgoing(a2, z2, a3, w3, 0.2);
        //    fsm.AddOutgoing(a2, z2, a4, w3, 0.2);
            
        //    fsm.AddOutgoing(a2, z3, a1, w1);
            
        //    fsm.AddOutgoing(a2, z4, a5, w3, 0.7);
        //    fsm.AddOutgoing(a2, z4, a6, w2, 0.3);
        //    //
        //    fsm.AddOutgoing(a3, z1, a1, w1, 0.6);
        //    fsm.AddOutgoing(a3, z1, a2, w1, 0.2);
            
        //    fsm.AddOutgoing(a3, z2, a5, w3, 0.8);
        //    fsm.AddOutgoing(a3, z2, a2, w3, 0.1);
            
        //    fsm.AddOutgoing(a3, z3, a5, w1, 0.9);
        //    fsm.AddOutgoing(a3, z3, a6, w1, 0.1);
            
        //    fsm.AddOutgoing(a3, z4, a1, w1, 0.5);
        //    fsm.AddOutgoing(a3, z4, a2, w2, 0.5);
        //    //
        //    fsm.AddOutgoing(a4, z1, a6, w1);
            
        //    fsm.AddOutgoing(a4, z2, a2, w2, 0.8);
            
        //    fsm.AddOutgoing(a4, z3, a2, w2, 0.6);
        //    //fsm.AddOutgoing(a4, z3, a2, w2, 0.4);
            
        //    fsm.AddOutgoing(a4, z4, a6, w3);
        //    //
        //    fsm.AddOutgoing(a5, z1, a1, w3);
            
        //    fsm.AddOutgoing(a5, z2, a1, w1, 0.3);
        //    fsm.AddOutgoing(a5, z2, a2, w2, 0.7);
            
        //    fsm.AddOutgoing(a5, z3, a2, w3, 0.8);
        //    fsm.AddOutgoing(a5, z3, a3, w3, 0.2);
            
        //    fsm.AddOutgoing(a5, z4, a4, w1, 0.9);
        //    //
        //    fsm.AddOutgoing(a6, z1, a2, w2, 0.6);
        //    fsm.AddOutgoing(a6, z1, a1, w2, 0.1);
        //    fsm.AddOutgoing(a6, z1, a3, w3, 0.1);
        //    fsm.AddOutgoing(a6, z1, a4, w3, 0.1);
        //    fsm.AddOutgoing(a6, z1, a5, w1, 0.1);
            
        //    fsm.AddOutgoing(a6, z2, a6, w2);
            
        //    fsm.AddOutgoing(a6, z3, a5, w3, 0.7);
        //    fsm.AddOutgoing(a6, z3, a6, w3, 0.3);
            
        //    fsm.AddOutgoing(a6, z4, a3, w1);
        //    //
        //    fsm.InitialState = a1;
        //}

        //public FSMNet<StructAtom<string>, StructAtom<string>> GetNet()
        //{

        //    var z1 = new StructAtom<string>("z1");
        //    var z2 = new StructAtom<string>("z2");
        //    var z3 = new StructAtom<string>("z3");
        //    var z4 = new StructAtom<string>("z4");


        //    var w1 = new StructAtom<string>("w1");
        //    var w2 = new StructAtom<string>("w2");
        //    var w3 = new StructAtom<string>("w3");

        //    //FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsm =
        //    //    new FiniteStateMachine<StructAtom<string>, StructAtom<string>>();

        //    var a1 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a1.ToString());
        //    var a2 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a2.ToString());
        //    var a3 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a3.ToString());
        //    var a4 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a4.ToString());
        //    var a5 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a5.ToString());
        //    var a6 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a6.ToString());

        //    fsm.AddState(a1);
        //    fsm.AddState(a2);
        //    fsm.AddState(a3);
        //    fsm.AddState(a4);
        //    fsm.AddState(a5);
        //    fsm.AddState(a6);

        //    fsm.AddOutgoing(a1, z1, a1, w2, 0.5);
        //    fsm.AddOutgoing(a1, z1, a2, w1, 0.5);
        //    fsm.AddOutgoing(a1, z2, a6, w2);
        //    fsm.AddOutgoing(a1, z3, a6, w1);
        //    fsm.AddOutgoing(a1, z4, a2, w3);

        //    fsm.AddOutgoing(a2, z1, a5, w2);
        //    fsm.AddOutgoing(a2, z2, a1, w1);
        //    fsm.AddOutgoing(a2, z3, a1, w1);
        //    fsm.AddOutgoing(a2, z4, a5, w3);

        //    fsm.AddOutgoing(a3, z1, a1, w1);
        //    fsm.AddOutgoing(a3, z2, a5, w3);
        //    fsm.AddOutgoing(a3, z3, a5, w1);
        //    fsm.AddOutgoing(a3, z4, a1, w1);

        //    fsm.AddOutgoing(a4, z1, a6, w1);
        //    fsm.AddOutgoing(a4, z2, a2, w2);
        //    fsm.AddOutgoing(a4, z3, a2, w2);
        //    fsm.AddOutgoing(a4, z4, a6, w3);

        //    fsm.AddOutgoing(a5, z1, a1, w3);
        //    fsm.AddOutgoing(a5, z2, a1, w1);
        //    fsm.AddOutgoing(a5, z3, a2, w3);
        //    fsm.AddOutgoing(a5, z4, a4, w1);

        //    fsm.AddOutgoing(a6, z1, a2, w2);
        //    fsm.AddOutgoing(a6, z2, a6, w2);
        //    fsm.AddOutgoing(a6, z3, a5, w3);
        //    fsm.AddOutgoing(a6, z4, a3, w1);

        //    fsm.InitialState = a1;

        //    List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>> pis =
        //        new List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>>();

        //    var pi1 = new Partition<FSMState<StructAtom<string>, StructAtom<string>>>();
        //    pi1.Add(new[]
        //                {
        //                    a1,
        //                    a2,
        //                    a3,
        //                    a4
        //                });
        //    pi1.Add(new[]
        //                {
        //                    a5,
        //                    a6
        //                });

        //    var pi2 = new Partition<FSMState<StructAtom<string>, StructAtom<string>>>();
        //    pi2.Add(new[]
        //                {
        //                    a1,
        //                    a2,
        //                    a5,
        //                    a6
        //                });
        //    pi2.Add(new[]
        //                {
        //                    a3,
        //                    a4
        //                });

        //    var pi3 = new Partition<FSMState<StructAtom<string>, StructAtom<string>>>();
        //    pi3.Add(new[]
        //                {
        //                    a1,
        //                    a3,
        //                    a5
        //                });
        //    pi3.Add(new[]
        //                {
        //                    a2,
        //                    a4,
        //                    a6
        //                });

        //    DecompositionAlgorithm<StructAtom<string>, StructAtom<string>> alg =
        //        new DecompositionAlgorithm<StructAtom<string>, StructAtom<string>>(fsm, new[] { pi1, pi2, pi3 });

        //    return alg.Solve();
        //}

        //private enum StateCores
        //{
        //    a1 = 0,
        //    a2,
        //    a3,
        //    a4,
        //    a5,
        //    a6,
        //}

        //private void Init()
        //{
        //    Enum x1 = X.x1; Enum x2 = X.x2; Enum x3 = X.x3;

        //    //TODO: Добавить средства для добавления отношений типа ksi: Z -> X
        //    FiniteStateMachine<StructAtom<Enum>, StructAtom<Enum>> S1 = new FiniteStateMachine<StructAtom<Enum>, StructAtom<Enum>>("a");
        //    FSMState<StructAtom<Enum>, StructAtom<Enum>> b1 = new FSMState<StructAtom<Enum>, StructAtom<Enum>>(S1, B.b1);
        //    FSMState<StructAtom<Enum>, StructAtom<Enum>> b2 = new FSMState<StructAtom<Enum>, StructAtom<Enum>>(S1, B.b2);
        //    FSMState<StructAtom<Enum>, StructAtom<Enum>> b3 = new FSMState<StructAtom<Enum>, StructAtom<Enum>>(S1, B.b3);

        //    S1.AddOutgoing(b1, new StructAtom<Enum>(x1), b1, (StructAtom<Enum>)b1.StateCore);
        //    S1.AddOutgoing(b1, new StructAtom<Enum>(x2), b3);
        //    S1.AddOutgoing(b1, new StructAtom<Enum>(x3), b3);

        //    S1.AddOutgoing(b2, new StructAtom<Enum>(x1), b1);
        //    S1.AddOutgoing(b2, new StructAtom<Enum>(x2), b2);
        //    S1.AddOutgoing(b2, new StructAtom<Enum>(x3), b2);

        //    S1.AddOutgoing(b3, new StructAtom<Enum>(x1), b3);
        //    S1.AddOutgoing(b3, new StructAtom<Enum>(x2), b3);
        //    S1.AddOutgoing(b3, new StructAtom<Enum>(x3), b1);
        //}

        //enum B
        //{
        //    b1,
        //    b2,
        //    b3
        //}

        //enum X
        //{
        //    x1,
        //    x2,
        //    x3
        //}

        private void btnDecompose_Click(object sender, EventArgs e)
        {
            if (fsmEditControl.fsm != null)
            {
                if (fsmEditControl.fsm.CheckInitialization())
                {
                    var frm = new frmOrtPartitionSetEdit();
                    if (frm.Show(fsmEditControl.fsm) == System.Windows.Forms.DialogResult.OK)
                    {
                        FSMNet<StructAtom<string>, StructAtom<string>> net = null;
                        try
                        {
                            var alg =
                                new DecompositionAlgorithm<StructAtom<string>, StructAtom<string>>(fsmEditControl.fsm,
                                                                                                   frm.Partitions);
                            net = alg.Solve();

                        }
                        catch (Exception exc)
                        {
                            net = null;
                            MessageBox.Show("Ошибка при декомпозиции автомата: " + exc.Message, this.Text,
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (net != null)
                        {
                            var frmResult = new frmDecomposeResult();
                            frmResult.Show(net);
                        }
                    }
                }
                else
                    MessageBox.Show("Текущий автомат не до конца инициализирован", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Не выбран автомат для декомпозиции", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsbtnSaveFSM_Click(object sender, EventArgs e)
        {
            if (fsmEditControl.fsm != null)
            {
                if (FSMXmlWorker.SaveFSMToFile(fsmEditControl.fsm))
                    MessageBox.Show("Автомат сохранён", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не выбран автомат для сохранения", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbtnLoadFSM_Click(object sender, EventArgs e)
        {
            var fsm = FSMXmlWorker.LoadFSMFromFile();
            if (fsm != null)
            {
                var f = FSMs.FirstOrDefault(s => s.KeyName == fsm.KeyName);
                if (f == null)
                {
                    FSMs.Add(fsm);
                    UpdateFSMList();
                    leFSMs.SetSelectedPosition(leFSMs.Items.Count - 1);
                }
                else
                    MessageBox.Show("Автомат с таким именем уже существует", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbtnDecompose_Click(object sender, EventArgs e)
        {
            var frm = new frmDecomposeResult();
            frm.Show();
        }

        private void tsbtnToExcel_Click(object sender, EventArgs e)
        {
            if (fsmEditControl.fsm != null)
            {
                try
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "excel-файл (*.xls)|*.xls";

                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        var fi = new System.IO.FileInfo(sfd.FileName);
                        fsmEditControl.gridControl1.ExportToXls(sfd.FileName);
                    }
                }
                catch (Exception exc)
                {
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
