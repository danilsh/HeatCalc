using System;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;
using System.Windows.Input;

namespace HeatCalc.Presentation
{
    class ZoneViewModel : TreeViewItemViewModel
    {
        private readonly Zone _zone;
        private readonly BuildingViewModel _buildingViewModel;
        private readonly ZoneEditViewModel _zoneEditViewModel;

        public ZoneEditViewModel EditorViewModel
        {
            get { return _zoneEditViewModel; }
        }

        public String Name
        {
            get { return _zone.Name; }
        }

        public String Volume
        {
            get { return String.Format("{0:0.0}", _zone.Volume); }
        }

        public String AirExchange
        {
            get { return String.Format("{0:0.0}", _zone.AirExchange); }
        }

        private readonly RelayCommand _newCladding;
        public ICommand NewCladding
        {
            get { return _newCladding; }
        }

        private readonly RelayCommand _deleteZone;
        public ICommand DeleteZone
        {
            get { return _deleteZone; }
        }

        public ZoneViewModel(Zone zone, BuildingViewModel buildingViewModel)
        {
            _zone = zone;
            _buildingViewModel = buildingViewModel;
            _zoneEditViewModel = new ZoneEditViewModel(zone, this);
            zone.Claddings.ForEach(c => children.Add(new CladdingViewModel(c, this)));

            _newCladding = new RelayCommand(param => this.NewCladdingCommand());
            _deleteZone = new RelayCommand(param => _buildingViewModel.DeleteZoneCommand(_zone, this));
        }

        public void Update()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("Volume");
            OnPropertyChanged("AirExchange");
            _buildingViewModel.Update();
        }

        private void NewCladdingCommand()
        {
            var cladding = new Cladding();
            _zone.Claddings.Add(cladding);
            children.Add(new CladdingViewModel(cladding, this));
            _buildingViewModel.Update();
        }

        public void DeleteCladdingCommand(Cladding cladding, CladdingViewModel claddingViewModel)
        {
            _zone.Claddings.Remove(cladding);
            children.Remove(claddingViewModel);
            _buildingViewModel.Update();
        }
    }
}
