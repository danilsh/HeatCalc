using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;
using System.Globalization;

namespace HeatCalc.Presentation
{
    class MaterialViewModel : ListViewItemViewModel
    {
        private readonly Material _material;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public String Name
        {
            get { return _material.Name; }
        }

        public String ThermalConductivity
        {
            get { return String.Format("{0:0.####}", _material.ThermalConductivity); }
        }

        private readonly RelayCommand _deleteMaterial;
        public ICommand DeleteMaterial
        {
            get { return _deleteMaterial; }
        }

        private readonly RelayCommand _setMaterial;
        public ICommand SetMaterial
        {
            get { return _setMaterial; }
        }

        public MaterialViewModel(Material material, MainWindowViewModel mainWindowViewModel)
        {
            _material = material;
            _mainWindowViewModel = mainWindowViewModel;

            _deleteMaterial = new RelayCommand(param => _mainWindowViewModel.DeleteMaterial(material, this));
            _setMaterial = new RelayCommand(param => SetMaterialCommand());
        }

        public void Update()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("ThermalConductivity");
        }

        private void SetMaterialCommand()
        {
            if (_mainWindowViewModel.SelectedCladdingLayer == null) return;
            _mainWindowViewModel.SelectedCladdingLayer.ThermalConductivity = _material.ThermalConductivity.ToString();
            _mainWindowViewModel.SelectedCladdingLayer.Name = _material.Name;
        }
   }
}
