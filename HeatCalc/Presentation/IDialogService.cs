using System;
using System.Windows;

namespace HeatCalc.Presentation
{
    enum DialogResult
    {
        Cancel,
        Ok,
        Yes,
        No
    }

    interface IDialogService
    {
        String OpenfileDialog();
        Boolean SaveFileDialog(ref String fileName);
        DialogResult YesNoDialog(String caption, String message);
        DialogResult YesNoCancelDialog(String caption, String message);
    }

    class DialogService : IDialogService
    {
        public String OpenfileDialog()
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
                {
                    CheckFileExists = true,
                    DefaultExt = ".xls",
                    Filter = "XML файлы (*.xml)|*.xml",
                };
            return (Boolean)dlg.ShowDialog() ? dlg.FileName : null;
        }

        public Boolean SaveFileDialog(ref String fileName)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog
                {
                    DefaultExt = ".xls",
                    Filter = "XML файлы (*.xml)|*.xml",
                    FileName = fileName
                };
            var ret = (Boolean) dlg.ShowDialog();
            if (ret) fileName = dlg.FileName;
            return ret;
        }

        public DialogResult YesNoDialog(String caption,String message)
        {
            var res = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (res)
            {
                case MessageBoxResult.Yes:
                    return DialogResult.Yes;
                case MessageBoxResult.No:
                    return DialogResult.No;
                default:
                    throw new InvalidOperationException();
            }
        }

        public DialogResult YesNoCancelDialog(String caption, String message)
        {
            var res = MessageBox.Show(message, caption, MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            switch (res)
            {
                case MessageBoxResult.Yes:
                    return DialogResult.Yes;
                case MessageBoxResult.No:
                    return DialogResult.No;
                case MessageBoxResult.Cancel:
                    return DialogResult.Cancel;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
