using System;
using System.Windows.Input;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    class WallLayerViewModel : TreeViewItemViewModel
    {
        private readonly WallLayer _wallLayer;
        private readonly WallPartViewModel _wallPartViewModel;
        private readonly WallLayerEditViewModel _wallLayerEditViewModel;

        public WallLayerEditViewModel EditorViewModel
        {
            get { return _wallLayerEditViewModel; }
        }

        public String ThermalConductivity
        {
            get { return String.Format("{0:0.####}", _wallLayer.ThermalConductivity); }
        }

        public String LayerThickness
        {
            get { return String.Format("{0:0.##}", _wallLayer.LayerThickness); }
        }

        public WallLayerViewModel(WallLayer wallLayer, WallPartViewModel wallPartViewModel)
        {
            _wallLayer = wallLayer;
            _wallPartViewModel = wallPartViewModel;
            _wallLayerEditViewModel = new WallLayerEditViewModel(wallLayer, this);
        }

        public void Update()
        {
            OnPropertyChanged("ThermalConductivity");
            OnPropertyChanged("LayerThickness");
            _wallPartViewModel.Update();
        }
    }
}
