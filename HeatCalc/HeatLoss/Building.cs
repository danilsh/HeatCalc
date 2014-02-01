using System;
using System.Collections.Generic;

namespace HeatCalc.HeatLoss
{
    /// <summary>
    /// Класс описывает здание, для которого считаются теплопотери
    /// </summary>
    class Building
    {
        private readonly List<Zone> _zones = new List<Zone>();
        /// <summary>
        /// Здание делится на зоны, для которых считается приведённая к площади теплопередача
        /// </summary>
        public List<Zone> Zones
        {
            get { return _zones; }
        }

        /// <summary>
        /// Название здания
        /// </summary>
        public String Name = "Здание";

        /// <summary>
        /// Температура наружного воздуха, С
        /// </summary>
        public double ExternalTemperature;

        /// <summary>
        /// Температура внутреннего воздуха, С
        /// </summary>
        public double InternalTemperature;

        /// <summary>
        /// Теплопотери здания, Вт
        /// </summary>
        public double HeatLoss
        {
            get
            {
                var tmp = 0.0;
                _zones.ForEach(z => tmp += z.Tc);
                tmp *= (InternalTemperature - ExternalTemperature);

                return tmp;
            }
        }
    }
}
