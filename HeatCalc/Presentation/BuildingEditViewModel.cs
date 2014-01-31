using System;
using System.Globalization;
using HeatCalc.MVVM.Common;
using HeatCalc.HeatLoss;

namespace HeatCalc.Presentation
{
    class BuildingEditViewModel : ObservableObject
    {
        private readonly Building _building;
        private readonly BuildingViewModel _buildingViewModel;

        public String Name
        {
            get { return _building.Name; }
            set
            {
                if (String.IsNullOrEmpty(value)) return;
                var tmp = _building.Name;
                if (!SetValue(ref tmp, value, "Name")) return;
                _building.Name = tmp;
                _buildingViewModel.Update();
            }
        }

        public String ExternalTemperature
        {
            get { return String.Format("{0:0.#}", _building.ExternalTemperature); }
            set
            {
                var tmp = _building.ExternalTemperature;
                if (!SetValue(ref tmp, double.Parse(value, CultureInfo.InvariantCulture), "ExternalTemperature")) return;
                _building.ExternalTemperature = tmp;
                _buildingViewModel.Update();
            }
        }

        public String InternalTemperature
        {
            get { return String.Format("{0:0.#}", _building.InternalTemperature); }
            set
            {
                var tmp = _building.InternalTemperature;
                if (!SetValue(ref tmp, double.Parse(value, CultureInfo.InvariantCulture), "InternalTemperature")) return;
                _building.InternalTemperature = tmp;
                _buildingViewModel.Update();
            }
        }

        public BuildingEditViewModel(Building building, BuildingViewModel buildingViewModel)
        {
            _building = building;
            _buildingViewModel = buildingViewModel;
        }
    }
}
