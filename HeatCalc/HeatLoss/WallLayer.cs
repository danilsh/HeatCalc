using System;

namespace HeatCalc.HeatLoss
{
    /// <summary>
    /// Класс представляет материал слоя ограждающей конструкции
    /// </summary>
    class WallLayer
    {
        private double _thermalConductivity;
        /// <summary>
        /// Коэффициент теплопроводности, Вт / (м2 К)
        /// </summary>
        public double ThermalConductivity
        {
            get { return _thermalConductivity; }
            set { _thermalConductivity = value; }
        }
    
        private double _layerThickness;
        /// <summary>
        /// Толщина, м 
        /// </summary>
        public double LayerThickness
        {
            get { return _layerThickness; }
            set { _layerThickness = value; }
        }

        /// <summary>
        /// Теплосопротивление слоя стены, м2 К / Вт
        /// </summary>
        public double R
        {
            get
            {
                return (Math.Abs(_thermalConductivity) < 1e-6) ? 0.0 : _layerThickness / _thermalConductivity;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="thermalConductivity">Коэффициент теплопроводности, Вт / (м2 К)</param>
        /// <param name="layerThickness">Толщина, м</param>
        public WallLayer(double thermalConductivity, double layerThickness)
        {
            _thermalConductivity = thermalConductivity;
            _layerThickness = layerThickness;
        }
    }
}
