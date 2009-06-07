namespace Test
{
    partial class PartitionEditControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbxStates = new DevExpress.XtraEditors.ListBoxControl();
            this.btnToTemp = new DevExpress.XtraEditors.SimpleButton();
            this.btnAllToTemp = new DevExpress.XtraEditors.SimpleButton();
            this.btnFromTemp = new DevExpress.XtraEditors.SimpleButton();
            this.btnAllFromTemp = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lbxTempStates = new DevExpress.XtraEditors.ListBoxControl();
            this.gcBlocks = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbxBlocks = new DevExpress.XtraEditors.ListBoxControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbxStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbxTempStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBlocks)).BeginInit();
            this.gcBlocks.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbxBlocks)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.49645F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.6974F));
            this.tableLayoutPanel1.Controls.Add(this.lbxStates, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnToTemp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAllToTemp, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnFromTemp, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAllFromTemp, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.splitContainerControl1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(578, 311);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbxStates
            // 
            this.lbxStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxStates.Location = new System.Drawing.Point(3, 3);
            this.lbxStates.Name = "lbxStates";
            this.tableLayoutPanel1.SetRowSpan(this.lbxStates, 6);
            this.lbxStates.Size = new System.Drawing.Size(172, 305);
            this.lbxStates.TabIndex = 0;
            // 
            // btnToTemp
            // 
            this.btnToTemp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnToTemp.Location = new System.Drawing.Point(181, 100);
            this.btnToTemp.Name = "btnToTemp";
            this.btnToTemp.Size = new System.Drawing.Size(46, 23);
            this.btnToTemp.TabIndex = 3;
            this.btnToTemp.Text = ">";
            this.btnToTemp.Click += new System.EventHandler(this.btnToTemp_Click);
            // 
            // btnAllToTemp
            // 
            this.btnAllToTemp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAllToTemp.Location = new System.Drawing.Point(181, 129);
            this.btnAllToTemp.Name = "btnAllToTemp";
            this.btnAllToTemp.Size = new System.Drawing.Size(46, 23);
            this.btnAllToTemp.TabIndex = 4;
            this.btnAllToTemp.Text = ">>";
            this.btnAllToTemp.Click += new System.EventHandler(this.btnAllToTemp_Click);
            // 
            // btnFromTemp
            // 
            this.btnFromTemp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFromTemp.Location = new System.Drawing.Point(181, 158);
            this.btnFromTemp.Name = "btnFromTemp";
            this.btnFromTemp.Size = new System.Drawing.Size(46, 23);
            this.btnFromTemp.TabIndex = 5;
            this.btnFromTemp.Text = "<";
            this.btnFromTemp.Click += new System.EventHandler(this.btnFromTemp_Click);
            // 
            // btnAllFromTemp
            // 
            this.btnAllFromTemp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAllFromTemp.Location = new System.Drawing.Point(181, 187);
            this.btnAllFromTemp.Name = "btnAllFromTemp";
            this.btnAllFromTemp.Size = new System.Drawing.Size(46, 23);
            this.btnAllFromTemp.TabIndex = 6;
            this.btnAllFromTemp.Text = "<<";
            this.btnAllFromTemp.Click += new System.EventHandler(this.btnAllFromTemp_Click);
            // 
            // splitContainerControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainerControl1, 2);
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(233, 3);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.lbxTempStates);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcBlocks);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.tableLayoutPanel1.SetRowSpan(this.splitContainerControl1, 6);
            this.splitContainerControl1.Size = new System.Drawing.Size(342, 305);
            this.splitContainerControl1.SplitterPosition = 120;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // lbxTempStates
            // 
            this.lbxTempStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxTempStates.Location = new System.Drawing.Point(0, 0);
            this.lbxTempStates.Name = "lbxTempStates";
            this.lbxTempStates.Size = new System.Drawing.Size(116, 301);
            this.lbxTempStates.TabIndex = 1;
            // 
            // gcBlocks
            // 
            this.gcBlocks.Controls.Add(this.tableLayoutPanel2);
            this.gcBlocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBlocks.Location = new System.Drawing.Point(0, 0);
            this.gcBlocks.Name = "gcBlocks";
            this.gcBlocks.Size = new System.Drawing.Size(212, 301);
            this.gcBlocks.TabIndex = 0;
            this.gcBlocks.Text = "Блоки разбиения :";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lbxBlocks, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAdd, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnRemove, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(208, 279);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbxBlocks
            // 
            this.lbxBlocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxBlocks.Location = new System.Drawing.Point(38, 3);
            this.lbxBlocks.Name = "lbxBlocks";
            this.tableLayoutPanel2.SetRowSpan(this.lbxBlocks, 4);
            this.lbxBlocks.Size = new System.Drawing.Size(167, 273);
            this.lbxBlocks.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdd.Location = new System.Drawing.Point(3, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRemove.Location = new System.Drawing.Point(3, 54);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(29, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "-";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // PartitionEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PartitionEditControl";
            this.Size = new System.Drawing.Size(578, 311);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbxStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbxTempStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBlocks)).EndInit();
            this.gcBlocks.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbxBlocks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.ListBoxControl lbxStates;
        private DevExpress.XtraEditors.ListBoxControl lbxTempStates;
        private DevExpress.XtraEditors.SimpleButton btnToTemp;
        private DevExpress.XtraEditors.SimpleButton btnAllToTemp;
        private DevExpress.XtraEditors.SimpleButton btnFromTemp;
        private DevExpress.XtraEditors.SimpleButton btnAllFromTemp;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl gcBlocks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.ListBoxControl lbxBlocks;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
    }
}
