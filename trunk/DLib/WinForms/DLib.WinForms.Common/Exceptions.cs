
using System;
using System.Windows.Forms;

namespace DLib.WinForms.Common
{
    /// <summary>
    /// Исключение в форме
    /// </summary>
    [global::System.Serializable]
    public class InterfaceFormException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InterfaceFormException() { }
        public InterfaceFormException(string message) : base(message) { }
        public InterfaceFormException(string message, Exception inner) : base(message, inner) { }
        protected InterfaceFormException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public InterfaceFormException(Form form)
        {
            ProblemForm = form;
        }
        public InterfaceFormException(string message, Form form)
            : base(message)
        {
            ProblemForm = form;
        }

        public Form ProblemForm = null;
    }

    [global::System.Serializable]
    public class DataGridViewException : InterfaceFormException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public DataGridViewException() { }
        public DataGridViewException(string message) : base(message) { }
        public DataGridViewException(string message, Exception inner) : base(message, inner) { }
        protected DataGridViewException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public DataGridViewException(DataGridView dgv)
            : base(dgv.FindForm())
        {
            ProblemDataGridView = dgv;
        }

        public DataGridViewException(string message, DataGridView dgv)
            : base(message, dgv.FindForm())
        {
            ProblemDataGridView = dgv;
        }

        public DataGridView ProblemDataGridView = null;
    }

    /// <summary>
    /// Исключение в текстбоксе
    /// </summary>
    [global::System.Serializable]
    public class TextBoxException : InterfaceFormException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public TextBoxException() { }
        public TextBoxException(string message) : base(message) { }
        public TextBoxException(string message, Exception inner) : base(message, inner) { }
        protected TextBoxException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public TextBoxException(TextBox tb)
            : base(tb.FindForm())
        {
            ProblemTextBox = tb;
        }

        public TextBoxException(TextBox tb, string message)
            : base(message, tb.FindForm())
        {
            ProblemTextBox = tb;
        }

        public TextBox ProblemTextBox = null;
    }

    /// <summary>
    /// Исключение в ячейке таблицы
    /// </summary>
    [global::System.Serializable]
    public class DataGridViewCellException : DataGridViewException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public DataGridViewCellException() { }
        public DataGridViewCellException(string message) : base(message) { }
        public DataGridViewCellException(string message, Exception inner) : base(message, inner) { }
        protected DataGridViewCellException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public DataGridViewCellException(DataGridViewCell cell)
            : base(cell.DataGridView)
        {
            ProblemCell = cell;
        }

        public DataGridViewCellException(DataGridViewCell cell, string message)
            : base(message, cell.DataGridView)
        {
            ProblemCell = cell;
        }

        public DataGridViewCell ProblemCell = null;
    }

    [global::System.Serializable]
    public class ParseFieldException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ParseFieldException() { }
        public ParseFieldException(string message)
            : base(ProcFieldName(message))
        {
            fieldName = message;
        }
        public ParseFieldException(string message, Exception inner) : base(ProcFieldName(message), inner) { }
        protected ParseFieldException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        private static string ProcFieldName(string FieldName)
        {
            return String.Format("Некорректные данные в поле \"{0}\". Обратитесь к разработчику.", FieldName);
        }

        public string FieldName
        {
            get
            {
                return fieldName;
            }
        }
        private string fieldName = string.Empty;
    }
}