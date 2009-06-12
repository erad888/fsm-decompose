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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcFSMEdit = new DevExpress.XtraEditors.GroupControl();
            this.fsmEditControl = new Test.FSMEditControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.leFSMs = new Test.ListEdit();
            this.btnDecompose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFSMEdit)).BeginInit();
            this.gcFSMEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcFSMEdit);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1051, 622);
            this.splitContainerControl1.SplitterPosition = 283;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcFSMEdit
            // 
            this.gcFSMEdit.Controls.Add(this.fsmEditControl);
            this.gcFSMEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcFSMEdit.Location = new System.Drawing.Point(0, 0);
            this.gcFSMEdit.Name = "gcFSMEdit";
            this.gcFSMEdit.Size = new System.Drawing.Size(754, 614);
            this.gcFSMEdit.TabIndex = 1;
            // 
            // fsmEditControl
            // 
            this.fsmEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsmEditControl.fsm = null;
            this.fsmEditControl.Location = new System.Drawing.Point(2, 20);
            this.fsmEditControl.Name = "fsmEditControl";
            this.fsmEditControl.Size = new System.Drawing.Size(750, 592);
            this.fsmEditControl.TabIndex = 0;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl2.Panel1.Controls.Add(this.leFSMs);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitContainerControl2.Panel2.Controls.Add(this.btnDecompose);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(279, 614);
            this.splitContainerControl2.SplitterPosition = 190;
            this.splitContainerControl2.TabIndex = 2;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // leFSMs
            // 
            this.leFSMs.Caption = "";
            this.leFSMs.CreationRule = null;
            this.leFSMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leFSMs.Location = new System.Drawing.Point(0, 0);
            this.leFSMs.Name = "leFSMs";
            this.leFSMs.Size = new System.Drawing.Size(279, 190);
            this.leFSMs.TabIndex = 1;
            // 
            // btnDecompose
            // 
            this.btnDecompose.Location = new System.Drawing.Point(28, 122);
            this.btnDecompose.Name = "btnDecompose";
            this.btnDecompose.Size = new System.Drawing.Size(108, 23);
            this.btnDecompose.TabIndex = 0;
            this.btnDecompose.Text = "Декомпозировать";
            this.btnDecompose.Click += new System.EventHandler(this.btnDecompose_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 622);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmTest";
            this.Text = "Декомпозиция вероятностного автомата";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcFSMEdit)).EndInit();
            this.gcFSMEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FSMEditControl fsmEditControl;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private ListEdit leFSMs;
        private DevExpress.XtraEditors.GroupControl gcFSMEdit;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SimpleButton btnDecompose;
    }
}

