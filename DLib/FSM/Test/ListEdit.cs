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
        }

        public void SyncControl()
        {
            lbxItemsSet.Items.Clear();
            lbxItemsSet.Items.AddRange(Items.ToArray());
            if (lbxItemsSet.Items.Count > 0)
                lbxItemsSet.SelectedIndex = 0;
        }

        public List<object> Items { get; private set; }
        public CreationRuleDelegate CreationRule { get; set; }

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
            if (CreationRule == null)
                throw new NullReferenceException("Не задано правило создание объектов.");

            if (string.IsNullOrEmpty(tbxNewItem.Text))
                throw new NullReferenceException("Значение не задано");

            object value = CreationRule(tbxNewItem.Text);
            if (value == null)
                throw new NullReferenceException("Объект пуст");

            tbxNewItem.Text = string.Empty;
            Add(value);
        }

        private void MinusHandler()
        {
            if (lbxItemsSet.SelectedIndex >= 0)
            {
                int position = lbxItemsSet.SelectedIndex;
                Remove(lbxItemsSet.SelectedItem);
                SetSelectedPosition(position);
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
