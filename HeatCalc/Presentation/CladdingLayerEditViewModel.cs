using System;
using System.Globalization;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    class CladdingLayerEditViewModel : ObservableObject
    {
        private readonly CladdingLayer _layer;
        private readonly CladdingLayerViewModel _layerViewModel;

        public String Name
        {
            get { return _layer.Name; }
            set
            {
                if (String.IsNullOrEmpty(value)) return;
                if (!SetValue(ref _layer.Name, value, "Name")) return;
                _layerViewModel.Update();
            }
        }

        public String ThermalConductivity
        {
            get { return String.Format("{0:0.0000}", _layer.ThermalConductivity); }
            set
            {
                if (!SetValue(ref _layer.ThermalConductivity, double.Parse(value), "ThermalConductivity")) return;
                _layerViewModel.Update();
            }
        }

        public String Thickness
        {
            get { return String.Format("{0:0.00}", _layer.Thickness); }
            set
            {
                if (!SetValue(ref _layer.Thickness, double.Parse(value), "Thickness")) return;
                _layerViewModel.Update();
            }
        }

        public CladdingLayerEditViewModel(CladdingLayer layer, CladdingLayerViewModel layerViewModel)
        {
            _layer = layer;
            _layerViewModel = layerViewModel;
        }
    }
}
