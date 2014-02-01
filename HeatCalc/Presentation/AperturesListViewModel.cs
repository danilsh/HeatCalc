using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;
using System.Windows.Input;

namespace HeatCalc.Presentation
{
    class AperturesListViewModel : TreeViewItemViewModel
    {
        private readonly Cladding _cladding;
        private readonly CladdingViewModel _claddingViewModel;

        private readonly RelayCommand _newAperture;
        public ICommand NewAperture
        {
            get { return _newAperture; }
        }

        public AperturesListViewModel(Cladding cladding, CladdingViewModel claddingViewModel)
        {
            _cladding = cladding;
            _claddingViewModel = claddingViewModel;
            cladding.Apertures.ForEach(a => children.Add(new ApertureViewModel(a, this)));

            _newAperture = new RelayCommand(post => NewAppertureCommand());
        }

        public void Update()
        {
            _claddingViewModel.Update();
        }

        private void NewAppertureCommand()
        {
            var aperture = new Aperture
                {
                    HeatTransferCoefficient = 1.0,
                    Area = 1.0
                };
            _cladding.Apertures.Add(aperture);
            children.Add(new ApertureViewModel(aperture, this));
            _claddingViewModel.Update();
        }

        public void DeleteApertureCommand(Aperture aperture, ApertureViewModel apertureViewModel)
        {
            _cladding.Apertures.Remove(aperture);
            children.Remove(apertureViewModel);
            _claddingViewModel.Update();
        }
    }
}
