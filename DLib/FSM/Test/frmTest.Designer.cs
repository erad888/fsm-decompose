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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFSMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFSMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FSMNetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.DecomposeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFSMEdit)).BeginInit();
            this.gcFSMEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 49);
            this.splitContainerControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1051, 573);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(816, 563);
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
            this.gcFSMEdit.Size = new System.Drawing.Size(810, 503);
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
            this.splitContainerControl2.Size = new System.Drawing.Size(219, 563);
            this.splitContainerControl2.SplitterPosition = 243;
            this.splitContainerControl2.TabIndex = 2;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // btnDecompose
            // 
            this.btnDecompose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDecompose.Location = new System.Drawing.Point(48, 2);
            this.btnDecompose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDecompose.LookAndFeel.UseWindowsXPTheme = true;
            this.btnDecompose.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
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
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1051, 25);
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbtnSaveFSM
            // 
            this.tsbtnSaveFSM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSaveFSM.Image = global::MainWinContainer.Properties.Resources.save;
            this.tsbtnSaveFSM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaveFSM.Name = "tsbtnSaveFSM";
            this.tsbtnSaveFSM.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSaveFSM.Text = "Сохранить автомат";
            this.tsbtnSaveFSM.Click += new System.EventHandler(this.tsbtnSaveFSM_Click);
            // 
            // tsbtnLoadFSM
            // 
            this.tsbtnLoadFSM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLoadFSM.Image = global::MainWinContainer.Properties.Resources.load;
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
            this.tsbtnDecompose.Image = global::MainWinContainer.Properties.Resources.decompose;
            this.tsbtnDecompose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDecompose.Name = "tsbtnDecompose";
            this.tsbtnDecompose.Size = new System.Drawing.Size(23, 22);
            this.tsbtnDecompose.Text = "Сеть";
            this.tsbtnDecompose.Click += new System.EventHandler(this.tsbtnDecompose_Click);
            // 
            // tsbtnToExcel
            // 
            this.tsbtnToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnToExcel.Image = global::MainWinContainer.Properties.Resources.excel;
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
            this.fsmEditControl.Size = new System.Drawing.Size(806, 498);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ToolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1051, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFSMToolStripMenuItem,
            this.SaveFSMToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "&Файл";
            // 
            // OpenFSMToolStripMenuItem
            // 
            this.OpenFSMToolStripMenuItem.Name = "OpenFSMToolStripMenuItem";
            this.OpenFSMToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.OpenFSMToolStripMenuItem.Text = "Открыть автомат...";
            this.OpenFSMToolStripMenuItem.Click += new System.EventHandler(this.tsbtnLoadFSM_Click);
            // 
            // SaveFSMToolStripMenuItem
            // 
            this.SaveFSMToolStripMenuItem.Name = "SaveFSMToolStripMenuItem";
            this.SaveFSMToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.SaveFSMToolStripMenuItem.Text = "Сохранить автомат...";
            this.SaveFSMToolStripMenuItem.Click += new System.EventHandler(this.tsbtnSaveFSM_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportToExcelToolStripMenuItem,
            this.toolStripMenuItem2,
            this.FSMNetToolStripMenuItem,
            this.DecomposeToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.ToolsToolStripMenuItem.Text = "&Инструменты";
            // 
            // ExportToExcelToolStripMenuItem
            // 
            this.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem";
            this.ExportToExcelToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ExportToExcelToolStripMenuItem.Text = "Экспорт в &Excel...";
            this.ExportToExcelToolStripMenuItem.Click += new System.EventHandler(this.tsbtnToExcel_Click);
            // 
            // FSMNetToolStripMenuItem
            // 
            this.FSMNetToolStripMenuItem.Name = "FSMNetToolStripMenuItem";
            this.FSMNetToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.FSMNetToolStripMenuItem.Text = "Сеть автоматов...";
            this.FSMNetToolStripMenuItem.Click += new System.EventHandler(this.tsbtnDecompose_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(179, 6);
            // 
            // DecomposeToolStripMenuItem
            // 
            this.DecomposeToolStripMenuItem.Name = "DecomposeToolStripMenuItem";
            this.DecomposeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.DecomposeToolStripMenuItem.Text = "Декомпозировать...";
            this.DecomposeToolStripMenuItem.Click += new System.EventHandler(this.btnDecompose_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 622);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFSMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFSMToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem FSMNetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DecomposeToolStripMenuItem;
    }
}

