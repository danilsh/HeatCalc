using System.Collections.Generic;
using System;

namespace HeatCalc.HeatLoss
{
    /// <summary>
    /// Класс представляет зону, которая является составным элементом здания
    /// </summary>
    class Zone
    {
        private readonly List<Cladding> _claddings = new List<Cladding>();
        /// <summary>
        /// Ограждающие конструкции, входящие в состав зоны
        /// </summary>
        public List<Cladding> Claddings
        {
            get { return _claddings; }
        }

        /// <summary>
        /// Название зоны
        /// </summary>
        public String Name = "Зона";

        /// <summary>
        /// Объем зоны, м3
        /// </summary>
        public double Volume;

        /// <summary>
        /// Объем приточного наружного воздуха, м3 / час
        /// </summary>
        public double AirExchange;

        /// Удельная теплоемкость 1м3 воздуха при постоянном давлении, КДж / (кг * К)
        /// (1 Дж = 1 Вт * с)
        protected const double Cp = 1.0;

        /// Плотность 1 м3 воздуха при температуре 20 C, кг / м3
        protected const double p = 1.20;

        /// <summary>
        /// Теплопроводность ограждающих конструкций зоны,
        /// плюс затраты на оборот воздуха в помещениях, Вт / К
        /// </summary>
        public double Tc 
        {
            get
            {
                // Вт * с / (кг * К) * кг / м3 * м3 / с = Вт / К 
                var tmp = Cp * p * AirExchange * 1000.0 / 3600.0;

                _claddings.ForEach(c => tmp += c.Tc);

                return tmp;
            }
        }
    }
}
