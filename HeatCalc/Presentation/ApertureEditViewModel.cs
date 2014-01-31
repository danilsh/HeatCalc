using System;
using HeatCalc.MVVM.Common;
using HeatCalc.HeatLoss;
using System.Globalization;

namespace HeatCalc.Presentation
{
    class ApertureEditViewModel : ObservableObject
    {
        private readonly Aperture _aperture;
        private readonly ApertureViewModel _apertureViewModel;

        public String Name
        {
            get { return _aperture.Name; }
            set
            {
                if (String.IsNullOrEmpty(value)) return;
                var tmp = _aperture.Name;
                if (!SetValue(ref tmp, value, "Name")) return;
                _aperture.Name = tmp;
                _apertureViewModel.Update();
            }
        }

        public String HeatTransferCoefficient
        {
            get { return String.Format("{0:0.0000}", _aperture.HeatTransferCoefficient); }
            set
            {
                var tmp = _aperture.HeatTransferCoefficient;
                if (!SetValue(ref tmp, double.Parse(value, CultureInfo.InvariantCulture), "HeatTransferCoefficient")) return;
                _aperture.HeatTransferCoefficient = tmp;
                _apertureViewModel.Update();
            }
        }

        public String Area
        {
            get { return String.Format("{0:0.00}", _aperture.Area); }
            set
            {
                var tmp = _aperture.Area;
                if (!SetValue(ref tmp, double.Parse(value, CultureInfo.InvariantCulture), "Area")) return;
                _aperture.Area = tmp;
                _apertureViewModel.Update();
            }
        }

        public ApertureEditViewModel(Aperture aperture, ApertureViewModel apertureViewModel)
        {
            _aperture = aperture;
            _apertureViewModel = apertureViewModel;
        }
    }
}
