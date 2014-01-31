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
                var tmp = _layer.Name;
                if (!SetValue(ref tmp, value, "Name")) return;
                _layer.Name = tmp;
                _layerViewModel.Update();
            }
        }

        public String ThermalConductivity
        {
            get { return String.Format("{0:0.0000}", _layer.ThermalConductivity); }
            set
            {
                var tmp = _layer.ThermalConductivity;
                if (!SetValue(ref tmp, double.Parse(value, CultureInfo.InvariantCulture), "ThermalConductivity")) return;
                _layer.ThermalConductivity = tmp;
                _layerViewModel.Update();
            }
        }

        public String Thickness
        {
            get { return String.Format("{0:0.00}", _layer.Thickness); }
            set
            {
                var tmp = _layer.Thickness;
                if (!SetValue(ref tmp, double.Parse(value, CultureInfo.InvariantCulture), "Thickness")) return;
                _layer.Thickness = tmp;
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
