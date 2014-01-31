using System;

namespace HeatCalc.HeatLoss
{
    /// <summary>
    /// Класс представляет материал слоя ограждающей конструкции
    /// </summary>
    class CladdingLayer
    {
        private String _name = "Материал Стены/Перекрытия";
        /// <summary>
        /// Название материала ограждающей конструкции
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private double _thermalConductivity;
        /// <summary>
        /// Коэффициент теплопроводности, Вт / (м2 К)
        /// </summary>
        public double ThermalConductivity
        {
            get { return _thermalConductivity; }
            set { _thermalConductivity = value; }
        }
    
        private double _thickness;
        /// <summary>
        /// Толщина, м 
        /// </summary>
        public double Thickness
        {
            get { return _thickness; }
            set { _thickness = value; }
        }

        /// <summary>
        /// Теплосопротивление слоя ограждающей конструкции, м2 К / Вт
        /// </summary>
        public double R
        {
            get
            {
                return (Math.Abs(_thermalConductivity) < 1e-6) ? 0.0 : _thickness / _thermalConductivity;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="thermalConductivity">Коэффициент теплопроводности, Вт / (м2 К)</param>
        /// <param name="thickness">Толщина, м</param>
        public CladdingLayer(double thermalConductivity, double thickness)
        {
            _thermalConductivity = thermalConductivity;
            _thickness = thickness;
        }
    }
}
