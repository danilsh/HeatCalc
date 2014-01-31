using System;
using System.Windows.Input;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    class CladdingLayerViewModel : TreeViewItemViewModel
    {
        private readonly CladdingLayer _layer;
        private readonly CladdingPartViewModel _partViewModel;
        private readonly CladdingLayerEditViewModel _layerEditViewModel;

        public CladdingLayerEditViewModel EditorViewModel
        {
            get { return _layerEditViewModel; }
        }

        public String Name
        {
            get { return _layer.Name; }
        }

        public String ThermalConductivity
        {
            get { return String.Format("{0:0.####}", _layer.ThermalConductivity); }
        }

        public String Thickness
        {
            get { return String.Format("{0:0.##}", _layer.Thickness); }
        }

        private readonly RelayCommand _deleteCladdingLayer;
        public ICommand DeleteCladdingLayer
        {
            get { return _deleteCladdingLayer; }
        }

        private readonly RelayCommand _addToLibrary;
        public ICommand AddToLibrary
        {
            get { return _addToLibrary; }
        }

        public override Boolean IsSelected
        {
            get { return isSelected; }
            set
            {
                if (SetValue(ref isSelected, value, "IsSelected"))
                {
                    MainWindowViewModel.CurrentMainWindowViewModel.SelectedCladdingLayer = isSelected ? this : null;
                }
            }
        }

        public CladdingLayerViewModel(CladdingLayer layer, CladdingPartViewModel partViewModel)
        {
            _layer = layer;
            _partViewModel = partViewModel;
            _layerEditViewModel = new CladdingLayerEditViewModel(layer, this);

            _deleteCladdingLayer = new RelayCommand(param => _partViewModel.DeleteCladdingLayerCommand(_layer, this));
            _addToLibrary = new RelayCommand(param => MainWindowViewModel.CurrentMainWindowViewModel.AddMaterial(new Material(layer.ThermalConductivity){Name = layer.Name}));
        }

        public void Update()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("ThermalConductivity");
            OnPropertyChanged("Thickness");
            _partViewModel.Update();
        }

        public void SetMaterial(Material material)
        {
            _layer.ThermalConductivity = material.ThermalConductivity;
            _layer.Name = material.Name;
            Update();
        }
    }
}
