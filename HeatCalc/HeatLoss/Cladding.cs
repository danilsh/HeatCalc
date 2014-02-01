using System;
using System.Collections.Generic;

namespace HeatCalc.HeatLoss
{
    /// <summary>
    /// Ограждающая конструкция
    /// </summary>
    class Cladding
    {
        private readonly List<Aperture> _apertures = new List<Aperture>();
        /// <summary>
        /// Окна/двери/люки
        /// </summary>
        public List<Aperture> Apertures
        {
            get { return _apertures; }
        }

        private readonly List<CladdingPart> _parts = new List<CladdingPart>();
        /// <summary>
        /// Элементы ограждающей конструкции
        /// </summary>
        public List<CladdingPart> Parts
        {
            get { return _parts; }
        }

        /// <summary>
        /// Название ограждающей конструкции
        /// </summary>
        public String Name = "Ограждающая конструкция";

        /// <summary>
        /// Теплопроводность ограждающей конструкции, Вт / К
        /// </summary>
        public double Tc
        {
            get
            {
                var tmp = 0.0;

                _apertures.ForEach(a => tmp += a.Tc);
                _parts.ForEach(wp => tmp += wp.Tc);

                return tmp;
            }
        }
    }
}
