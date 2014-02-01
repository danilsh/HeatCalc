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
                if (!SetValue(ref _aperture.Name, value, "Name")) return;
                _apertureViewModel.Update();
            }
        }

        public String HeatTransferCoefficient
        {
            get { return String.Format("{0:0.0000}", _aperture.HeatTransferCoefficient); }
            set
            {
                if (!SetValue(ref _aperture.HeatTransferCoefficient, double.Parse(value), "HeatTransferCoefficient")) return;
                _apertureViewModel.Update();
            }
        }

        public String Area
        {
            get { return String.Format("{0:0.00}", _aperture.Area); }
            set
            {
                if (!SetValue(ref _aperture.Area, double.Parse(value), "Area")) return;
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
