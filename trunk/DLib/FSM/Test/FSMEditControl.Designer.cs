namespace Test
{
    partial class FSMEditControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gvEdit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.leStates = new Test.ListEdit();
            this.leInput = new Test.ListEdit();
            this.leOutput = new Test.ListEdit();
            this.listEdit1 = new Test.ListEdit();
            this.listEdit2 = new Test.ListEdit();
            this.listEdit3 = new Test.ListEdit();
            this.listEdit4 = new Test.ListEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEdit)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl2.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(897, 612);
            this.splitContainerControl2.SplitterPosition = 342;
            this.splitContainerControl2.TabIndex = 1;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gvEdit;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(897, 342);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEdit});
            // 
            // gvEdit
            // 
            this.gvEdit.GridControl = this.gridControl1;
            this.gvEdit.Name = "gvEdit";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.leStates, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.leInput, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.leOutput, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(897, 264);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // leStates
            // 
            this.leStates.CreationRule = null;
            this.leStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leStates.Location = new System.Drawing.Point(3, 3);
            this.leStates.Name = "leStates";
            this.leStates.Size = new System.Drawing.Size(293, 258);
            this.leStates.TabIndex = 0;
            // 
            // leInput
            // 
            this.leInput.CreationRule = null;
            this.leInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leInput.Location = new System.Drawing.Point(302, 3);
            this.leInput.Name = "leInput";
            this.leInput.Size = new System.Drawing.Size(293, 258);
            this.leInput.TabIndex = 1;
            // 
            // leOutput
            // 
            this.leOutput.CreationRule = null;
            this.leOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leOutput.Location = new System.Drawing.Point(601, 3);
            this.leOutput.Name = "leOutput";
            this.leOutput.Size = new System.Drawing.Size(293, 258);
            this.leOutput.TabIndex = 2;
            // 
            // listEdit1
            // 
            this.listEdit1.CreationRule = null;
            this.listEdit1.Location = new System.Drawing.Point(0, 0);
            this.listEdit1.Name = "listEdit1";
            this.listEdit1.Size = new System.Drawing.Size(324, 198);
            this.listEdit1.TabIndex = 0;
            // 
            // listEdit2
            // 
            this.listEdit2.CreationRule = null;
            this.listEdit2.Location = new System.Drawing.Point(0, 0);
            this.listEdit2.Name = "listEdit2";
            this.listEdit2.Size = new System.Drawing.Size(324, 198);
            this.listEdit2.TabIndex = 0;
            // 
            // listEdit3
            // 
            this.listEdit3.CreationRule = null;
            this.listEdit3.Location = new System.Drawing.Point(0, 0);
            this.listEdit3.Name = "listEdit3";
            this.listEdit3.Size = new System.Drawing.Size(324, 198);
            this.listEdit3.TabIndex = 0;
            // 
            // listEdit4
            // 
            this.listEdit4.CreationRule = null;
            this.listEdit4.Location = new System.Drawing.Point(0, 0);
            this.listEdit4.Name = "listEdit4";
            this.listEdit4.Size = new System.Drawing.Size(324, 198);
            this.listEdit4.TabIndex = 0;
            // 
            // FSMEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl2);
            this.Name = "FSMEditControl";
            this.Size = new System.Drawing.Size(897, 612);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEdit)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEdit;
        private ListEdit listEdit1;
        private ListEdit listEdit2;
        private ListEdit listEdit3;
        private ListEdit listEdit4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ListEdit leStates;
        private ListEdit leInput;
        private ListEdit leOutput;
        public DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
    }
}