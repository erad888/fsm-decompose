﻿namespace Test
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
            this.components = new System.ComponentModel.Container();
            this.fsmNetControl1 = new FSM.FSMWinControls.FSMNetControl(this.components);
            this.SuspendLayout();
            // 
            // fsmNetControl1
            // 
            this.fsmNetControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsmNetControl1.Location = new System.Drawing.Point(0, 0);
            this.fsmNetControl1.Name = "fsmNetControl1";
            this.fsmNetControl1.Size = new System.Drawing.Size(284, 264);
            this.fsmNetControl1.TabIndex = 0;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.fsmNetControl1);
            this.Name = "frmTest";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private FSM.FSMWinControls.FSMNetControl fsmNetControl1;
    }
}

