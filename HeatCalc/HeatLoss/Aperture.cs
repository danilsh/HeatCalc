using System;

namespace HeatCalc.HeatLoss
{

    /// <summary>
    /// Класс представляет Двери/Окна/Люки
    /// </summary>
    class Aperture
    {
        /// <summary>
        /// Название окна/двери/люка
        /// </summary>
        public String Name = "Окно/Дверь/Люк";

        /// <summary>
        /// Коэффициент теплопроводности, Вт / (м2 К)
        /// </summary>
        public double HeatTransferCoefficient;

        /// <summary>
        /// Площадь, м2
        /// </summary>
        public double Area;

        /// <summary>
        /// Теплопроводность окна/двери/люка, Вт / К
        /// </summary>
        public double Tc
        {
            get
            {
                return HeatTransferCoefficient * Area;
            }
        }
    }
}
