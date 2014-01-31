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

        private String _name = "Здание";
        /// <summary>
        /// Название здания
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private double _externalTemperature;
        /// <summary>
        /// Температура наружного воздуха, С
        /// </summary>
        public double ExternalTemperature
        {
            get { return _externalTemperature; }
            set { _externalTemperature = value; }
        }
    
        private double _internalTemperature;
        /// <summary>
        /// Температура внутреннего воздуха, С
        /// </summary>
        public double InternalTemperature
        {
            get { return _internalTemperature; }
            set { _internalTemperature = value; }
        }

        /// <summary>
        /// Теплопотери здания, Вт
        /// </summary>
        public double HeatLoss
        {
            get
            {
                var tmp = 0.0;
                _zones.ForEach(z => tmp += z.Tc);
                tmp *= (_internalTemperature - _externalTemperature);

                return tmp;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="externalTemperature">Внешняя температура, С</param>
        /// <param name="internalTemperature">Температура в помещении, С</param>
        public Building(double externalTemperature, double internalTemperature)
        {
            _externalTemperature = externalTemperature;
            _internalTemperature = internalTemperature;
        }   
    }
}
