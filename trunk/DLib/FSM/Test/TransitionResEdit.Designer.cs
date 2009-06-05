namespace Test
{
    partial class TransitionResEdit
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
            this.gc = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.seProbability = new DevExpress.XtraEditors.SpinEdit();
            this.lblProbability = new DevExpress.XtraEditors.LabelControl();
            this.cbxOutput = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblOutput = new DevExpress.XtraEditors.LabelControl();
            this.cbxDestState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDestState = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            this.gc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seProbability.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxOutput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDestState.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gc
            // 
            this.gc.Controls.Add(this.btnCancel);
            this.gc.Controls.Add(this.btnOK);
            this.gc.Controls.Add(this.seProbability);
            this.gc.Controls.Add(this.lblProbability);
            this.gc.Controls.Add(this.cbxOutput);
            this.gc.Controls.Add(this.lblOutput);
            this.gc.Controls.Add(this.cbxDestState);
            this.gc.Controls.Add(this.lblDestState);
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 0);
            this.gc.Name = "gc";
            this.gc.ShowCaption = false;
            this.gc.Size = new System.Drawing.Size(284, 264);
            this.gc.TabIndex = 0;
            this.gc.Text = "Укажите параметры";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(197, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(116, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Сохранить";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // seProbability
            // 
            this.seProbability.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seProbability.Location = new System.Drawing.Point(172, 95);
            this.seProbability.Name = "seProbability";
            this.seProbability.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.seProbability.Size = new System.Drawing.Size(100, 20);
            this.seProbability.TabIndex = 5;
            this.seProbability.Validating += new System.ComponentModel.CancelEventHandler(this.seProbability_Validating);
            // 
            // lblProbability
            // 
            this.lblProbability.Location = new System.Drawing.Point(91, 98);
            this.lblProbability.Name = "lblProbability";
            this.lblProbability.Size = new System.Drawing.Size(72, 13);
            this.lblProbability.TabIndex = 4;
            this.lblProbability.Text = "Вероянтость :";
            // 
            // cbxOutput
            // 
            this.cbxOutput.Location = new System.Drawing.Point(172, 64);
            this.cbxOutput.Name = "cbxOutput";
            this.cbxOutput.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxOutput.Size = new System.Drawing.Size(100, 20);
            this.cbxOutput.TabIndex = 3;
            // 
            // lblOutput
            // 
            this.lblOutput.Location = new System.Drawing.Point(67, 67);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(96, 13);
            this.lblOutput.TabIndex = 2;
            this.lblOutput.Text = "Выходной символ :";
            // 
            // cbxDestState
            // 
            this.cbxDestState.Location = new System.Drawing.Point(172, 31);
            this.cbxDestState.Name = "cbxDestState";
            this.cbxDestState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxDestState.Size = new System.Drawing.Size(100, 20);
            this.cbxDestState.TabIndex = 1;
            // 
            // lblDestState
            // 
            this.lblDestState.Location = new System.Drawing.Point(12, 34);
            this.lblDestState.Name = "lblDestState";
            this.lblDestState.Size = new System.Drawing.Size(151, 13);
            this.lblDestState.TabIndex = 0;
            this.lblDestState.Text = "Результирующее состояние :";
            // 
            // TransitionResEdit
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.gc);
            this.Name = "TransitionResEdit";
            this.Text = "Добавление перехода";
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            this.gc.ResumeLayout(false);
            this.gc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seProbability.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxOutput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDestState.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gc;
        private DevExpress.XtraEditors.LabelControl lblDestState;
        private DevExpress.XtraEditors.ComboBoxEdit cbxDestState;
        private DevExpress.XtraEditors.LabelControl lblOutput;
        private DevExpress.XtraEditors.ComboBoxEdit cbxOutput;
        private DevExpress.XtraEditors.LabelControl lblProbability;
        private DevExpress.XtraEditors.SpinEdit seProbability;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}