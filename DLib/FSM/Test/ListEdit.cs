using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogicUtils;

namespace Test
{
    public partial class ListEdit : UserControl
    {
        public ListEdit()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            Items = new List<object>();
            lbxItemsSet.SelectedValueChanged += lbxItemsSet_SelectedValueChanged;
            lbxItemsSet.SelectedIndexChanged += lbxItemsSet_SelectedIndexChanged;
        }

        void lbxItemsSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SelectedIndexChanged != null)
                SelectedIndexChanged(this, new TemplateEventArgs<int>(lbxItemsSet.SelectedIndex));
        }

        void lbxItemsSet_SelectedValueChanged(object sender, EventArgs e)
        {
            if(SelectedValueChanged != null)
                SelectedValueChanged(this, new TemplateEventArgs<object>(lbxItemsSet.SelectedValue));
        }

        public event EventHandler<TemplateEventArgs<object>> SelectedValueChanged;
        public event EventHandler<TemplateEventArgs<int>> SelectedIndexChanged;

        public void SyncControl()
        {
            lbxItemsSet.Items.Clear();
            lbxItemsSet.Items.AddRange(Items.ToArray());
            if (lbxItemsSet.Items.Count > 0)
                lbxItemsSet.SelectedIndex = 0;
        }

        public bool AllowRename { get; set; }

        public List<object> Items { get; private set; }
        public CreationRuleDelegate CreationRule { get; set; }

        public string Caption
        {
            get { return gcMain.Text; }
            set
            {
                if (value != null)
                {
                    gcMain.Text = value;
                }
            }
        }

        private int savedPosition = -1;

        public void SaveSelectedPosition()
        {
            savedPosition = lbxItemsSet.SelectedIndex;
        }
        public void RestoreSelectedPosition()
        {
            SetSelectedPosition(savedPosition);
        }

        public void SetSelectedPosition(int position)
        {
            if (lbxItemsSet.Items.Count > position)
                lbxItemsSet.SelectedIndex = position;
            else
                if (lbxItemsSet.Items.Count > 0)
                    lbxItemsSet.SelectedIndex = lbxItemsSet.Items.Count - 1;
        }

        public bool Add(object Value)
        {
            bool result = false;
            if (NotifyItemAdded(Value))
            {
                //Items.Add(Value);
                SyncControl();
                result = true;
            }
            return result;
        }

        public bool Remove(object Value)
        {
            bool result = false;
            if(NotifyItemRemoved(Value))
            {
                result = true;
                SyncControl();
            }
            return result;
        }

        private void AddHandler()
        {
            try
            {
                if (CreationRule == null)
                    throw new NullReferenceException("Не задано правило создания объектов.");

                if (string.IsNullOrEmpty(tbxNewItem.Text))
                    throw new NullReferenceException("Значение не задано");

                object value = CreationRule(tbxNewItem.Text);
                if (value == null)
                    throw new NullReferenceException("Объект пуст");

                tbxNewItem.Text = string.Empty;
                Add(value);
                lbxItemsSet.SelectedItem = value;
                tbxNewItem.Focus();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MinusHandler()
        {
            try
            {
                if (lbxItemsSet.SelectedIndex >= 0)
                {
                    int position = lbxItemsSet.SelectedIndex;
                    Remove(lbxItemsSet.SelectedItem);
                    SetSelectedPosition(position);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public event EventHandler<TemplateEventArgs<object>> ItemAdded;
        private bool NotifyItemAdded(object Item)
        {
            bool result = false;
            if (ItemAdded != null)
            {
                var args = new TemplateEventArgs<object>(Item);
                ItemAdded(this, args);
                result = !args.Cancel;
            }
            return result;
        }

        public event EventHandler<TemplateEventArgs<object>> ItemRemoved;
        private bool NotifyItemRemoved(object Item)
        {
            bool result = false;
            if (ItemRemoved != null)
            {
                var args = new TemplateEventArgs<object>(Item);
                ItemRemoved(this, args);
                result = !args.Cancel;
            }
            return result;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            AddHandler();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            MinusHandler();
        }
    }

    public delegate object CreationRuleDelegate(string StrObject);
    public delegate string PresentationRuleDelegate(object EntityObject);

    public class TemplateEventArgs<T> : EventArgs
    {
        public TemplateEventArgs()
        {
            Cancel = false;
        }
        public TemplateEventArgs(T Value):this()
        {
            this.Value = Value;
        }

        public T Value { get; set; }
        public bool Cancel { get; set; }
    }
}
