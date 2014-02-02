using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using HeatCalc.HeatLoss;
using HeatCalc.MVVM.Common;
using HeatCalc.IO;

namespace HeatCalc.Presentation
{
    class MainWindowViewModel : ObservableObject
    {
        private static MainWindowViewModel _currentMainWindowViewModel;
        public static MainWindowViewModel CurrentMainWindowViewModel
        {
            get { return _currentMainWindowViewModel; }
        }

        public IDialogService DialogService { get; set; }
        public IFileService FileService { get; set; }

        private readonly ObservableCollection<BuildingViewModel> _buildings = new ObservableCollection<BuildingViewModel>();
        public ObservableCollection<BuildingViewModel> Buildings
        {
            get { return _buildings; }
        }

        private readonly ObservableCollection<MaterialViewModel> _materials = new ObservableCollection<MaterialViewModel>();
        public ObservableCollection<MaterialViewModel> Materials
        {
            get { return _materials; }
        }

        private readonly Library _library = new Library();

        private CladdingLayerEditViewModel _selectedCladdingLayer = null;
        public CladdingLayerEditViewModel SelectedCladdingLayer
        {
            get { return _selectedCladdingLayer; }
            set { _selectedCladdingLayer = value; }
        }

        private String _title;
        public String Title
        {
            get { return _title; }
            set { SetValue(ref _title, value, "Title"); }
        }

        private Boolean _isDirty = false;
        public Boolean IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;
                SetValue(ref _title, GetTitleString(), "Title");
            }
        }

        private String _fileName = String.Empty;

        private readonly RelayCommand _save;
        public ICommand Save
        {
            get { return _save; }
        }

        private readonly RelayCommand _saveDlg;
        public ICommand SaveDlg
        {
            get { return _saveDlg; }
        }

        private readonly RelayCommand _loadDlg;
        public ICommand LoadDlg
        {
            get { return _loadDlg; }
        }

        public MainWindowViewModel()
        {
            _buildings.Add(new BuildingViewModel(new Building{ExternalTemperature = -26.0, InternalTemperature = 20}));


            _title = "Тепловые расчеты";

            _save = new RelayCommand(param => SaveCommand());
            _saveDlg = new RelayCommand(param => SaveDlgCommand());
            _loadDlg = new RelayCommand(param => LoadDlgCommand());

            _currentMainWindowViewModel = this;
        }

        public Boolean SaveCommand()
        {
            if(String.IsNullOrEmpty(_fileName)) return SaveDlgCommand();
            FileService.StoreBuilding(_buildings[0].Building, _fileName);
            _isDirty = false;
            return true;
        }

        private Boolean SaveDlgCommand()
        {
            if (DialogService == null) return true;
            if (!DialogService.SaveFileDialog(ref _fileName)) return false;

            FileService.StoreBuilding(_buildings[0].Building, _fileName);
            SetValue(ref _title, GetTitleString(), "Title");
            _isDirty = false;
            return true;
        }

        private String GetTitleString()
        {
            return "Тепловые расчеты - " + Path.GetFileNameWithoutExtension(_fileName) + (_isDirty ? "*" : "");
        }

        private void LoadDlgCommand()
        {
            if (DialogService == null) return;
            if (!CanClose()) return;
            var fileName = DialogService.OpenfileDialog();
            if (String.IsNullOrEmpty(fileName)) return;

            var building = FileService.GetBuilding(fileName);
            if (building == null) return;
            var buildingVm = new BuildingViewModel(building);
            _buildings.Clear();
            _buildings.Add(buildingVm);
            _fileName = fileName;
            _isDirty = false;
            SetValue(ref _title, GetTitleString(), "Title");
        }

        public void DeleteMaterial(Material material, MaterialViewModel materialViewModel)
        {
            if (DialogService == null) return;
            if (DialogService.YesNoDialog("Удаление", "Объект будет удалён безвозвратно. Вы уверены?") == DialogResult.No)
                return;
            _library.Materials.Remove(material);
            _materials.Remove(materialViewModel);
        }

        public void AddMaterial(Material material)
        {
            _library.Materials.Add(material);
            _materials.Add(new MaterialViewModel(material, this));
        }

        public Boolean CanClose()
        {
            if (!IsDirty) return true;
            if (DialogService == null) return true;
            switch (DialogService.YesNoCancelDialog("Предупреждение", "В проекте есть несохранённые данные. Сохранить?"))
            {
                case DialogResult.Cancel:
                    return false;
                case DialogResult.No:
                    return true;
                case DialogResult.Yes:
                    return SaveCommand();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
