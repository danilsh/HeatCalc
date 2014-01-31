using System;
using System.Globalization;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    class WallLayerEditViewModel : ObservableObject
    {
        private readonly WallLayer _wallLayer;
        private readonly WallLayerViewModel _wallLayerViewModel;

        public String ThermalConductivity
        {
            get { return String.Format("{0:0.0000}", _wallLayer.ThermalConductivity); }
            set
            {
                var tmp = _wallLayer.ThermalConductivity;
                if (SetValue(ref tmp, double.Parse(value, CultureInfo.InvariantCulture), "ThermalConductivity"))
                {
                    _wallLayer.ThermalConductivity = tmp;
                    _wallLayerViewModel.Update();
                }
            }
        }

        public String LayerThickness
        {
            get { return String.Format("{0:0.00}", _wallLayer.LayerThickness); }
            set
            {
                var tmp = _wallLayer.LayerThickness;
                if (SetValue(ref tmp, double.Parse(value, CultureInfo.InvariantCulture), "LayerThickness"))
                {
                    _wallLayer.LayerThickness = tmp;
                    _wallLayerViewModel.Update();
                }
            }
        }

        public WallLayerEditViewModel(WallLayer wallLayer, WallLayerViewModel wallLayerViewModel)
        {
            _wallLayer = wallLayer;
            _wallLayerViewModel = wallLayerViewModel;
        }
    }
}
