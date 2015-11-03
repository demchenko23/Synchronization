using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synchronization.Presenter.OpenDirectory
{
    public class Open
    {
        public string OpenDirectory(TextBox textBox)
        {
            string path = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
                textBox.Text = path;
                return path;
            }
            return path;
        }
    }
}