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
            this.seRepeatsNumber = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grcStatParams = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxInputSequence = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.chc = new DevExpress.XtraCharts.ChartControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbxInitialState = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seRepeatsNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcStatParams)).BeginInit();
            this.grcStatParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxInputSequence.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxInitialState.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.cbxInitialState);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.cbxInputSequence);
            this.splitContainerControl1.Panel1.Controls.Add(this.seRepeatsNumber);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.grcStatParams);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.chc);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(815, 413);
            this.splitContainerControl1.SplitterPosition = 267;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // seRepeatsNumber
            // 
            this.seRepeatsNumber.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seRepeatsNumber.Location = new System.Drawing.Point(134, 314);
            this.seRepeatsNumber.Name = "seRepeatsNumber";
            this.seRepeatsNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seRepeatsNumber.Size = new System.Drawing.Size(100, 20);
            this.seRepeatsNumber.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 317);
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
            this.grcStatParams.Size = new System.Drawing.Size(238, 209);
            this.grcStatParams.TabIndex = 5;
            this.grcStatParams.Text = "Статистика";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(234, 187);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbxInputSequence
            // 
            this.cbxInputSequence.Location = new System.Drawing.Point(134, 340);
            this.cbxInputSequence.Name = "cbxInputSequence";
            this.cbxInputSequence.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxInputSequence.Size = new System.Drawing.Size(100, 20);
            this.cbxInputSequence.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 343);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(98, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Входные символы :";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(159, 376);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 291);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(117, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Начальное состояние :";
            // 
            // cbxInitialState
            // 
            this.cbxInitialState.Location = new System.Drawing.Point(134, 288);
            this.cbxInitialState.Name = "cbxInitialState";
            this.cbxInitialState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxInitialState.Size = new System.Drawing.Size(100, 20);
            this.cbxInitialState.TabIndex = 12;
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
            ((System.ComponentModel.ISupportInitialize)(this.seRepeatsNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcStatParams)).EndInit();
            this.grcStatParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbxInputSequence.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxInitialState.Properties)).EndInit();
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
    }
}