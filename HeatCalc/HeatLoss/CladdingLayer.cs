using System;

namespace HeatCalc.HeatLoss
{
    /// <summary>
    /// Класс представляет материал слоя ограждающей конструкции
    /// </summary>
    class CladdingLayer
    {
        /// <summary>
        /// Название материала ограждающей конструкции
        /// </summary>
        public String Name = "Материал Стены/Перекрытия";

        /// <summary>
        /// Коэффициент теплопроводности, Вт / (м2 К)
        /// </summary>
        public double ThermalConductivity;

        /// <summary>
        /// Толщина, м 
        /// </summary>
        public double Thickness;

        /// <summary>
        /// Теплосопротивление слоя ограждающей конструкции, м2 К / Вт
        /// </summary>
        public double R
        {
            get
            {
                return (Math.Abs(ThermalConductivity) < 1e-6) ? 0.0 : Thickness / ThermalConductivity;
            }
        }
    }
}
