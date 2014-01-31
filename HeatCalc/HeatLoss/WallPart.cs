using System;
using System.Collections.Generic;

namespace HeatCalc.HeatLoss
{
    /// <summary>
    /// Элемент ограждающей конструкции
    /// </summary>
    class WallPart
    {
        private readonly List<WallLayer> _wallLayers = new List<WallLayer>();
        /// <summary>
        /// Материал слоя ограждающей конструкции
        /// </summary>
        public List<WallLayer> WallLayers
        {
            get { return _wallLayers; }
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
        /// Теплопроводность многослойной стены, Вт / К
        /// </summary>
        public double Tc
        {
            get
            {
                var tmp = 0.0;
                _wallLayers.ForEach(wl => tmp += wl.R);
                tmp *= _area;

                return (Math.Abs(tmp) < 1e-6) ? 0.0 : 1.0 / tmp * _area;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="area">Площадь, м2</param>
        public WallPart(double area)
        {
            _area = area;
        }
    }
}
