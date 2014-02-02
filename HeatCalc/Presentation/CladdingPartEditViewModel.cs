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
                if (!SetValue(ref _part.Name, value, "Name")) return;
                MainWindowViewModel.CurrentMainWindowViewModel.IsDirty = true;
                _partViewModel.Update();
            }
        }

        public String Area
        {
            get { return String.Format("{0:0.00}", _part.Area); }
            set
            {
                if (!SetValue(ref _part.Area, double.Parse(value), "Area")) return;
                MainWindowViewModel.CurrentMainWindowViewModel.IsDirty = true;
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
