using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DLib.WinForms.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnNameAttribute : Attribute
    {
        public String ColumnName
        {
            get { return columnName; }
        }
        private String columnName = String.Empty;

        public ColumnNameAttribute(String columnName)
        {
            this.columnName = columnName;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnTextAttribute : Attribute
    {
        public String ColumnText
        {
            get { return columnText; }
        }
        private String columnText = String.Empty;

        public ColumnTextAttribute(String columnText)
        {
            this.columnText = columnText;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnWidthAttribute : Attribute
    {
        public int ColumnWidth
        {
            get { return columnWidth; }
        }
        private int columnWidth = 50;

        public ColumnWidthAttribute(int Width)
        {
            if (Width > 0)
            {
                this.columnWidth = Width;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class ContentAlignmentAttribute : Attribute
    {
        public ContentAlignment Alignment
        {
            get { return alignment; }
        }
        private ContentAlignment alignment = ContentAlignment.MiddleCenter;

        public ContentAlignmentAttribute(ContentAlignment Alignment)
        {
            this.alignment = (ContentAlignment)Alignment;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class StyleFormatAttribute : Attribute
    {
        public string StyleFormat
        {
            get { return styleFormat; }
        }
        private string styleFormat = string.Empty;

        public StyleFormatAttribute(string StyleFormat)
        {
            this.styleFormat = StyleFormat;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyOrderAttribute : Attribute
    {
        private int order;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Order">Порядковый номер</param>
        public PropertyOrderAttribute(int Order)
        {
            this.order = Order;
        }
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Order
        {
            get { return order; }
        }
    }

    /// <summary>
    /// Пара имя/номер п/п с сортировкой по номеру
    /// </summary>
    public class PropertyOrderPair : IComparable
    {
        private int _order;
        private string _name;
        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name"></param>
        /// <param name="order"></param>
        public PropertyOrderPair(string name, int order)
        {
            _order = order;
            _name = name;
        }

        /// <summary>
        /// Собственно метод сравнения
        /// </summary>
        public int CompareTo(object obj)
        {
            int otherOrder = ((PropertyOrderPair)obj)._order;

            if (otherOrder == _order)
            {
                // если Order одинаковый - сортируем по именам
                string otherName = ((PropertyOrderPair)obj)._name;
                return string.Compare(_name, otherName);
            }
            else if (otherOrder > _order)
                return -1;

            return 1;
        }
    }
}
