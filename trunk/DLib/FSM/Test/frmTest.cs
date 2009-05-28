using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DecomposeLib;
using FSM;
using LogicUtils;

namespace Test
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            
            fsmNetControl1.LogicComponent = GetNet();
            
        }

        public FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsm = new FiniteStateMachine<StructAtom<string>, StructAtom<string>>();

        public FSMNet<StructAtom<string>, StructAtom<string>> GetNet()
        {

            var z1 = new StructAtom<string>("z1");
            var z2 = new StructAtom<string>("z2");
            var z3 = new StructAtom<string>("z3");
            var z4 = new StructAtom<string>("z4");


            var w1 = new StructAtom<string>("w1");
            var w2 = new StructAtom<string>("w2");
            var w3 = new StructAtom<string>("w3");

            //FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsm =
            //    new FiniteStateMachine<StructAtom<string>, StructAtom<string>>();

            var a1 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a1);
            var a2 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a2);
            var a3 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a3);
            var a4 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a4);
            var a5 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a5);
            var a6 = new FSMState<StructAtom<string>, StructAtom<string>>(fsm, StateCores.a6);

            fsm.AddState(a1);
            fsm.AddState(a2);
            fsm.AddState(a3);
            fsm.AddState(a4);
            fsm.AddState(a5);
            fsm.AddState(a6);

            fsm.AddOutgoing(a1, z1, a1, w2, 0.5);
            fsm.AddOutgoing(a1, z1, a2, w1, 0.5);
            fsm.AddOutgoing(a1, z2, a6, w2);
            fsm.AddOutgoing(a1, z3, a6, w1);
            fsm.AddOutgoing(a1, z4, a2, w3);

            fsm.AddOutgoing(a2, z1, a5, w2);
            fsm.AddOutgoing(a2, z2, a1, w1);
            fsm.AddOutgoing(a2, z3, a1, w1);
            fsm.AddOutgoing(a2, z4, a5, w3);

            fsm.AddOutgoing(a3, z1, a1, w1);
            fsm.AddOutgoing(a3, z2, a5, w3);
            fsm.AddOutgoing(a3, z3, a5, w1);
            fsm.AddOutgoing(a3, z4, a1, w1);

            fsm.AddOutgoing(a4, z1, a6, w1);
            fsm.AddOutgoing(a4, z2, a2, w2);
            fsm.AddOutgoing(a4, z3, a2, w2);
            fsm.AddOutgoing(a4, z4, a6, w3);

            fsm.AddOutgoing(a5, z1, a1, w3);
            fsm.AddOutgoing(a5, z2, a1, w1);
            fsm.AddOutgoing(a5, z3, a2, w3);
            fsm.AddOutgoing(a5, z4, a4, w1);

            fsm.AddOutgoing(a6, z1, a2, w2);
            fsm.AddOutgoing(a6, z2, a6, w2);
            fsm.AddOutgoing(a6, z3, a5, w3);
            fsm.AddOutgoing(a6, z4, a3, w1);

            fsm.InitialState = a1;

            List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>> pis =
                new List<Partition<FSMState<StructAtom<string>, StructAtom<string>>>>();

            var pi1 = new Partition<FSMState<StructAtom<string>, StructAtom<string>>>();
            pi1.Add(new[]
                        {
                            a1,
                            a2,
                            a3,
                            a4
                        });
            pi1.Add(new[]
                        {
                            a5,
                            a6
                        });

            var pi2 = new Partition<FSMState<StructAtom<string>, StructAtom<string>>>();
            pi2.Add(new[]
                        {
                            a1,
                            a2,
                            a5,
                            a6
                        });
            pi2.Add(new[]
                        {
                            a3,
                            a4
                        });

            var pi3 = new Partition<FSMState<StructAtom<string>, StructAtom<string>>>();
            pi3.Add(new[]
                        {
                            a1,
                            a3,
                            a5
                        });
            pi3.Add(new[]
                        {
                            a2,
                            a4,
                            a6
                        });

            DecompositionAlgorithm<StructAtom<string>, StructAtom<string>> alg =
                new DecompositionAlgorithm<StructAtom<string>, StructAtom<string>>(fsm, new[] { pi1, pi2, pi3 });

            return alg.Solve();
        }

        private enum StateCores
        {
            a1 = 0,
            a2,
            a3,
            a4,
            a5,
            a6,
        }

        private void Init()
        {
            Enum x1 = X.x1; Enum x2 = X.x2; Enum x3 = X.x3;

            //TODO: Добавить средства для добавления отношений типа ksi: Z -> X
            FiniteStateMachine<StructAtom<Enum>, StructAtom<Enum>> S1 = new FiniteStateMachine<StructAtom<Enum>, StructAtom<Enum>>();
            FSMState<StructAtom<Enum>, StructAtom<Enum>> b1 = new FSMState<StructAtom<Enum>, StructAtom<Enum>>(S1, B.b1);
            FSMState<StructAtom<Enum>, StructAtom<Enum>> b2 = new FSMState<StructAtom<Enum>, StructAtom<Enum>>(S1, B.b2);
            FSMState<StructAtom<Enum>, StructAtom<Enum>> b3 = new FSMState<StructAtom<Enum>, StructAtom<Enum>>(S1, B.b3);

            S1.AddOutgoing(b1, new StructAtom<Enum>(x1), b1, (StructAtom<Enum>)b1.StateCore);
            S1.AddOutgoing(b1, new StructAtom<Enum>(x2), b3);
            S1.AddOutgoing(b1, new StructAtom<Enum>(x3), b3);

            S1.AddOutgoing(b2, new StructAtom<Enum>(x1), b1);
            S1.AddOutgoing(b2, new StructAtom<Enum>(x2), b2);
            S1.AddOutgoing(b2, new StructAtom<Enum>(x3), b2);

            S1.AddOutgoing(b3, new StructAtom<Enum>(x1), b3);
            S1.AddOutgoing(b3, new StructAtom<Enum>(x2), b3);
            S1.AddOutgoing(b3, new StructAtom<Enum>(x3), b1);
        }

        enum B
        {
            b1,
            b2,
            b3
        }

        enum X
        {
            x1,
            x2,
            x3
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFSMEdit frm = new frmFSMEdit();
            frm.fsm = fsm;
            frm.SetFSMToView();
            frm.Show();
        }
    }
}
