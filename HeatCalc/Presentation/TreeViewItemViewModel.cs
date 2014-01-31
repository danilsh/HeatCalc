using System;
using System.Collections.ObjectModel;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    public class TreeViewItemViewModel : ListViewItemViewModel
    {
        protected ObservableCollection<TreeViewItemViewModel> children = new ObservableCollection<TreeViewItemViewModel>();
        public ObservableCollection<TreeViewItemViewModel> Children
        {
            get { return children; }
        }

        protected Boolean isExpanded = false;
        public virtual Boolean IsExpanded
        {
            get { return isExpanded; }
            set
            {
                SetValue(ref isExpanded, value, "IsExpanded");
            }
        }
    }
}
