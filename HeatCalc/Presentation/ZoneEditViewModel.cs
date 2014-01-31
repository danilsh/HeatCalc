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
                var tmp = _zone.Name;
                if (!SetValue(ref tmp, value, "Name")) return;
                _zone.Name = tmp;
                _zoneViewModel.Update();
            }
        }

        public String Volume
        {
            get { return String.Format("{0:0.0}", _zone.Volume); }
            set
            {
                var tmp = _zone.Volume;
                if (!SetValue(ref tmp, double.Parse(value, CultureInfo.InvariantCulture), "Volume")) return;
                _zone.Volume = tmp;
                _zoneViewModel.Update();
            }
        }

        public String AirExchange
        {
            get { return String.Format("{0:0.0}", _zone.AirExchange); }
            set
            {
                var tmp = _zone.AirExchange;
                if (!SetValue(ref tmp, double.Parse(value, CultureInfo.InvariantCulture), "AirExchange")) return;
                _zone.AirExchange = tmp;
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
