using System;
using System.Windows.Input;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    class CladdingViewModel : TreeViewItemViewModel
    {
        private readonly Cladding _cladding;
        private readonly ZoneViewModel _zoneViewModel;

        private readonly CladdingEditViewModel _claddingEditViewModel;
        public CladdingEditViewModel EditorViewModel
        {
            get { return _claddingEditViewModel; }
        }

        public String Name
        {
            get { return _cladding.Name; }
        }

        private readonly RelayCommand _deleteCladding;
        public ICommand DeleteCladding
        {
            get { return _deleteCladding; }
        }

        public CladdingViewModel(Cladding cladding, ZoneViewModel zoneViewModel)
        {
            _cladding = cladding;
            _zoneViewModel = zoneViewModel;
            _claddingEditViewModel = new CladdingEditViewModel(cladding, this);

            children.Add(new AperturesListViewModel(_cladding, this));
            children.Add(new CladdingPartsListViewModel(_cladding, this));

            _deleteCladding = new RelayCommand(param => _zoneViewModel.DeleteCladdingCommand(_cladding, this));
        }

        public void Update()
        {
            OnPropertyChanged("Name");
            _zoneViewModel.Update();
        }
    }
}
