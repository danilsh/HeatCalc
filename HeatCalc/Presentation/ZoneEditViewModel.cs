using System;
using System.Globalization;
using HeatCalc.MVVM.Common;
using HeatCalc.HeatLoss;

namespace HeatCalc.Presentation
{
    class ZoneEditViewModel : ObservableObject
    {
        private readonly Zone _zone;
        private readonly ZoneViewModel _zoneViewModel;

        public String Name
        {
            get { return _zone.Name; }
            set
            {
                if (String.IsNullOrEmpty(value)) return;
                if (!SetValue(ref _zone.Name, value, "Name")) return;
                MainWindowViewModel.CurrentMainWindowViewModel.IsDirty = true;
                _zoneViewModel.Update();
            }
        }

        public String Volume
        {
            get { return String.Format("{0:0.0}", _zone.Volume); }
            set
            {
                if (!SetValue(ref _zone.Volume, double.Parse(value), "Volume")) return;
                MainWindowViewModel.CurrentMainWindowViewModel.IsDirty = true;
                _zoneViewModel.Update();
            }
        }

        public String AirExchange
        {
            get { return String.Format("{0:0.0}", _zone.AirExchange); }
            set
            {
                if (!SetValue(ref _zone.AirExchange, double.Parse(value), "AirExchange")) return;
                MainWindowViewModel.CurrentMainWindowViewModel.IsDirty = true;
                _zoneViewModel.Update();
            }
        }

        public ZoneEditViewModel(Zone zone, ZoneViewModel zoneViewModel)
        {
            _zone = zone;
            _zoneViewModel = zoneViewModel;
        }
    }
}
