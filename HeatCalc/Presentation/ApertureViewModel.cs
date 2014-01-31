using System;
using System.Windows.Input;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    class ApertureViewModel : TreeViewItemViewModel
    {
        private readonly Aperture _aperture;
        private readonly AperturesListViewModel _aperturesListViewModel;
        private readonly ApertureEditViewModel _apertureEditViewModel;

        public ApertureEditViewModel EditorViewModel
        {
            get { return _apertureEditViewModel; }
        }

        public String Name
        {
            get { return _aperture.Name; }
        }

        public String HeatTransferCoefficient
        {
            get { return String.Format("{0:0.####}", _aperture.HeatTransferCoefficient); }
        }

        public String Area
        {
            get { return String.Format("{0:0.##}", _aperture.Area); }
        }

        private readonly RelayCommand _deleteAperture;
        public ICommand DeleteAperture
        {
            get { return _deleteAperture; }
        }

        public ApertureViewModel(Aperture aperture, AperturesListViewModel aperturesListViewModel)
        {
            _aperture = aperture;
            _aperturesListViewModel = aperturesListViewModel;
            _apertureEditViewModel = new ApertureEditViewModel(aperture, this);

            _deleteAperture = new RelayCommand(param => _aperturesListViewModel.DeleteApertureCommand(_aperture, this));
        }

        public void Update()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("HeatTransferCoefficient");
            OnPropertyChanged("Area");
            _aperturesListViewModel.Update();
        }
    }
}
