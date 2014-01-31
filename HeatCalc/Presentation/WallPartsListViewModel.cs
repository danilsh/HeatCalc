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
            cladding.WallParts.ForEach(wp => children.Add(new WallPartViewModel(wp, this)));

            _newWallPart = new RelayCommand(param => this.NewWallPartCommand());
        }

        private void NewWallPartCommand()
        {
            var wallPart = new WallPart(1.0);
            _cladding.WallParts.Add(wallPart);
            children.Add(new WallPartViewModel(wallPart, this));
            _claddingViewModel.Update();
        }

        public void Update()
        {
            _claddingViewModel.Update();
        }
    }
}
