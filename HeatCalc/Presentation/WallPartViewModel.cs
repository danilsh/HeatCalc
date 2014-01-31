using System;
using System.Windows.Input;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    class WallPartViewModel : TreeViewItemViewModel
    {
        private readonly WallPart _wallPart;
        private readonly WallPartsListViewModel _partsListViewModel;
        private readonly WallPartEditViewModel _wallPartEditViewModel;

        public WallPartEditViewModel EditorViewModel
        {
            get { return _wallPartEditViewModel; }
        }

        public String Area
        {
            get { return String.Format("{0:0.##}", _wallPart.Area); }
        }

        private readonly RelayCommand _newWallLayer;
        public ICommand NewWallLayer
        {
            get { return _newWallLayer; }
        }

        public WallPartViewModel(WallPart wallPart, WallPartsListViewModel wallPartsListViewModel)
        {
            _wallPart = wallPart;
            _partsListViewModel = wallPartsListViewModel;
            _wallPartEditViewModel = new WallPartEditViewModel(wallPart, this);
            wallPart.WallLayers.ForEach(wl => children.Add(new WallLayerViewModel(wl, this)));

            _newWallLayer = new RelayCommand(param => this.NewWallLayerCommand());
        }

        public void Update()
        {
            OnPropertyChanged("Area");
            _partsListViewModel.Update();
        }

        private void NewWallLayerCommand()
        {
            var wallLayer = new WallLayer(1.0, 1.0);
            _wallPart.WallLayers.Add(wallLayer);
            children.Add(new WallLayerViewModel(wallLayer, this));
            _partsListViewModel.Update();
        }
    }
}
