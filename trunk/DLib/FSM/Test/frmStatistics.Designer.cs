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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cbxInitialState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbxInputSequence = new DevExpress.XtraEditors.ComboBoxEdit();
            this.seRepeatsNumber = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grcStatParams = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chc = new DevExpress.XtraCharts.ChartControl();
            this.gcSettings = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTimeValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRejectionCountValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxInitialState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxInputSequence.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRepeatsNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcStatParams)).BeginInit();
            this.grcStatParams.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).BeginInit();
            this.gcSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcSettings);
            this.splitContainerControl1.Panel1.Controls.Add(this.grcStatParams);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.chc);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(815, 413);
            this.splitContainerControl1.SplitterPosition = 267;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // cbxInitialState
            // 
            this.cbxInitialState.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxInitialState.Location = new System.Drawing.Point(128, 3);
            this.cbxInitialState.Name = "cbxInitialState";
            this.cbxInitialState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxInitialState.Size = new System.Drawing.Size(119, 20);
            this.cbxInitialState.TabIndex = 12;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl3.Location = new System.Drawing.Point(5, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(117, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Начальное состояние :";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(172, 81);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl2.Location = new System.Drawing.Point(24, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(98, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Входные символы :";
            // 
            // cbxInputSequence
            // 
            this.cbxInputSequence.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxInputSequence.Location = new System.Drawing.Point(128, 55);
            this.cbxInputSequence.Name = "cbxInputSequence";
            this.cbxInputSequence.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxInputSequence.Size = new System.Drawing.Size(119, 20);
            this.cbxInputSequence.TabIndex = 8;
            // 
            // seRepeatsNumber
            // 
            this.seRepeatsNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.seRepeatsNumber.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seRepeatsNumber.Location = new System.Drawing.Point(128, 29);
            this.seRepeatsNumber.Name = "seRepeatsNumber";
            this.seRepeatsNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seRepeatsNumber.Size = new System.Drawing.Size(119, 20);
            this.seRepeatsNumber.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelControl1.Location = new System.Drawing.Point(22, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Число повторений :";
            // 
            // grcStatParams
            // 
            this.grcStatParams.Controls.Add(this.tableLayoutPanel1);
            this.grcStatParams.Location = new System.Drawing.Point(10, 10);
            this.grcStatParams.Name = "grcStatParams";
            this.grcStatParams.Size = new System.Drawing.Size(238, 92);
            this.grcStatParams.TabIndex = 5;
            this.grcStatParams.Text = "Статистика";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.2906F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.7094F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeValue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblRejectionCountValue, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(234, 70);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chc
            // 
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            this.chc.Diagram = xyDiagram1;
            this.chc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chc.Legend.Visible = false;
            this.chc.Location = new System.Drawing.Point(0, 0);
            this.chc.Name = "chc";
            series1.Name = "serTargetEntity";
            series1.PointOptionsTypeName = "PointOptions";
            this.chc.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chc.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            this.chc.Size = new System.Drawing.Size(538, 409);
            this.chc.TabIndex = 0;
            // 
            // gcSettings
            // 
            this.gcSettings.Controls.Add(this.tableLayoutPanel2);
            this.gcSettings.Location = new System.Drawing.Point(1, 257);
            this.gcSettings.Name = "gcSettings";
            this.gcSettings.Size = new System.Drawing.Size(254, 142);
            this.gcSettings.TabIndex = 13;
            this.gcSettings.Text = "Параметры";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelControl3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRefresh, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.cbxInitialState, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbxInputSequence, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelControl1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.seRepeatsNumber, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl2, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(250, 120);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Время работы : ";
            // 
            // lblTimeValue
            // 
            this.lblTimeValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimeValue.AutoSize = true;
            this.lblTimeValue.Location = new System.Drawing.Point(116, 11);
            this.lblTimeValue.Name = "lblTimeValue";
            this.lblTimeValue.Size = new System.Drawing.Size(13, 13);
            this.lblTimeValue.TabIndex = 1;
            this.lblTimeValue.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Число отказов : ";
            // 
            // lblRejectionCountValue
            // 
            this.lblRejectionCountValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRejectionCountValue.AutoSize = true;
            this.lblRejectionCountValue.Location = new System.Drawing.Point(116, 46);
            this.lblRejectionCountValue.Name = "lblRejectionCountValue";
            this.lblRejectionCountValue.Size = new System.Drawing.Size(13, 13);
            this.lblRejectionCountValue.TabIndex = 3;
            this.lblRejectionCountValue.Text = "0";
            // 
            // frmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 413);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmStatistics";
            this.Text = "frmStatistics";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbxInitialState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxInputSequence.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRepeatsNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcStatParams)).EndInit();
            this.grcStatParams.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).EndInit();
            this.gcSettings.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private DevExpress.XtraCharts.ChartControl chc;
        private DevExpress.XtraEditors.ComboBoxEdit cbxInitialState;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl gcSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTimeValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRejectionCountValue;
    }
}