namespace Test
{
    partial class ListEdit
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
            this.gcMain = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbxItemsSet = new DevExpress.XtraEditors.ListBoxControl();
            this.btnMinus = new DevExpress.XtraEditors.SimpleButton();
            this.btnPlus = new DevExpress.XtraEditors.SimpleButton();
            this.tbxNewItem = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            this.gcMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbxItemsSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxNewItem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMain
            // 
            this.gcMain.Controls.Add(this.tableLayoutPanel1);
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(0, 0);
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(324, 198);
            this.gcMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbxItemsSet, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMinus, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPlus, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxNewItem, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 176);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lbxItemsSet
            // 
            this.lbxItemsSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxItemsSet.Location = new System.Drawing.Point(178, 3);
            this.lbxItemsSet.Name = "lbxItemsSet";
            this.tableLayoutPanel1.SetRowSpan(this.lbxItemsSet, 3);
            this.lbxItemsSet.Size = new System.Drawing.Size(139, 170);
            this.lbxItemsSet.TabIndex = 2;
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(148, 32);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(24, 23);
            this.btnMinus.TabIndex = 3;
            this.btnMinus.Text = "-";
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(148, 3);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(24, 23);
            this.btnPlus.TabIndex = 4;
            this.btnPlus.Text = "+";
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // tbxNewItem
            // 
            this.tbxNewItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbxNewItem.Location = new System.Drawing.Point(3, 3);
            this.tbxNewItem.Name = "tbxNewItem";
            this.tbxNewItem.Size = new System.Drawing.Size(139, 20);
            this.tbxNewItem.TabIndex = 5;
            // 
            // ListEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcMain);
            this.Name = "ListEdit";
            this.Size = new System.Drawing.Size(324, 198);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            this.gcMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbxItemsSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxNewItem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.GroupControl gcMain;
        private DevExpress.XtraEditors.SimpleButton btnMinus;
        private DevExpress.XtraEditors.SimpleButton btnPlus;
        private DevExpress.XtraEditors.ListBoxControl lbxItemsSet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.TextEdit tbxNewItem;

    }
}
