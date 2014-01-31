using System.Windows.Controls;
using System.Windows;

namespace HeatCalc.Presentation
{
    class EditorTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BuildingTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is BuildingViewModel) return BuildingTemplate;

            return null;
        }
    }
}
