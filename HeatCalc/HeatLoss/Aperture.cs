using System;

namespace HeatCalc.HeatLoss
{

    /// <summary>
    /// Класс представляет Двери/Окна/Люки
    /// </summary>
    class Aperture
    {
        private String _name = "Окно/Дверь/Люк";
        /// <summary>
        /// Название окна/двери/люка
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private double _heatTransferCoefficient;
        /// <summary>
        /// Коэффициент теплопроводности, Вт / (м2 К)
        /// </summary>
        public double HeatTransferCoefficient
        {
            get { return _heatTransferCoefficient; }
            set { _heatTransferCoefficient = value; }
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
        /// Теплопроводность окна/двери/люка, Вт / К
        /// </summary>
        public double Tc
        {
            get
            {
                return _heatTransferCoefficient * _area;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="heatTransferCoefficient">Коэффициент теплопередачи, Вт / (м2 К)</param>
        /// <param name="area">Площадь, м2</param>
        public Aperture(double heatTransferCoefficient, double area)
        {
            _heatTransferCoefficient = heatTransferCoefficient;
            _area = area;
        }
    }
}
