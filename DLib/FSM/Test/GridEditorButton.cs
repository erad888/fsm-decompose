using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;

namespace Test
{
    public partial class GridEditorButton : EditorButton
    {
        public GridEditorButton()
        {
            InitializeComponent();
        }
        public GridEditorButton(ButtonPredefines kind):this()
        {
            Kind = kind;
        }

        public void SetCell(int RowHandle, GridColumn Column)
        {
            this.RowHandle = RowHandle;
            this.Column = Column;
        }

        public int RowHandle { get; private set; }
        public GridColumn Column { get; private set; } 
    }
}
