using HeatCalc.HeatLoss;
using System.Windows.Input;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    class CladdingPartsListViewModel : TreeViewItemViewModel
    {
        private readonly Cladding _cladding;
        private readonly CladdingViewModel _claddingViewModel;

        private readonly RelayCommand _newCladdingPart;
        public ICommand NewCladdingPart
        {
            get { return _newCladdingPart; }
        }

        public CladdingPartsListViewModel(Cladding cladding, CladdingViewModel claddingViewModel)
        {
            _cladding = cladding;
            _claddingViewModel = claddingViewModel;
            cladding.Parts.ForEach(wp => children.Add(new CladdingPartViewModel(wp, this)));

            _newCladdingPart = new RelayCommand(param => this.NewCladdingPartCommand());
        }

        public void Update()
        {
            _claddingViewModel.Update();
        }

        private void NewCladdingPartCommand()
        {
            var wallPart = new CladdingPart(1.0);
            _cladding.Parts.Add(wallPart);
            children.Add(new CladdingPartViewModel(wallPart, this));
            _claddingViewModel.Update();
        }

        public void DeleteCladdingPartCommand(CladdingPart part, CladdingPartViewModel partViewModel)
        {
            _cladding.Parts.Remove(part);
            children.Remove(partViewModel);
            _claddingViewModel.Update();
        }
    }
}
