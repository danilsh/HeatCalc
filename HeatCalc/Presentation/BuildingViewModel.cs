﻿using System;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;
using System.Windows.Input;

namespace HeatCalc.Presentation
{
    class BuildingViewModel : TreeViewItemViewModel
    {
        private readonly Building _building;
        public Building Building
        {
            get { return _building; }
        }

        private readonly BuildingEditViewModel _buildingEditViewModel;
        public BuildingEditViewModel EditorViewModel
        {
            get { return _buildingEditViewModel; }
        }

        public String Name
        {
            get { return _building.Name; }
        }

        public String ExternalTemperature
        {
            get { return String.Format("{0:0.#}", _building.ExternalTemperature); }
        }

        public String InternalTemperature
        {
            get { return String.Format("{0:0.#}", _building.InternalTemperature); }
        }

        public String HeatLoss
        {
            get { return String.Format("{0:0.0}", _building.HeatLoss); }
        }

        private readonly RelayCommand _newZone;
        public ICommand NewZone
        {
            get { return _newZone; }
        }

        public BuildingViewModel(Building building)
        {
            _building = building;
            _buildingEditViewModel = new BuildingEditViewModel(building, this);
            building.Zones.ForEach(z => children.Add(new ZoneViewModel(z, this)));

            _newZone = new RelayCommand(param => this.NewZoneCommand());
        }

        public void Update()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("ExternalTemperature");
            OnPropertyChanged("InternalTemperature");
            OnPropertyChanged("HeatLoss");
        }

        private void NewZoneCommand()
        {
            var zone = new Zone
                {
                    Building = _building,
                    AirExchange = 1.0,
                    Volume = 1.0
                };
            _building.Zones.Add(zone);
            var tmp = new ZoneViewModel(zone, this);
            children.Add(tmp);
            IsExpanded = true;
            tmp.IsSelected = true;
            OnPropertyChanged("HeatLoss");
        }

        public void DeleteZoneCommand(Zone zone, ZoneViewModel zoneViewModel)
        {
            if (MainWindowViewModel.CurrentMainWindowViewModel.DialogService == null) return;
            if (MainWindowViewModel.CurrentMainWindowViewModel.DialogService.YesNoDialog("Удаление", "Объект будет удалён безвозвратно. Вы уверены?") == DialogResult.No)
                return;
            _building.Zones.Remove(zone);
            children.Remove(zoneViewModel);
            OnPropertyChanged("HeatLoss");
        }
    }
}
