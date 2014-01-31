using System.Collections.Generic;

namespace HeatCalc.HeatLoss
{
    /// <summary>
    /// Класс представляет библиотеку для хранения различных объектов: материалов и т.п.
    /// </summary>
    class Library
    {
        private readonly List<Material> _materials = new List<Material>();
        /// <summary>
        /// Список материалов в библиотеке
        /// </summary>
        public List<Material> Materials
        {
            get { return _materials; }
        }
    }
}
