﻿using System;
using System.Windows.Input;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    class CladdingPartViewModel : TreeViewItemViewModel
    {
        private readonly CladdingPart _part;
        private readonly CladdingPartsListViewModel _partsListViewModel;
        private readonly CladdingPartEditViewModel _partEditViewModel;

        public CladdingPartEditViewModel EditorViewModel
        {
            get { return _partEditViewModel; }
        }

        public String Name
        {
            get { return _part.Name; }
        }

        public String Area
        {
            get { return String.Format("{0:0.##}", _part.Area); }
        }

        private readonly RelayCommand _newCladdingLayer;
        public ICommand NewCladdingLayer
        {
            get { return _newCladdingLayer; }
        }

        private readonly RelayCommand _deleteCladdingPart;
        public ICommand DeleteCladdingPart
        {
            get { return _deleteCladdingPart; }
        }

        public CladdingPartViewModel(CladdingPart part, CladdingPartsListViewModel partsListViewModel)
        {
            _part = part;
            _partsListViewModel = partsListViewModel;
            _partEditViewModel = new CladdingPartEditViewModel(part, this);
            part.Layers.ForEach(wl => children.Add(new CladdingLayerViewModel(wl, this)));

            _newCladdingLayer = new RelayCommand(param => this.NewCladdingLayerCommand());
            _deleteCladdingPart = new RelayCommand(param => _partsListViewModel.DeleteCladdingPartCommand(_part, this));
        }

        public void Update()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("Area");
            _partsListViewModel.Update();
        }

        private void NewCladdingLayerCommand()
        {
            var layer = new CladdingLayer(1.0, 1.0);
            _part.Layers.Add(layer);
            children.Add(new CladdingLayerViewModel(layer, this));
            _partsListViewModel.Update();
        }

        public void DeleteCladdingLayerCommand(CladdingLayer layer, CladdingLayerViewModel layerViewModel)
        {
            _part.Layers.Remove(layer);
            children.Remove(layerViewModel);
            _partsListViewModel.Update();
        }
    }
}
