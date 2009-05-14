using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DLib.WinForms.Drawing;

namespace FSM.FSMWinControls
{
    public partial class FSMNetControl : Panel
    {
        public FSMNetControl()
        {
            InitializeComponent();

            base.Paint += new PaintEventHandler(FSMNetControl_Paint);
        }

        //public FSMNetControl()
        //{
            
        //}

        public FSMNetControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //TODO: Вынести в константы
        private float Unit
        {
            get { return 50; }
        }
        public float SubFSMBlockWidth
        {
            get { return 30; }
        }
        public float SubFSMBlockHeight
        {
            get { return 20; }
        }
        public double ArrowheadAngle
        {
            get { return Math.PI / 6; }
        }
        public float ArrowheadLength
        {
            get { return 10; }
        }

        private Pen BlockPen = Pens.Black;

        void FSMNetControl_Paint(object sender, PaintEventArgs e)
        {
            //Pen pen = Pens.Black;
            //e.Graphics.DrawArrow(pen, 200, 20, 100, 100, 10, Math.PI/6);


        }

        //private void DrawSubFSMBlock()
        private void DrawSubFSMBlock(Graphics graphics, Point blockCenter)
        {
            graphics.DrawRectangle(BlockPen, blockCenter.X - SubFSMBlockWidth / 2, blockCenter.Y - SubFSMBlockHeight / 2, SubFSMBlockWidth, SubFSMBlockHeight);
        }
    }
}
