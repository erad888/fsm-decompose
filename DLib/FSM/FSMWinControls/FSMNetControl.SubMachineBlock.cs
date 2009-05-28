using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using DLib.WinForms.Drawing;

namespace FSM.FSMWinControls
{
	public partial class FSMNetControl
	{
        /// <summary>
        /// Описывает блок сети автоматов
        /// </summary>
        private class SubMachineBlock:IStringKeyable
        {
            #region static
            static ColorCarouselPicker ColorPicker = new ColorCarouselPicker(new[] { Color.Blue, Color.Red, Color.DarkGreen, Color.DeepPink, Color.DarkMagenta });
            #endregion

            public SubMachineBlock(int No, FSMNetControl control, Point basePoint, FSMInfo fsmInfo)
            {
                if (control == null) throw new ArgumentNullException("control");

                this.No = No;
                this.control = control;
                this.BasePoint = basePoint;
                this.FSMInfo = fsmInfo;

                this.KeyName = fsmInfo.KeyName;

                SolveCoords();
                SetColors();
            }

            public void SetPenWidth(int width)
            {
                if (width >= 0)
                {
                    FSMBlockPen.Width = width;
                    FBlockPen.Width = width;
                    KsiBlockPen.Width = width;
                    ArrowPen.Width = width;
                }
            }

            public void SolveCoords(Point BasePoint)
            {
                this.BasePoint = BasePoint;
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

            private void SetColors()
            {
                if (!ColorsInitialized)
                {
                    Color color = ColorPicker.Value;

                    if (FSMBlockPen == null)
                        FSMBlockPen = new Pen(color);
                    else
                        FSMBlockPen.Color = color;

                    if (KsiBlockPen == null)
                        KsiBlockPen = new Pen(color);
                    else
                        FSMBlockPen.Color = color;

                    if (FBlockPen == null)
                        FBlockPen = new Pen(color);
                    else
                        FSMBlockPen.Color = color;

                    if (ArrowPen == null)
                        ArrowPen = new Pen(color);
                    else
                        FSMBlockPen.Color = color;

                    ColorsInitialized = true;
                }
            }

            private bool ColorsInitialized = false;
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

            public Pen FSMBlockPen { get; set; }
            public Pen FBlockPen { get; set; }
            public Pen KsiBlockPen { get; set; }
            public Pen ArrowPen { get; set; }

            public int No { get; set; }
            public Rectangle FSMBlock { get; set; }
            public Rectangle F { get; set; }
            public Rectangle Ksi { get; set; }

            public Rectangle BoundRect
            {
                get
                {
                    var result = new Rectangle();
                    result.X = Math.Min(Ksi.X, F.X);
                    result.Y = Math.Min(Ksi.Y, F.Y);
                    result.Width = Math.Max(Ksi.X + Ksi.Width, FSMBlock.X + FSMBlock.Width) - result.X;
                    result.Height = Math.Max(F.Y + F.Height, FSMBlock.Y + FSMBlock.Height) - result.Y;

                    return result;
                }
            }

            public bool Exists { get; set; }

            #region IStringKeyable Members

            public string KeyName { get; set; }

            #endregion
        }
	}
}
