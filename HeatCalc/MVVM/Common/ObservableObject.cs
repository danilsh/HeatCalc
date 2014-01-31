using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HeatCalc.MVVM.Common
{
    /// <summary>
    /// Наиболее оптимальная на 06.2012 ручная реализация INotifyPropertyChanged для целей MVVM
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual Boolean SetValue<T>(ref T target, T value, params String[] changedProperties)
        {
            if (EqualityComparer<T>.Default.Equals(target, value)) return false;

            target = value;
            if (changedProperties.Length > 0)
            {
                foreach (var str in changedProperties)
                {
                    OnPropertyChanged(str);
                }
            }
            else
                OnPropertyChanged(null);

            return true;
        }

        protected virtual void OnPropertyChanged(String propertyName)
        {
            // Приравниваем перед использованием для более надежной работы с несколькими потоками,
            // поскольку проверка и вызов - не одна атомарная операция
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
