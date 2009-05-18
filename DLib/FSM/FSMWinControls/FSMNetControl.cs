﻿using System;
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

            BlockPen = new Pen(Color.Black, 1);
        }

        public FSMNetControl(INetComponentInfosContainer netComponentInfosContainer):this()
        {
            if (netComponentInfosContainer == null) throw new ArgumentNullException("netComponentInfosContainer");

            LogicComponent = netComponentInfosContainer;
        }

        public FSMNetControl(IContainer container):this()
        {
            container.Add(this);
        }

        public INetComponentInfosContainer LogicComponent { get; set; }
        private List<SubMachineBlock> SubMachineBlocks = new List<SubMachineBlock>();
        private Rectangle GBlock;
        private Point InputPoint;

        #region Dimensions
        //TODO: Вынести в константы
        private int Unit
        {
            get { return 50; }
        }
        private int PointRadius
        {
            get { return (int)BlockPen.Width * 2; }
        }

        public int SubFSMBlockSpace
        {
            get { return Unit; }
        }

        public int SubFSMBlockWidth
        {
            get { return Unit * 2; }
        }
        public int SubFSMBlockHeight
        {
            get { return Unit; }
        }
        public int SubFSMBlockRadius
        {
            get { return Unit / 5; }
        }

        public int FBlockWidth
        {
            get { return 2 * Unit / 3; }
        }
        public int FBlockHeigth
        {
            get { return 3 * Unit / 2 + SubMachineBlocks.Count * 10; }
        }
        public int FBlockRadius
        {
            get { return Unit / 8; }
        }

        public int KsiBlockWidth
        {
            get { return 3 * Unit / 2; }
        }
        public int KsiBlockHeigth
        {
            get { return 2 * Unit / 3; }
        }
        public int KsiBlockRadius
        {
            get { return Unit / 8; }
        }

        public int GBlockWidth
        {
            get { return Unit; }
        }
        public int GBlockHeigth
        {
            get { return 5 * SubFSMBlockSpace / 2 + SubMachineBlocks.Count * 20; }
        }
        public int GBlockRadius
        {
            get { return Unit / 8; }
        }


        public double ArrowheadAngle
        {
            get { return Math.PI / 12; }
        }
        public float ArrowheadLength
        {
            get { return Unit / 4; }
        }

        #endregion

        private Pen BlockPen;// = Pens.Black;

        private Brush BlockBrush = Brushes.Black;

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
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;// AntiAlias;

            if (LogicComponent != null)
            {
                InputPoint = new Point(ClientRectangle.Width/20,
                    ClientRectangle.Height / 5);

                Point pt = new Point(InputPoint.X + SubFSMBlockSpace*4,
                                     InputPoint.Y + SubFSMBlockSpace*2 +SubFSMBlockHeight/2 + KsiBlockHeigth);

                SubMachineBlocks.Clear();

                int index = 0;
                foreach (var fsmInfo in LogicComponent.Components)
                {
                    if (index > 0)
                        pt.X += SubFSMBlockSpace * 3 + SubFSMBlockWidth;

                    SubMachineBlock block = new SubMachineBlock(index, this, pt, fsmInfo);
                    SubMachineBlocks.Add(block);
                    DrawSubMachine(e.Graphics, pt, block);

                    ++index;
                }

                var pointG = new Point(pt.X + SubFSMBlockWidth / 2 + SubFSMBlockSpace * 2, pt.Y);
                DrawGBlock(e.Graphics, pointG);
                DrawBoundArrows(e.Graphics, SubMachineBlocks.First(), SubMachineBlocks.Last());
                DrawInputArrows(e.Graphics, InputPoint);

                for (int i = 0; i < SubMachineBlocks.Count; ++i)
                {
                    if (i + 1 < SubMachineBlocks.Count)
                    {
                        DrawArrowsBetweenBlocks(e.Graphics, SubMachineBlocks[i], SubMachineBlocks[i + 1]);
                    }
                }

                foreach (var block in SubMachineBlocks)
                {
                    DrawConnectionArrows(e.Graphics, block, SubMachineBlocks.Except(new[] {block}));
                }

                foreach (var block in SubMachineBlocks.Take(SubMachineBlocks.Count - 1))
                {
                    DrawOutputArrows(e.Graphics, block);
                }
            }

            e.Graphics.SmoothingMode = old;
        }


        private void DrawOutputArrows(Graphics graphics, SubMachineBlock block)
        {
            var dY = (block.No + 1)*10;
            var pt = new Point(block.RightConnector.X + SubFSMBlockSpace / 3,
                              block.RightConnector.Y + SubFSMBlockSpace + dY);

            graphics.DrawArrow(BlockPen, pt.X, pt.Y, GBlock.X, pt.Y, ArrowheadLength, ArrowheadAngle);
        }

        private void DrawInputArrows(Graphics graphics, Point inputPoint)
        {
            DrawPoint(graphics, BlockBrush, inputPoint);

            var pt1 = new Point((SubMachineBlocks.Last().RightConnector.X + GBlock.X) / 2, inputPoint.Y);
            var pt2 = new Point(pt1.X, GBlock.Y + GBlock.Height / 4);

            graphics.DrawLines(BlockPen, new[]
                                             {
                                                 inputPoint,
                                                 pt1,
                                                 pt2
                                             });
            graphics.DrawArrow(BlockPen, pt2.X, pt2.Y, GBlock.X, pt2.Y, ArrowheadLength, ArrowheadAngle);

            foreach (var block in SubMachineBlocks)
            {
                graphics.DrawArrow(BlockPen,
                                   block.TopConnector.X,
                                   inputPoint.Y,
                                   block.TopConnector.X,
                                   block.TopConnector.Y,
                                   ArrowheadLength,
                                   ArrowheadAngle);
            }
        }

        private void DrawConnectionArrows(Graphics graphics, SubMachineBlock block, IEnumerable<SubMachineBlock> destinationBlocks)
        {
            var dY = (block.No + 1)*10;
            var dX = (block.No - 1) * 10;
            
            var pt = new Point(block.RightConnector.X + SubFSMBlockSpace / 3,
                              block.RightConnector.Y + SubFSMBlockSpace + dY);

            DrawPoint(graphics, BlockBrush,
                                     pt.X,
                                     block.RightConnector.Y);

            graphics.DrawLine(BlockPen,
                              pt.X,
                              block.RightConnector.Y,
                              pt.X,
                              pt.Y);

            int minDestNo = destinationBlocks.Min(b => b.No);
            if (block.No > minDestNo)
            {
                if(block.No < SubMachineBlocks.Count - 1)
                DrawPoint(graphics, BlockBrush, pt);

                var firstBlock = destinationBlocks.First(b => b.No == minDestNo);
                graphics.DrawLine(BlockPen,
                                  pt.X,
                                  pt.Y,
                                  firstBlock.LeftConnector.X - SubFSMBlockSpace/2 + dX,
                                  pt.Y
                    );
            }

            int maxDestNo = destinationBlocks.Max(b => b.No);
            if (block.No < maxDestNo - 1)
            {
                var lastBlock = destinationBlocks.First(b => b.No == maxDestNo);
                graphics.DrawLine(BlockPen,
                                  pt.X,
                                  pt.Y,
                                  lastBlock.LeftConnector.X - SubFSMBlockSpace / 2 + dX,
                                  pt.Y
                    );
            }

            foreach (var destinationBlock in destinationBlocks)
            {
                if (destinationBlock.No != block.No + 1)
                {
                    if (destinationBlock.No > 0)
                        DrawPoint(graphics, BlockBrush,
                                         destinationBlock.LeftConnector.X - SubFSMBlockSpace / 2 + dX,
                                         pt.Y);

                    graphics.DrawLine(BlockPen,
                                      destinationBlock.LeftConnector.X - SubFSMBlockSpace/2 + dX,
                                      pt.Y,
                                      destinationBlock.LeftConnector.X - SubFSMBlockSpace/2 + dX,
                                      destinationBlock.LeftConnector.Y + dY
                        );

                    graphics.DrawArrow(BlockPen,
                                       destinationBlock.LeftConnector.X - SubFSMBlockSpace/2 + dX,
                                       destinationBlock.LeftConnector.Y + dY,
                                       destinationBlock.LeftConnector.X,
                                       destinationBlock.LeftConnector.Y + dY,
                                       ArrowheadLength,
                                       ArrowheadAngle
                        );
                }
            }
        }

        private void DrawBoundArrows(Graphics graphics, SubMachineBlock firstBlock, SubMachineBlock lastBlock)
        {
            //graphics.DrawArrow(BlockPen,
            //                   firstBlock.LeftConnector.X - SubFSMBlockSpace,
            //                   firstBlock.LeftConnector.Y,
            //                   firstBlock.LeftConnector.X,
            //                   firstBlock.LeftConnector.Y,
            //                   ArrowheadLength,
            //                   ArrowheadAngle);

            graphics.DrawArrow(BlockPen,
                               lastBlock.RightConnector.X,
                               lastBlock.RightConnector.Y,
                               GBlock.X,
                               GBlock.Y + GBlockHeigth / 2,
                               ArrowheadLength,
                               ArrowheadAngle);
        }

        private void DrawGBlock(Graphics graphics, Point basePoint)
        {
            GBlock = new Rectangle(basePoint.X - GBlockWidth/2,
                                           basePoint.Y - GBlockHeigth/2,
                                           GBlockWidth,
                                           GBlockHeigth);
            graphics.DrawPath(BlockPen, GBlock.ToRoundedRect(GBlockRadius));
        }

        private void DrawArrowsBetweenBlocks(Graphics graphics, SubMachineBlock firstBlock, SubMachineBlock secondBlock)
        {
            graphics.DrawArrow(BlockPen,
                               firstBlock.RightConnector,
                               secondBlock.LeftConnector,
                               ArrowheadLength,
                               ArrowheadAngle);
        }

        private void DrawSubMachine(Graphics graphics, Point point, SubMachineBlock block)
        {
            DrawSubFSMBlock(graphics, point, block);
            DrawFBlock(graphics, point, block);
            DrawKsiBlock(graphics, point, block);
            DrawArrows(graphics, point, block);
        }

        private void DrawSubFSMBlock(Graphics graphics, Point point, SubMachineBlock block)
        {
            graphics.DrawPath(BlockPen, block.FSMBlock.ToRoundedRect(SubFSMBlockRadius));
            graphics.DrawString(block.FSMInfo.KeyName, Font, BlockBrush, point.X, point.Y - Font.Size / 2);
        }

        private void DrawFBlock(Graphics graphics, Point point, SubMachineBlock block)
        {
            graphics.DrawPath(BlockPen, block.F.ToRoundedRect(FBlockRadius));
        }

        private void DrawKsiBlock(Graphics graphics, Point point, SubMachineBlock block)
        {
            graphics.DrawPath(BlockPen, block.Ksi.ToRoundedRect(KsiBlockRadius));
        }

        private void DrawArrows(Graphics graphics, Point point, SubMachineBlock block)
        {
            graphics.DrawArrow(BlockPen,
                block.F.X + block.F.Width,
                block.F.Y + block.F.Height / 2,
                block.FSMBlock.X,
                block.FSMBlock.Y + block.FSMBlock.Height / 2,
                ArrowheadLength,
                ArrowheadAngle);

            graphics.DrawArrow(BlockPen,
                block.Ksi.X + block.Ksi.Width / 2,
                block.Ksi.Y + block.Ksi.Height,
                block.FSMBlock.X + block.FSMBlock.Width / 2,
                block.FSMBlock.Y,
                ArrowheadLength,
                ArrowheadAngle);
        }

        private void DrawPoint(Graphics graphics, Brush brush, Point point)
        {
            DrawPoint(graphics, brush, point.X, point.Y);
        }
        private void DrawPoint(Graphics graphics, Brush brush, int pointX, int pointY)
        {
            graphics.FillEllipse(brush,
                                         pointX - PointRadius,
                                         pointY - PointRadius,
                                         2 * PointRadius,
                                         2 * PointRadius);
        }

        private class SubMachineBlock
        {
            public SubMachineBlock(int No, FSMNetControl control, Point basePoint, FSMInfo fsmInfo)
            {
                if (control == null) throw new ArgumentNullException("control");

                this.No = No;
                this.control = control;
                this.BasePoint = basePoint;
                this.FSMInfo = fsmInfo;

                SolveCoords();
            }
            private void SolveCoords()
            {
                FSMBlock = new Rectangle(BasePoint.X - control.SubFSMBlockWidth / 2, BasePoint.Y - control.SubFSMBlockHeight / 2, control.SubFSMBlockWidth, control.SubFSMBlockHeight);
                F = new Rectangle(BasePoint.X - control.FBlockWidth - control.SubFSMBlockWidth / 2 - control.SubFSMBlockSpace, BasePoint.Y - control.FBlockHeigth / 2, control.FBlockWidth, control.FBlockHeigth);
                Ksi = new Rectangle(BasePoint.X - control.KsiBlockWidth / 2,
                    BasePoint.Y - control.KsiBlockHeigth / 2 - control.SubFSMBlockSpace - control.KsiBlockHeigth,
                    control.KsiBlockWidth,
                    control.KsiBlockHeigth);
            }

            private FSMNetControl control = null;
            private Point BasePoint;

            public FSMInfo FSMInfo { get; private set; }

            public int X { get { return F.X; } }
            public int Y { get { return Ksi.Y; } }

            public Point TopConnector
            {
                get { return new Point(Ksi.X + Ksi.Width / 2, Ksi.Y); }
            }
            public Point BottomConnector
            {
                get { return new Point(FSMBlock.X + FSMBlock.Width / 2, FSMBlock.Y + FSMBlock.Height); }
            }
            public Point LeftConnector
            {
                get { return new Point(F.X, F.Y + F.Height / 2); }
            }
            public Point RightConnector
            {
                get { return new Point(FSMBlock.X + FSMBlock.Width, FSMBlock.Y + FSMBlock.Height / 2); }
            }

            public int No { get; set; }
            public Rectangle FSMBlock { get; set; }
            public Rectangle F { get; set; }
            public Rectangle Ksi { get; set; }
        }
    }
}