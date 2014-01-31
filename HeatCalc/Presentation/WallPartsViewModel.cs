using HeatCalc.HeatLoss;
using System.Windows.Input;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    class WallPartsListViewModel : TreeViewItemViewModel
    {
        private readonly Cladding _cladding;
        private readonly CladdingViewModel _claddingViewModel;

        private readonly RelayCommand _newWallPart;
        public ICommand NewWallPart
        {
            get { return _newWallPart; }
        }

        public WallPartsListViewModel(Cladding cladding, CladdingViewModel claddingViewModel)
        {
            _cladding = cladding;
            _claddingViewModel = claddingViewModel;

            _newWallPart = new RelayCommand(param => this.NewWallPartCommand());
        }

        private void NewWallPartCommand()
        {
            
        }

        public void Update()
        {
            _claddingViewModel.Update();
        }
    }
}
