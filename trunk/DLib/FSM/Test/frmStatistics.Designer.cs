namespace Test
{
    partial class frmStatistics
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatistics));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grcStatParams = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNetTimeValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNetRejectionCountValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFSMTimeValue = new System.Windows.Forms.Label();
            this.lblFSMRejectionCountValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCountOfRepeatsValue = new System.Windows.Forms.Label();
            this.gcSettings = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbxInitialState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbxInputSequence = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.seRepeatsNumber = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.chbxSyncronize = new DevExpress.XtraEditors.CheckEdit();
            this.tcCharts = new DevExpress.XtraTab.XtraTabControl();
            this.cmsCharts1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSaveToFile1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCharts2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSaveToFile2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcStatParams)).BeginInit();
            this.grcStatParams.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).BeginInit();
            this.gcSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxInitialState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxInputSequence.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRepeatsNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbxSyncronize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcCharts)).BeginInit();
            this.cmsCharts1.SuspendLayout();
            this.cmsCharts2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grcStatParams);
            this.splitContainerControl1.Panel1.Controls.Add(this.gcSettings);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tcCharts);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(815, 568);
            this.splitContainerControl1.SplitterPosition = 267;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grcStatParams
            // 
            this.grcStatParams.Controls.Add(this.tableLayoutPanel1);
            this.grcStatParams.Dock = System.Windows.Forms.DockStyle.Top;
            this.grcStatParams.Location = new System.Drawing.Point(0, 177);
            this.grcStatParams.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.grcStatParams.Name = "grcStatParams";
            this.grcStatParams.Size = new System.Drawing.Size(263, 180);
            this.grcStatParams.TabIndex = 5;
            this.grcStatParams.Text = "Статистика";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.31687F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.68313F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNetTimeValue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNetRejectionCountValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFSMTimeValue, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFSMRejectionCountValue, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCountOfRepeatsValue, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 158);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Время работы сети : ";
            // 
            // lblNetTimeValue
            // 
            this.lblNetTimeValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNetTimeValue.AutoSize = true;
            this.lblNetTimeValue.Location = new System.Drawing.Point(161, 6);
            this.lblNetTimeValue.Name = "lblNetTimeValue";
            this.lblNetTimeValue.Size = new System.Drawing.Size(13, 13);
            this.lblNetTimeValue.TabIndex = 1;
            this.lblNetTimeValue.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Число отказов сети : ";
            // 
            // lblNetRejectionCountValue
            // 
            this.lblNetRejectionCountValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNetRejectionCountValue.AutoSize = true;
            this.lblNetRejectionCountValue.Location = new System.Drawing.Point(161, 32);
            this.lblNetRejectionCountValue.Name = "lblNetRejectionCountValue";
            this.lblNetRejectionCountValue.Size = new System.Drawing.Size(13, 13);
            this.lblNetRejectionCountValue.TabIndex = 3;
            this.lblNetRejectionCountValue.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Время работы автомата : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Число отказов автомата : ";
            // 
            // lblFSMTimeValue
            // 
            this.lblFSMTimeValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFSMTimeValue.AutoSize = true;
            this.lblFSMTimeValue.Location = new System.Drawing.Point(161, 58);
            this.lblFSMTimeValue.Name = "lblFSMTimeValue";
            this.lblFSMTimeValue.Size = new System.Drawing.Size(13, 13);
            this.lblFSMTimeValue.TabIndex = 1;
            this.lblFSMTimeValue.Text = "0";
            // 
            // lblFSMRejectionCountValue
            // 
            this.lblFSMRejectionCountValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFSMRejectionCountValue.AutoSize = true;
            this.lblFSMRejectionCountValue.Location = new System.Drawing.Point(161, 84);
            this.lblFSMRejectionCountValue.Name = "lblFSMRejectionCountValue";
            this.lblFSMRejectionCountValue.Size = new System.Drawing.Size(13, 13);
            this.lblFSMRejectionCountValue.TabIndex = 1;
            this.lblFSMRejectionCountValue.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Число повторений : ";
            // 
            // lblCountOfRepeatsValue
            // 
            this.lblCountOfRepeatsValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCountOfRepeatsValue.AutoSize = true;
            this.lblCountOfRepeatsValue.Location = new System.Drawing.Point(161, 124);
            this.lblCountOfRepeatsValue.Name = "lblCountOfRepeatsValue";
            this.lblCountOfRepeatsValue.Size = new System.Drawing.Size(13, 13);
            this.lblCountOfRepeatsValue.TabIndex = 1;
            this.lblCountOfRepeatsValue.Text = "0";
            // 
            // gcSettings
            // 
            this.gcSettings.Controls.Add(this.tableLayoutPanel2);
            this.gcSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcSettings.Location = new System.Drawing.Point(0, 0);
            this.gcSettings.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.gcSettings.Name = "gcSettings";
            this.gcSettings.Size = new System.Drawing.Size(263, 177);
            this.gcSettings.TabIndex = 13;
            this.gcSettings.Text = "Параметры";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelControl3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbxInitialState, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbxInputSequence, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelControl1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.seRepeatsNumber, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnRefresh, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.chbxSyncronize, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(259, 155);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl3.Location = new System.Drawing.Point(9, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(117, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Начальное состояние :";
            // 
            // cbxInitialState
            // 
            this.cbxInitialState.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxInitialState.Location = new System.Drawing.Point(132, 3);
            this.cbxInitialState.Name = "cbxInitialState";
            this.cbxInitialState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxInitialState.Size = new System.Drawing.Size(124, 20);
            this.cbxInitialState.TabIndex = 12;
            // 
            // cbxInputSequence
            // 
            this.cbxInputSequence.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxInputSequence.Location = new System.Drawing.Point(132, 55);
            this.cbxInputSequence.Name = "cbxInputSequence";
            this.cbxInputSequence.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxInputSequence.Size = new System.Drawing.Size(124, 20);
            this.cbxInputSequence.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl1.Location = new System.Drawing.Point(26, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Число повторений :";
            // 
            // seRepeatsNumber
            // 
            this.seRepeatsNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.seRepeatsNumber.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seRepeatsNumber.Location = new System.Drawing.Point(132, 29);
            this.seRepeatsNumber.Name = "seRepeatsNumber";
            this.seRepeatsNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seRepeatsNumber.Size = new System.Drawing.Size(124, 20);
            this.seRepeatsNumber.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl2.Location = new System.Drawing.Point(28, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(98, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Входные символы :";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRefresh.Location = new System.Drawing.Point(132, 106);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(124, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Смоделировать";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chbxSyncronize
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.chbxSyncronize, 2);
            this.chbxSyncronize.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbxSyncronize.Location = new System.Drawing.Point(20, 81);
            this.chbxSyncronize.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.chbxSyncronize.Name = "chbxSyncronize";
            this.chbxSyncronize.Properties.Caption = "Синхронизировать сеть и автомат";
            this.chbxSyncronize.Size = new System.Drawing.Size(236, 19);
            this.chbxSyncronize.TabIndex = 13;
            // 
            // tcCharts
            // 
            this.tcCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCharts.Location = new System.Drawing.Point(0, 0);
            this.tcCharts.Name = "tcCharts";
            this.tcCharts.Size = new System.Drawing.Size(538, 564);
            this.tcCharts.TabIndex = 1;
            this.tcCharts.Text = "tcCharts";
            // 
            // cmsCharts1
            // 
            this.cmsCharts1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveToFile1});
            this.cmsCharts1.Name = "cmsCharts";
            this.cmsCharts1.Size = new System.Drawing.Size(183, 26);
            // 
            // tsmiSaveToFile1
            // 
            this.tsmiSaveToFile1.Name = "tsmiSaveToFile1";
            this.tsmiSaveToFile1.Size = new System.Drawing.Size(182, 22);
            this.tsmiSaveToFile1.Text = "Сохранить в файл...";
            this.tsmiSaveToFile1.Click += new System.EventHandler(this.tsmiSaveToFile1_Click);
            // 
            // cmsCharts2
            // 
            this.cmsCharts2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveToFile2});
            this.cmsCharts2.Name = "cmsCharts";
            this.cmsCharts2.Size = new System.Drawing.Size(183, 26);
            // 
            // tsmiSaveToFile2
            // 
            this.tsmiSaveToFile2.Name = "tsmiSaveToFile2";
            this.tsmiSaveToFile2.Size = new System.Drawing.Size(182, 22);
            this.tsmiSaveToFile2.Text = "Сохранить в файл...";
            this.tsmiSaveToFile2.Click += new System.EventHandler(this.tsmiSaveToFile2_Click);
            // 
            // frmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 568);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStatistics";
            this.Text = "Статистика";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcStatParams)).EndInit();
            this.grcStatParams.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).EndInit();
            this.gcSettings.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxInitialState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxInputSequence.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRepeatsNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbxSyncronize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcCharts)).EndInit();
            this.cmsCharts1.ResumeLayout(false);
            this.cmsCharts2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SpinEdit seRepeatsNumber;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl grcStatParams;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.ComboBoxEdit cbxInputSequence;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cbxInitialState;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl gcSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNetTimeValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNetRejectionCountValue;
        private DevExpress.XtraTab.XtraTabControl tcCharts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFSMTimeValue;
        private System.Windows.Forms.Label lblFSMRejectionCountValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCountOfRepeatsValue;
        private System.Windows.Forms.ContextMenuStrip cmsCharts1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveToFile1;
        private System.Windows.Forms.ContextMenuStrip cmsCharts2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveToFile2;
        private DevExpress.XtraEditors.CheckEdit chbxSyncronize;
    }
}