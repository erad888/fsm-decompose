namespace Test
{
    partial class frmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gcFSMEdit = new DevExpress.XtraEditors.GroupControl();
            this.tbxFSMName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnDecompose = new DevExpress.XtraEditors.SimpleButton();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbtnSaveFSM = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLoadFSM = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnDecompose = new System.Windows.Forms.ToolStripButton();
            this.tsbtnToExcel = new System.Windows.Forms.ToolStripButton();
            this.fsmEditControl = new Test.FSMEditControl();
            this.leFSMs = new Test.ListEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFSMEdit)).BeginInit();
            this.gcFSMEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 25);
            this.splitContainerControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1051, 597);
            this.splitContainerControl1.SplitterPosition = 223;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gcFSMEdit, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbxFSMName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(816, 587);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // gcFSMEdit
            // 
            this.gcFSMEdit.Controls.Add(this.fsmEditControl);
            this.gcFSMEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcFSMEdit.Location = new System.Drawing.Point(3, 57);
            this.gcFSMEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcFSMEdit.LookAndFeel.UseWindowsXPTheme = true;
            this.gcFSMEdit.Name = "gcFSMEdit";
            this.gcFSMEdit.ShowCaption = false;
            this.gcFSMEdit.Size = new System.Drawing.Size(810, 527);
            this.gcFSMEdit.TabIndex = 1;
            // 
            // tbxFSMName
            // 
            this.tbxFSMName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxFSMName.Location = new System.Drawing.Point(3, 31);
            this.tbxFSMName.Name = "tbxFSMName";
            this.tbxFSMName.Size = new System.Drawing.Size(810, 20);
            this.tbxFSMName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(30, 10, 3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Создайте или загрузите автомат.";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl2.LookAndFeel.UseWindowsXPTheme = true;
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl2.Panel1.Controls.Add(this.leFSMs);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl2.Panel2.Controls.Add(this.btnDecompose);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(219, 587);
            this.splitContainerControl2.SplitterPosition = 243;
            this.splitContainerControl2.TabIndex = 2;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // btnDecompose
            // 
            this.btnDecompose.Location = new System.Drawing.Point(82, 13);
            this.btnDecompose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDecompose.LookAndFeel.UseWindowsXPTheme = true;
            this.btnDecompose.Name = "btnDecompose";
            this.btnDecompose.Size = new System.Drawing.Size(134, 27);
            this.btnDecompose.TabIndex = 0;
            this.btnDecompose.Text = "Декомпозировать";
            this.btnDecompose.Click += new System.EventHandler(this.btnDecompose_Click);
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSaveFSM,
            this.tsbtnLoadFSM,
            this.toolStripSeparator1,
            this.tsbtnDecompose,
            this.tsbtnToExcel});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1051, 25);
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbtnSaveFSM
            // 
            this.tsbtnSaveFSM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSaveFSM.Image = global::Test.Properties.Resources.save;
            this.tsbtnSaveFSM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveFSM.Name = "tsbtnSaveFSM";
            this.tsbtnSaveFSM.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSaveFSM.Text = "Сохранить автомат";
            this.tsbtnSaveFSM.Click += new System.EventHandler(this.tsbtnSaveFSM_Click);
            // 
            // tsbtnLoadFSM
            // 
            this.tsbtnLoadFSM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLoadFSM.Image = global::Test.Properties.Resources.load;
            this.tsbtnLoadFSM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLoadFSM.Name = "tsbtnLoadFSM";
            this.tsbtnLoadFSM.Size = new System.Drawing.Size(23, 22);
            this.tsbtnLoadFSM.Text = "Загрузить автомат";
            this.tsbtnLoadFSM.Click += new System.EventHandler(this.tsbtnLoadFSM_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnDecompose
            // 
            this.tsbtnDecompose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDecompose.Image = global::Test.Properties.Resources.decompose;
            this.tsbtnDecompose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDecompose.Name = "tsbtnDecompose";
            this.tsbtnDecompose.Size = new System.Drawing.Size(23, 22);
            this.tsbtnDecompose.Text = "Декомпозиция";
            this.tsbtnDecompose.Click += new System.EventHandler(this.tsbtnDecompose_Click);
            // 
            // tsbtnToExcel
            // 
            this.tsbtnToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnToExcel.Image = global::Test.Properties.Resources.excel;
            this.tsbtnToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnToExcel.Name = "tsbtnToExcel";
            this.tsbtnToExcel.Size = new System.Drawing.Size(23, 22);
            this.tsbtnToExcel.Text = "Экспорт в Excel";
            this.tsbtnToExcel.Click += new System.EventHandler(this.tsbtnToExcel_Click);
            // 
            // fsmEditControl
            // 
            this.fsmEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsmEditControl.fsm = null;
            this.fsmEditControl.Location = new System.Drawing.Point(2, 2);
            this.fsmEditControl.Name = "fsmEditControl";
            this.fsmEditControl.Size = new System.Drawing.Size(806, 522);
            this.fsmEditControl.TabIndex = 0;
            // 
            // leFSMs
            // 
            this.leFSMs.AllowRename = false;
            this.leFSMs.Caption = "";
            this.leFSMs.CreationRule = null;
            this.leFSMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leFSMs.Location = new System.Drawing.Point(0, 0);
            this.leFSMs.Name = "leFSMs";
            this.leFSMs.Size = new System.Drawing.Size(219, 243);
            this.leFSMs.TabIndex = 1;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 622);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.tsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTest";
            this.Text = "Декомпозиция вероятностного автомата";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFSMEdit)).EndInit();
            this.gcFSMEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FSMEditControl fsmEditControl;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private ListEdit leFSMs;
        private DevExpress.XtraEditors.GroupControl gcFSMEdit;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SimpleButton btnDecompose;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbtnSaveFSM;
        private System.Windows.Forms.ToolStripButton tsbtnLoadFSM;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnDecompose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbxFSMName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbtnToExcel;
    }
}

