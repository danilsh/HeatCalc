using System;
using HeatCalc.MVVM.Common;

namespace HeatCalc.Presentation
{
    public class ListViewItemViewModel : ObservableObject
    {
        protected Boolean isSelected = false;
        public virtual Boolean IsSelected
        {
            get { return isSelected; }
            set
            {
                SetValue(ref isSelected, value, "IsSelected");
            }
        }
    }
}
