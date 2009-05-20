using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Linq;

namespace DLib.WinForms.Drawing
{
    /// <summary>
    /// ÷ветова€ карусель
    /// </summary>
    public class ColorCarouselPicker
    {
        #region Constructors

        public ColorCarouselPicker(IEnumerable<Color> availableColors)
        {
            if (availableColors == null) throw new ArgumentNullException("availableColors");

            AvailableColors = availableColors.ToArray();
        }

        public ColorCarouselPicker()
        {
            LoadColors();
        }

        #endregion

        #region Properties
        public Color[] AvailableColors { get; private set; }

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
        private int index = 0;
        #endregion

        #region Methods
        private void LoadColors()
        {
            AvailableColors = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.Public).
                Where(p => p.PropertyType == typeof(Color)).
                Select(p => p.GetValue(null, null)).
                Cast<Color>().
                Where(c => c.A > 0).
                ToArray();
        }

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