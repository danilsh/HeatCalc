using System;

namespace HeatCalc.Presentation
{
    interface IDialogService
    {
        String OpenfileDialog();
        Boolean SaveFileDialog(ref String fileName);
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
    }
}
