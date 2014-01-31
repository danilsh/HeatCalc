using System.Globalization;
using HeatCalc.MVVM.Common;
using HeatCalc.HeatLoss;
using System;

namespace HeatCalc.Presentation
{
    class WallPartEditViewModel : ObservableObject
    {
        private readonly WallPart _wallPart;
        private readonly WallPartViewModel _wallPartViewModel;

        public String Area
        {
            get { return String.Format("{0:0.00}", _wallPart.Area); }
            set
            {
                var tmp = _wallPart.Area;
                if (SetValue(ref tmp, double.Parse(value, CultureInfo.InvariantCulture), "Area"))
                {
                    _wallPart.Area = tmp;
                    _wallPartViewModel.Update();
                }
            }
        }

        public WallPartEditViewModel(WallPart wallPart, WallPartViewModel wallPartViewModel)
        {
            _wallPart = wallPart;
            _wallPartViewModel = wallPartViewModel;
        }
    }
}
