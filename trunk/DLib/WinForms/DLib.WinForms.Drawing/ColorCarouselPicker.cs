using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Linq;

namespace DLib.WinForms.Drawing
{
    /// <summary>
    /// �������� ��������. ���������� ����� ������ �� ���������������� ������.
    /// </summary>
    /// <remarks>��-��������� ���������� ����� � ���������� ����� �� �������.
    /// ��� ��������� ��������� (��������, ���������� ������ �����) ���������� �������������� ����� <c>MoveIndex</c></remarks>
    /// <example>
    /// ColorCarouselPicker ColorPicker = new ColorCarouselPicker(new[] { Color.Blue, Color.Red, Color.DarkGreen, Color.DeepPink, Color.DarkMagenta });
    /// foreach (var shape in shapes)
    /// {
    ///     shape.Color = ColorPicker.Value;
    /// }
    /// </example>
    public class ColorCarouselPicker
    {
        #region Constructors
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="availableColors">��������� �����</param>
        public ColorCarouselPicker(IEnumerable<Color> availableColors)
        {
            if (availableColors == null) throw new ArgumentNullException("availableColors");

            AvailableColors = availableColors.ToArray();
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <remarks>��������� ����� ����� ���������������� �������������, ��������� ��������������� ����� .Net Framework</remarks>
        public ColorCarouselPicker()
        {
            LoadColors();
        }

        #endregion

        #region Properties
        /// <summary>
        /// ������ ������� ������
        /// </summary>
        public Color[] AvailableColors { get; private set; }

        /// <summary>
        /// ������� �� ������. ������������� ���������� ��� ������ ���������
        /// </summary>
        public Color Value
        {
            get
            {
                Color result = AvailableColors[index];
                MoveIndex();
                return result;
            }
        }
        #endregion

        #region Fields
        /// <summary>
        /// ������ �������� �����
        /// </summary>
        private int index = 0;
        #endregion

        #region Methods
        /// <summary>
        /// ��������� ����������� �����
        /// </summary>
        private void LoadColors()
        {
            AvailableColors = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public).
                Where(p => p.PropertyType == typeof(Color)).
                Select(p => p.GetValue(null, null)).
                Cast<Color>().
                Where(c => c.A > 0).
                ToArray();
        }

        /// <summary>
        /// ����������� � ���������� �����
        /// </summary>
        /// <returns></returns>
        protected virtual int MoveIndex()
        {
            ++index;
            if (index >= AvailableColors.Length)
                index = 0;
            return index;
        }

        #endregion
    }
}