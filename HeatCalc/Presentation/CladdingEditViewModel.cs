using System;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    class CladdingEditViewModel : ObservableObject
    {
        private readonly Cladding _cladding;
        private readonly CladdingViewModel _claddingViewModel;

        public String Name
        {
            get { return _cladding.Name; }
            set
            {
                if (String.IsNullOrEmpty(value)) return;
                var tmp = _cladding.Name;
                if (!SetValue(ref tmp, value, "Name")) return;
                _cladding.Name = tmp;
                _claddingViewModel.Update();
            }
        }

        public CladdingEditViewModel(Cladding cladding, CladdingViewModel claddingViewModel)
        {
            _cladding = cladding;
            _claddingViewModel = claddingViewModel;
        }
    }
}
