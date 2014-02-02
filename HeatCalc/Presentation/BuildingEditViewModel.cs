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
                if (!SetValue(ref _building.Name, value, "Name")) return;
                MainWindowViewModel.CurrentMainWindowViewModel.IsDirty = true;
                _buildingViewModel.Update();
            }
        }

        public String ExternalTemperature
        {
            get { return String.Format("{0:0.#}", _building.ExternalTemperature); }
            set
            {
                if (!SetValue(ref _building.ExternalTemperature, double.Parse(value), "ExternalTemperature")) return;
                MainWindowViewModel.CurrentMainWindowViewModel.IsDirty = true;
                _buildingViewModel.Update();
            }
        }

        public String InternalTemperature
        {
            get { return String.Format("{0:0.#}", _building.InternalTemperature); }
            set
            {
                if (!SetValue(ref _building.InternalTemperature, double.Parse(value), "InternalTemperature")) return;
                MainWindowViewModel.CurrentMainWindowViewModel.IsDirty = true;
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
