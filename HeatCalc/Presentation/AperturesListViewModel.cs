﻿using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;
using System.Windows.Input;

namespace HeatCalc.Presentation
{
    class AperturesListViewModel : TreeViewItemViewModel
    {
        private readonly Cladding _cladding;
        private readonly CladdingViewModel _claddingViewModel;

        private readonly RelayCommand _newAperture;
        public ICommand NewAperture
        {
            get { return _newAperture; }
        }

        public AperturesListViewModel(Cladding cladding, CladdingViewModel claddingViewModel)
        {
            _cladding = cladding;
            _claddingViewModel = claddingViewModel;
            cladding.Apertures.ForEach(a => children.Add(new ApertureViewModel(a, this)));

            _newAperture = new RelayCommand(post => NewAppertureCommand());
        }

        public void Update()
        {
            _claddingViewModel.Update();
        }

        private void NewAppertureCommand()
        {
            var aperture = new Aperture
                {
                    HeatTransferCoefficient = 1.0,
                    Area = 1.0
                };
            _cladding.Apertures.Add(aperture);
            var tmp = new ApertureViewModel(aperture, this);
            children.Add(tmp);
            IsExpanded = true;
            tmp.IsSelected = true;
            _claddingViewModel.Update();
        }

        public void DeleteApertureCommand(Aperture aperture, ApertureViewModel apertureViewModel)
        {
            if (MainWindowViewModel.CurrentMainWindowViewModel.DialogService == null) return;
            if (MainWindowViewModel.CurrentMainWindowViewModel.DialogService.YesNoDialog("Удаление", "Объект будет удалён безвозвратно. Вы уверены?") == DialogResult.No)
                return;
            _cladding.Apertures.Remove(aperture);
            children.Remove(apertureViewModel);
            _claddingViewModel.Update();
        }
    }
}
