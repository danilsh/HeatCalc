using System;
using System.Collections.Generic;

namespace HeatCalc.HeatLoss
{
    /// <summary>
    /// Элемент ограждающей конструкции
    /// </summary>
    class CladdingPart
    {
        private readonly List<CladdingLayer> _layers = new List<CladdingLayer>();
        /// <summary>
        /// Материал слоя ограждающей конструкции
        /// </summary>
        public List<CladdingLayer> Layers
        {
            get { return _layers; }
        }

        /// <summary>
        /// Название элемента ограждающей конструкции
        /// </summary>
        public String Name = "Стена/Перекрытие";

        /// <summary>
        /// Площадь, м2
        /// </summary>
        public double Area;

        /// <summary>
        /// Теплопроводность многослойной ограждающей конструкции, Вт / К
        /// </summary>
        public double Tc
        {
            get
            {
                var tmp = 0.0;
                _layers.ForEach(wl => tmp += wl.R);
                tmp *= Area;

                return (Math.Abs(tmp) < 1e-6) ? 0.0 : 1.0 / tmp * Area;
            }
        }
    }
}
