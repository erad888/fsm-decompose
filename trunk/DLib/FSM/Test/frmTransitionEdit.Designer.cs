namespace Test
{
    partial class frmTransitionEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransitionEdit));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcTransitions = new DevExpress.XtraGrid.GridControl();
            this.gvTransitions = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTransitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransitions)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcTransitions);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(727, 354);
            this.splitContainerControl1.SplitterPosition = 335;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcTransitions
            // 
            this.gcTransitions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTransitions.EmbeddedNavigator.Name = "";
            this.gcTransitions.Location = new System.Drawing.Point(0, 0);
            this.gcTransitions.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcTransitions.LookAndFeel.UseWindowsXPTheme = true;
            this.gcTransitions.MainView = this.gvTransitions;
            this.gcTransitions.Name = "gcTransitions";
            this.gcTransitions.Size = new System.Drawing.Size(384, 349);
            this.gcTransitions.TabIndex = 0;
            this.gcTransitions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTransitions});
            // 
            // gvTransitions
            // 
            this.gvTransitions.GridControl = this.gcTransitions;
            this.gvTransitions.Name = "gvTransitions";
            // 
            // frmTransitionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 354);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTransitionEdit";
            this.Text = "Редактирование переходов ";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTransitions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransitions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcTransitions;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTransitions;

    }
}