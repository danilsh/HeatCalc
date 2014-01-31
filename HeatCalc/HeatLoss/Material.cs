using System;

namespace HeatCalc.HeatLoss
{
    /// <summary>
    /// Класс представляет материал слоя ограждающей конструкции
    /// </summary>
    class Material
    {
        private String _name = "Материал";
        /// <summary>
        /// Название материала
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
    
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="thermalConductivity">Коэффициент теплопроводности, Вт / (м2 К)</param>
        public Material(double thermalConductivity)
        {
            _thermalConductivity = thermalConductivity;
        }
    }
}
