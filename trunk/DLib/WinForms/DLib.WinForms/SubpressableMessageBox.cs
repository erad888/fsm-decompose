using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DLib.WinForms
{
    public partial class SubpressableMessageBox : Form
    {
        public SubpressableMessageBox()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            cbx.DataBindings.Clear();
            cbx.DataBindings.Add("Checked", this, "Checked");
            cbx.DataBindings.Add("Text", this, "CheckBoxText");
            this.DataBindings.Add("Text", this, "HeaderText");
            lblMessage.DataBindings.Add("Text", this, "Message");


            HeaderText = string.Empty;
            Message = string.Empty;
            CheckBoxText = string.Empty;
            Checked = false;
        }

        private void RefreshButtons()
        {
            btnOk.Visible = (Buttons & MessageBoxButtons.OK) == MessageBoxButtons.OK;
        }

        public string HeaderText { get; set; }
        public string Message { get; set; }
        public string CheckBoxText { get; set; }
        public bool Checked { get; set; }
        public MessageBoxButtons Buttons { get; set; }

    }
}
