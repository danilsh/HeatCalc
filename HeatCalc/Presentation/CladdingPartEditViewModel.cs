using System.Globalization;
using HeatCalc.MVVM.Common;
using HeatCalc.HeatLoss;
using System;

namespace HeatCalc.Presentation
{
    class CladdingPartEditViewModel : ObservableObject
    {
        private readonly CladdingPart _part;
        private readonly CladdingPartViewModel _partViewModel;

        public String Name
        {
            get { return _part.Name; }
            set
            {
                if (String.IsNullOrEmpty(value)) return;
                var tmp = _part.Name;
                if (!SetValue(ref tmp, value, "Name")) return;
                _part.Name = tmp;
                _partViewModel.Update();
            }
        }

        public String Area
        {
            get { return String.Format("{0:0.00}", _part.Area); }
            set
            {
                var tmp = _part.Area;
                if (!SetValue(ref tmp, double.Parse(value, CultureInfo.InvariantCulture), "Area")) return;
                _part.Area = tmp;
                _partViewModel.Update();
            }
        }

        public CladdingPartEditViewModel(CladdingPart part, CladdingPartViewModel partViewModel)
        {
            _part = part;
            _partViewModel = partViewModel;
        }
    }
}
