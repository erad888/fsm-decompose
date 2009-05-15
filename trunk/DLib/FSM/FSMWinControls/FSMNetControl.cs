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
    public partial class FSMNetControl : UserControl
    {
        public FSMNetControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
           // SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
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

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var old = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = Pens.Black;
            e.Graphics.DrawArrow(pen, 200, 20, 100, 100, 10, Math.PI / 6);
            RectangleF rect = e.Graphics.ClipBounds;
            Rectangle f = ClientRectangle;// Rectangle.Ceiling(rect);
            e.Graphics.DrawPath(pen, f.ToRoundedRect());
            e.Graphics.SmoothingMode = old;
        }


        //private void DrawSubFSMBlock()
        private void DrawSubFSMBlock(Graphics graphics, Point blockCenter)
        {
            graphics.DrawRectangle(BlockPen, blockCenter.X - SubFSMBlockWidth / 2, blockCenter.Y - SubFSMBlockHeight / 2, SubFSMBlockWidth, SubFSMBlockHeight);
        }
    }
}
