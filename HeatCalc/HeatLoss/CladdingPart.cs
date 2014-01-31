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

        private String _name = "Стена/Перекрытие";
        /// <summary>
        /// Название элемента ограждающей конструкции
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private double _area;
        /// <summary>
        /// Площадь, м2
        /// </summary>
        public double Area
        {
            get { return _area; }
            set { _area = value; }
        }

        /// <summary>
        /// Теплопроводность многослойной ограждающей конструкции, Вт / К
        /// </summary>
        public double Tc
        {
            get
            {
                var tmp = 0.0;
                _layers.ForEach(wl => tmp += wl.R);
                tmp *= _area;

                return (Math.Abs(tmp) < 1e-6) ? 0.0 : 1.0 / tmp * _area;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="area">Площадь, м2</param>
        public CladdingPart(double area)
        {
            _area = area;
        }
    }
}
