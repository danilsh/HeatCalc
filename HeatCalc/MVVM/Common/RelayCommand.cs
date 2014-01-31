using System;
using System.Windows.Input;
using System.Diagnostics;

namespace HeatCalc.MVVM.Common
{
    /// <summary>
    /// Реализация команды для MVVM по статье MSDN "WPF Apps With The Model-View-ViewModel Design Pattern" by Josh Smith, 2009
    /// </summary>
    public class RelayCommand : ICommand
    {
        readonly Action<Object> _execute;
        readonly Predicate<Object> _canExecute;

        public RelayCommand(Action<Object> execute) : this(execute, null) { }

        public RelayCommand(Action<Object> execute, Predicate<Object> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute");

            this._execute = execute;
            this._canExecute = canExecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
