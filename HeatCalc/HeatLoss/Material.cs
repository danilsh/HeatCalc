using System;

namespace HeatCalc.HeatLoss
{
    /// <summary>
    /// Класс представляет материал слоя ограждающей конструкции
    /// </summary>
    class Material
    {
        /// <summary>
        /// Название материала
        /// </summary>
        public String Name = "Материал";

        /// <summary>
        /// Коэффициент теплопроводности, Вт / (м2 К)
        /// </summary>
        public double ThermalConductivity;
    }
}
