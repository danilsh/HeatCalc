using System;
using System.ComponentModel;
using System.Windows;
using HeatCalc.Presentation;

namespace HeatCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = !MainWindowViewModel.CurrentMainWindowViewModel.CanClose();
        }
    }
}
