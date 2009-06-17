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
            InitHandlers();

            SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            BlockPen = new Pen(Color.Black, 1);
        }

        private void InitHandlers()
        {
            this.MouseClick += new MouseEventHandler(FSMNetControl_MouseClick);
            //this.MouseMove += FSMNetControl_MouseClick;
            //this.MouseMove += new MouseEventHandler(FSMNetControl_MouseMove);
        }

        void FSMNetControl_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var block in SubMachineBlocks.Values)
            {
                if (block.BoundRect.Contains(e.X, e.Y))
                    Cursor = Cursors.Hand;
                else
                    Cursor = Cursors.Arrow;
            }
        }

        void FSMNetControl_MouseClick(object sender, MouseEventArgs e)
        {
            var oldSelected = SelectedBlock;

            SelectedBlock = null;
            foreach (var subMachineBlock in SubMachineBlocks.Values)
            {
                if (subMachineBlock.BoundRect.Contains(e.X, e.Y))
                {
                    subMachineBlock.SetPenWidth(2);
                    SelectedBlock = subMachineBlock.FSMInfo;
                }
                else
                {
                    subMachineBlock.SetPenWidth(1);
                }
                Invalidate();
            }

            if (SelectedBlock != oldSelected)
                NotifySelectedBlockChanged();
        }

        public event EventHandler<EventArgs> SelectedBlockChanged;
        private void NotifySelectedBlockChanged()
        {
            if (SelectedBlockChanged != null)
                SelectedBlockChanged(this, EventArgs.Empty);
        }

        public FSMInfo SelectedBlock { get; private set; }

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
        private Dictionary<string, SubMachineBlock> SubMachineBlocks = new Dictionary<string, SubMachineBlock>();
        private Rectangle GBlock;
        private Point InputPoint;

        #region Dimensions
        //TODO: Вынести в константы
        private int Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private int unit = 50;
        private const double cnstRatio = 0.9;

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
            get { return 5 * SubFSMBlockSpace / 2 + SubMachineBlocks.Values.Where(b=>b.Exists).Count() * 20; }
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

        private Size CalcSize()
        {
            var result = new Size();
            int width = SubMachineBlocks.Count * (SubFSMBlockSpace * 2 + SubFSMBlockWidth + FBlockWidth);
            width += 3 * SubFSMBlockSpace + GBlockWidth;
            var heigth = SubFSMBlockSpace + GBlockHeigth;
            result.Width = width;
            result.Height = heigth;
            return result;
        }

        public void Reset()
        {
            flag = false;
        }

        bool flag = false;

        protected override void OnPaint(PaintEventArgs e)
        {
            var old = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;// AntiAlias;

            if (LogicComponent != null)
            {
                var size = CalcSize();

                if (Size.Width > 0 && Size.Height > 0)
                {
                    double widthRatio = (double)size.Width/Size.Width;
                    double heigthRatio = (double)size.Height/Size.Height;

                    double k = cnstRatio / Math.Max(widthRatio, heigthRatio);
                    unit = (int)(unit*k);

                    size = CalcSize();
                }

                InputPoint = new Point((Size.Width - size.Width) / 2, (Size.Height - size.Height) / 2);

                Point pt = new Point(InputPoint.X + SubFSMBlockSpace*4,
                                     InputPoint.Y + SubFSMBlockSpace*2 +SubFSMBlockHeight/2 + KsiBlockHeigth);

                //SubMachineBlocks.Clear();
                foreach (var block in SubMachineBlocks.Values)
                {
                    block.Exists = false;
                }

                int index = 0;
                foreach (var fsmInfo in LogicComponent.Components)
                {
                    if (index > 0)
                        pt.X += SubFSMBlockSpace * 3 + SubFSMBlockWidth;

                    SubMachineBlock block = null;
                    if (SubMachineBlocks.ContainsKey(fsmInfo.KeyName))
                    {
                        block = SubMachineBlocks[fsmInfo.KeyName];
                        block.SolveCoords(pt);
                        block.Exists = true;
                    }
                    else
                    {
                        block = new SubMachineBlock(index, this, pt, fsmInfo);
                        block.Exists = true;
                        SubMachineBlocks.Add(block.KeyName, block);
                    }
                    DrawSubMachine(e.Graphics, pt, block);

                    ++index;
                }

                foreach (var blockKeyToDelete in SubMachineBlocks.Where(b=> !b.Value.Exists).Select(b=>b.Key).ToArray())
                {
                    SubMachineBlocks.Remove(blockKeyToDelete);
                }

                var pointG = new Point(pt.X + SubFSMBlockWidth / 2 + SubFSMBlockSpace * 2, pt.Y);
                DrawGBlock(e.Graphics, pointG);
                DrawOutputArrow(e.Graphics);
                DrawBoundArrows(e.Graphics, SubMachineBlocks.Values.First(), SubMachineBlocks.Values.Last());
                DrawInputArrows(e.Graphics, InputPoint);

                for (int i = 0; i < SubMachineBlocks.Count; ++i)
                {
                    if (i + 1 < SubMachineBlocks.Count)
                    {
                        DrawArrowsBetweenBlocks(e.Graphics, SubMachineBlocks.Values.ElementAt(i), SubMachineBlocks.Values.ElementAt(i + 1));
                    }
                }

                foreach (var block in SubMachineBlocks.Values)
                {
                    DrawConnectionArrows(e.Graphics, block, SubMachineBlocks.Values.Except(new[] {block}));
                }

                foreach (var block in SubMachineBlocks.Values.Take(SubMachineBlocks.Count - 1))
                {
                    DrawOutputArrows(e.Graphics, block);
                }

                if (!flag)
                {
                    flag = true;
                    Invalidate();
                }
            }

            e.Graphics.SmoothingMode = old;
        }

        private void DrawOutputArrows(Graphics graphics, SubMachineBlock block)
        {
            var dY = (block.No + 1)*10;
            var pt = new Point(block.RightConnector.X + SubFSMBlockSpace / 3,
                              block.RightConnector.Y + SubFSMBlockSpace + dY);

            graphics.DrawArrow(block.ArrowPen, pt.X, pt.Y, GBlock.X, pt.Y, ArrowheadLength, ArrowheadAngle);
        }

        private void DrawInputArrows(Graphics graphics, Point inputPoint)
        {
            DrawPoint(graphics, BlockBrush, inputPoint);

            var pt1 = new Point((SubMachineBlocks.Values.Last().RightConnector.X + GBlock.X) / 2, inputPoint.Y);
            var pt2 = new Point(pt1.X, GBlock.Y + GBlock.Height / 4);

            graphics.DrawLines(BlockPen, new[]
                                             {
                                                 inputPoint,
                                                 pt1,
                                                 pt2
                                             });
            graphics.DrawArrow(BlockPen, pt2.X, pt2.Y, GBlock.X, pt2.Y, ArrowheadLength, ArrowheadAngle);
            
            foreach (var block in SubMachineBlocks.Values)
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

            graphics.DrawLine(block.ArrowPen,
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
                graphics.DrawLine(block.ArrowPen,
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
                graphics.DrawLine(block.ArrowPen,
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

                    graphics.DrawLine(block.ArrowPen,
                                      destinationBlock.LeftConnector.X - SubFSMBlockSpace/2 + dX,
                                      pt.Y,
                                      destinationBlock.LeftConnector.X - SubFSMBlockSpace/2 + dX,
                                      destinationBlock.LeftConnector.Y + dY
                        );

                    graphics.DrawArrow(block.ArrowPen,
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

            graphics.DrawArrow(lastBlock.ArrowPen,
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
            Point center = new Point(GBlock.X + GBlock.Width / 2, GBlock.Y + GBlock.Height / 2);
            graphics.DrawString("G", Font, BlockBrush, center.X - (int)(Font.Size) / 2, center.Y - Font.Size);
        }

        private void DrawOutputArrow(Graphics graphics)
        {
            graphics.DrawArrow(BlockPen,
                GBlock.X + GBlock.Width,
                GBlock.Y + GBlock.Height / 2,
                GBlock.X + GBlock.Width + SubFSMBlockSpace,
                GBlock.Y + GBlock.Height / 2,
                ArrowheadLength,
                ArrowheadAngle);
        }

        private void DrawArrowsBetweenBlocks(Graphics graphics, SubMachineBlock firstBlock, SubMachineBlock secondBlock)
        {
            graphics.DrawArrow(firstBlock.ArrowPen,
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

            //graphics.DrawRectangle(BlockPen, block.BoundRect);
        }

        private void DrawSubFSMBlock(Graphics graphics, Point point, SubMachineBlock block)
        {
            graphics.DrawPath(block.FSMBlockPen, block.FSMBlock.ToRoundedRect(SubFSMBlockRadius));
            graphics.DrawString(block.FSMInfo.KeyName, Font, BlockBrush, point.X - ((int)(block.FSMInfo.KeyName.Length * 0.8 * Font.Size)) / 2, point.Y - Font.Size);
        }

        private void DrawFBlock(Graphics graphics, Point point, SubMachineBlock block)
        {
            graphics.DrawPath(block.FBlockPen, block.F.ToRoundedRect(FBlockRadius));
            Point center = new Point(block.F.X + block.F.Width / 2, block.F.Y + block.F.Height / 2);
            graphics.DrawString("f" + block.KeyName, Font, BlockBrush, center.X - ((int)((block.FSMInfo.KeyName.Length + 1) * 0.8 * Font.Size)) / 2, center.Y - Font.Size);
        }

        private void DrawKsiBlock(Graphics graphics, Point point, SubMachineBlock block)
        {
            graphics.DrawPath(block.KsiBlockPen, block.Ksi.ToRoundedRect(KsiBlockRadius));
            Point center = new Point(block.Ksi.X + block.Ksi.Width / 2, block.Ksi.Y + block.Ksi.Height / 2);
            graphics.DrawString("ѱ" + block.KeyName, Font, BlockBrush, center.X - ((int)((block.FSMInfo.KeyName.Length + 1) * 0.8 * Font.Size)) / 2, center.Y - Font.Size);
        }

        private void DrawArrows(Graphics graphics, Point point, SubMachineBlock block)
        {
            graphics.DrawArrow(block.ArrowPen,
                block.F.X + block.F.Width,
                block.F.Y + block.F.Height / 2,
                block.FSMBlock.X,
                block.FSMBlock.Y + block.FSMBlock.Height / 2,
                ArrowheadLength,
                ArrowheadAngle);

            graphics.DrawArrow(block.ArrowPen,
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

        public Size GetSize()
        {
            if (SubMachineBlocks.Count > 0)
            {
                return new Size(
                    Math.Abs(
                        GBlock.X + 2*SubFSMBlockSpace) -
                        Math.Min(0, Math.Min(SubMachineBlocks.First().Value.LeftConnector.X - SubFSMBlockSpace, InputPoint.X) - SubFSMBlockSpace),
                    Math.Abs(
                        (GBlock.Y + GBlock.Height) -
                        (InputPoint.Y - SubFSMBlockSpace))
                    );

            }
            return Size.Empty;
        }
    }
}
