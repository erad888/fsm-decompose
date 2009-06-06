namespace Test
{
    partial class frmPatitionsEdit
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
            this.pec = new Test.PartitionsEditControl();
            this.SuspendLayout();
            // 
            // pec
            // 
            this.pec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pec.Location = new System.Drawing.Point(0, 0);
            this.pec.Name = "pec";
            this.pec.Size = new System.Drawing.Size(586, 388);
            this.pec.TabIndex = 0;
            // 
            // frmPatitionsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 388);
            this.Controls.Add(this.pec);
            this.Name = "frmPatitionsEdit";
            this.Text = "frmPatitionsEdit";
            this.ResumeLayout(false);

        }

        #endregion

        private PartitionsEditControl pec;
    }
}