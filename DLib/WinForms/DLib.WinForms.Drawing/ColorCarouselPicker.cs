using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Linq;

namespace DLib.WinForms.Drawing
{
    /// <summary>
    /// Цветовая карусель. Производит выбор цветов из предопределённого набора.
    /// </summary>
    /// <remarks>По-умолчанию производит сдвиг к следующему цвету по порядку.
    /// Для изменения поведения (например, случайного выбора цвета) необходимо переопределить метод <c>MoveIndex</c></remarks>
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
        /// Конструктор
        /// </summary>
        /// <param name="availableColors">Доступные цвета</param>
        public ColorCarouselPicker(IEnumerable<Color> availableColors)
        {
            if (availableColors == null) throw new ArgumentNullException("availableColors");

            AvailableColors = availableColors.ToArray();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <remarks>Доступные цвета будут инициализированы автоматически, используя предопределённые цвета .Net Framework</remarks>
        public ColorCarouselPicker()
        {
            LoadColors();
        }

        #endregion

        #region Properties
        /// <summary>
        /// Массив рабочих цветов
        /// </summary>
        public Color[] AvailableColors { get; private set; }

        /// <summary>
        /// Бегунок по цветам. автоматически сдвигается при каждом обращении
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
        /// Индекс текущего цвета
        /// </summary>
        private int index = 0;
        #endregion

        #region Methods
        /// <summary>
        /// Грузануть стандартные цвета
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
        /// Перемещение к следующему цвету
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