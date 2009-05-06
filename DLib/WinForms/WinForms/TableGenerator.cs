using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DLib.WinForms.Common;

namespace DLib.WinForms
{
    /// <summary>
    /// Куча для работы с гридой (DataGridView)
    /// </summary>
    /// <remarks>Неплохо бы их раскидать по классам</remarks>
    public static class TableGenerator
    {
        /// <summary>
        /// Вытащить таблицу из гриды
        /// </summary>
        /// <param name="dgv">Грид</param>
        /// <returns>Таблица</returns>
        public static DataTable GenTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                DataColumn columnRes = new DataColumn(column.Name);
                columnRes.Caption = column.HeaderText;
                dt.Columns.Add(columnRes);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow rowRes = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    rowRes[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(rowRes);
            }

            return dt;
        }
        /// <summary>
        /// Создать шаблон таблицы на основе типа
        /// </summary>
        /// <param name="TableName">Имя таблицы</param>
        /// <param name="WrappedType">Тип, размеченный аттрибутами ColumnName (и ему подобными)</param>
        /// <returns>Таблица</returns>
        public static DataTable GenTable(string TableName, Type WrappedType)
        {
            DataTable result = new DataTable(TableName);
            foreach (PropertyInfo var in WrappedType.GetProperties())
            {
                ColumnNameAttribute name = (ColumnNameAttribute)Attribute.GetCustomAttribute(var, typeof(ColumnNameAttribute));
                if (name != null)
                {
                    DataColumn column = new DataColumn(name.ColumnName, var.PropertyType);
                    ColumnTextAttribute text = (ColumnTextAttribute)Attribute.GetCustomAttribute(var, typeof(ColumnTextAttribute));
                    if (text != null)
                    {
                        column.Caption = text.ColumnText;
                    }
                    result.Columns.Add(column);
                }
            }
            return result;
        }
        /// <summary>
        /// Сгенерить строку таблицы на основе объекта
        /// </summary>
        /// <param name="Value">Объект, по которому генерится строка</param>
        /// <param name="Table">Таблица, для которой генерится строка</param>
        /// <returns>Строка</returns>
        public static DataRow GenRowFromObject(object Value, DataTable Table)
        {
            DataRow result = Table.NewRow();
            foreach (PropertyInfo var in Value.GetType().GetProperties())
            {
                ColumnNameAttribute name = (ColumnNameAttribute)Attribute.GetCustomAttribute(var, typeof(ColumnNameAttribute));
                if (name != null)
                {
                    if (Table.Columns.Contains(name.ColumnName))
                    {
                        MethodInfo mi = var.GetGetMethod();
                        if (mi != null)
                        {
                            Object obj = mi.Invoke(Value, null);
                            result[name.ColumnName] = obj;
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Преобразовать имя колонки к индексу колонки
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="dgv"></param>
        /// <returns></returns>
        private static int ToIndex(string columnName, DataGridView dgv)
        {
            return dgv.Columns[columnName].Index;
        }
        /// <summary>
        /// Наполнить колонки на основе типа.
        /// </summary>
        /// <param name="columns">Коллекция колонок</param>
        /// <param name="type">Тип, размеченный аттрибутами</param>
        public static void ParseAllPropsIntoColumns(DataGridViewColumnCollection columns, Type type)
        {
            PropertyInfo[] props = type.GetProperties();
            ArrayList propsNames = new ArrayList(props.Length);

            foreach (PropertyInfo prop in props)
            {
                PropertyOrderAttribute att = (PropertyOrderAttribute)Attribute.GetCustomAttribute(prop, typeof(PropertyOrderAttribute));
                if (att != null)
                    propsNames.Add(new PropertyOrderPair(prop.Name, att.Order));
                else
                    propsNames.Add(new PropertyOrderPair(prop.Name, 0));
            }

            propsNames.Sort();

            DataGridViewCell cell = new DataGridViewTextBoxCell();
            for (int i = 0; i < propsNames.Count; ++i)
            {
                PropertyInfo prop = type.GetProperty((propsNames[i] as PropertyOrderPair).Name);

                ColumnNameAttribute attName = (ColumnNameAttribute)Attribute.GetCustomAttribute(prop, typeof(ColumnNameAttribute));
                if (attName != null)
                {
                    DataGridViewColumn column = new DataGridViewColumn();
                    column.Name = attName.ColumnName;
                    column.CellTemplate = cell;

                    ColumnWidthAttribute attWidth = (ColumnWidthAttribute)Attribute.GetCustomAttribute(prop, typeof(ColumnWidthAttribute));
                    if (attWidth != null)
                        column.Width = attWidth.ColumnWidth;
                    else
                        column.Width = 100;

                    ColumnTextAttribute attText = (ColumnTextAttribute)Attribute.GetCustomAttribute(prop, typeof(ColumnTextAttribute));
                    if (attText != null)
                        column.HeaderText = attText.ColumnText;
                    else
                        column.HeaderText = attName.ColumnName;

                    if (prop.GetSetMethod() != null)
                    {
                        ReadOnlyAttribute attRO = (ReadOnlyAttribute)Attribute.GetCustomAttribute(prop, typeof(ReadOnlyAttribute));
                        if (attRO != null)
                            column.ReadOnly = attRO.IsReadOnly;
                    }

                    ContentAlignmentAttribute attAl = (ContentAlignmentAttribute)Attribute.GetCustomAttribute(prop, typeof(ContentAlignmentAttribute));
                    if (attAl != null)
                        column.HeaderCell.Style.Alignment = (DataGridViewContentAlignment)(attAl.Alignment);

                    columns.Add(column);
                }
            }
        }
        /// <summary>
        /// Наполнить ячейки данными из объекта.
        /// </summary>
        /// <param name="cells">Коллекция ячеек</param>
        /// <param name="obj">Объект, откуда брать данные</param>
        /// <param name="dgv">Грида, в которой всё происходит</param>
        /// <remarks>Обёртка</remarks>
        public static void ParseAllPropsIntoCells(DataGridViewCellCollection cells, object obj, DataGridView dgv)
        {
            ParseAllPropsIntoCells(cells, obj, dgv, false);
        }
        /// <summary>
        /// Наполнить ячейки данными из объекта.
        /// </summary>
        /// <param name="cells">Коллекция ячеек</param>
        /// <param name="obj">Объект, откуда брать данные</param>
        /// <param name="dgv">Грида, в которой всё происходит</param>
        /// <param name="withTagFilling">Пихать ли в <c>DataGridViewCell.Tag</c> ссылку на данные</param>
        public static void ParseAllPropsIntoCells(DataGridViewCellCollection cells, object obj, DataGridView dgv, bool withTagFilling)
        {
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                ColumnNameAttribute attName = (ColumnNameAttribute)Attribute.GetCustomAttribute(prop, typeof(ColumnNameAttribute));
                if (attName != null)
                {
                    if (dgv.Columns.Contains(attName.ColumnName))
                    {
                        cells[ToIndex(attName.ColumnName, dgv)].Value = prop.GetGetMethod().Invoke(obj, null).ToString();
                        if (withTagFilling)
                            cells[ToIndex(attName.ColumnName, dgv)].Tag = prop.GetGetMethod().Invoke(obj, null);

                        StyleFormatAttribute attSt = (StyleFormatAttribute)Attribute.GetCustomAttribute(prop, typeof(StyleFormatAttribute));
                        if (attSt != null)
                            cells[ToIndex(attName.ColumnName, dgv)].Style.Format = attSt.StyleFormat;
                    }
                }
            }
        }
        /// <summary>
        /// Распарсить строку в объект
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="Row">Строка</param>
        /// <returns>Объект</returns>
        public static T GenObjectFromRow<T>(DataRow Row) where T : new()
        {
            T result = new T();
            foreach (PropertyInfo var in result.GetType().GetProperties())
            {
                ColumnNameAttribute name = (ColumnNameAttribute)Attribute.GetCustomAttribute(var, typeof(ColumnNameAttribute));
                if (name != null)
                {
                    if (Row.Table.Columns.Contains(name.ColumnName))
                    {
                        MethodInfo mi = var.GetSetMethod();
                        if (mi != null)
                            mi.Invoke(result, new object[] { Row[name.ColumnName] });
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Target"></param>
        /// <returns></returns>
        public delegate T SelectDelegate<T>(object Target);
        /// <summary>
        /// Распарсить отмеченные (галочкой) ячейки гриды в коллекцию объектов.
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="dgv">Грида</param>
        /// <param name="SelectionColumnName">Имя колонки, в которой находятся галочки (CheckBoxCell)</param>
        /// <returns>Коллекция объектов</returns>
        public static List<T> GetItemsFromCheckedRowsTags<T>(DataGridView dgv, string SelectionColumnName) where T : class
        {
            List<T> result = new List<T>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[SelectionColumnName] as DataGridViewCheckBoxCell;
                if (cell != null)
                    if (row.Tag is T)
                        if (cell.Value != null && (bool)cell.Value)
                            result.Add(row.Tag as T);
            }
            return result;
        }
        /// <summary>
        /// Распарсить отмеченные (галочкой) ячейки гриды в коллекцию объектов.
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="dgv">Грида</param>
        /// <param name="SelectionColumnName">Имя колонки, в которой находятся галочки (CheckBoxCell)</param>
        /// <param name="Selector">Селектор, для преобразования объектов, лежащих в ячейках, к результирующему типу T</param>
        /// <returns>Коллекция объектов</returns>
        public static List<T> GetItemsFromCheckedRowsTags<T>(DataGridView dgv, string SelectionColumnName, SelectDelegate<T> Selector) where T : class
        {
            List<T> result = new List<T>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[SelectionColumnName] as DataGridViewCheckBoxCell;
                if (cell != null)
                {
                    T temp = Selector(row.Tag);
                    if (temp != null)
                        if (cell.Value != null && (bool)cell.Value)
                            result.Add(temp);
                }
            }
            return result;
        }
        /// <summary>
        /// Вытащить объекты из ячеек
        /// </summary>
        /// <typeparam name="T">Тип объектов</typeparam>
        /// <param name="cells">Ячейки</param>
        /// <returns>Коллекция объектов</returns>
        public static List<T> GetItemsFromCellsTags<T>(DataGridViewCellCollection cells) where T : class
        {
            List<T> result = new List<T>();
            foreach (DataGridViewCell cell in cells)
            {
                if (cell.Tag is T)
                    result.Add(cell.Tag as T);
            }
            return result;
        }
        /// <summary>
        /// Вытащить объекты из Tag`ов отмеченных (галочкой) строк
        /// </summary>
        /// <typeparam name="T">Тип объектов</typeparam>
        /// <param name="dgv">Грида</param>
        /// <param name="SelectionColumnName">Имя столбца с галочками</param>
        /// <returns></returns>
        public static List<T> GetItemsFromCheckedRowsCellsTags<T>(DataGridView dgv, string SelectionColumnName) where T : class
        {
            List<T> result = new List<T>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[SelectionColumnName] as DataGridViewCheckBoxCell;
                if (cell != null)
                    if (cell.Value != null && (bool)cell.Value)
                    {
                        List<T> data = GetItemsFromCellsTags<T>(row.Cells);
                        if (data.Count > 0)
                            result.Add(data[0]);
                    }
            }
            return result;
        }
        /// <summary>
        /// Вытащить объекты из Tag`ов отмеченных (галочкой) строк
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="SelectionColumnName"></param>
        /// <param name="columnNames"></param>
        /// <returns></returns>
        public static List<Object> GetItemsFromCheckedRowsCellsTags(DataGridView dgv, string SelectionColumnName, string[] columnNames)
        {
            if (columnNames.Length == 0)
                return GetItemsFromCheckedRowsCellsTags<Object>(dgv, SelectionColumnName);
            else
            {
                List<Object> result = new List<Object>();

                List<int> indexes = new List<int>();
                foreach (string columnName in columnNames)
                {
                    if (dgv.Columns.Contains(columnName))
                        indexes.Add(dgv.Columns[columnName].Index);
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[SelectionColumnName] as DataGridViewCheckBoxCell;
                    if (cell != null)
                        if (cell.Value != null && (bool)cell.Value)
                        {
                            foreach (int index in indexes)
                            {
                                Object temp = row.Cells[index].Tag;
                                if (temp != null)
                                    result.Add(temp);
                            }
                        }
                }
                return result;
            }
        }
    }
}
