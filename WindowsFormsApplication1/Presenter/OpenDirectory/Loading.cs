using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synchronization.Presenter.OpenDirectory
{
    public class Loading
    {
        public void LazyLoading(TreeView treeView, string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo[] diArray = directory.GetDirectories();
            Nodes tn = new Nodes();
            foreach (DirectoryInfo direct in diArray)
            {
                treeView.Nodes.Add(tn.CreateTreeItem(direct));
            }
            FileInfo[] fileInDir;
            try { fileInDir = directory.GetFiles(); }
            catch { return; }
            foreach (FileInfo file in fileInDir)
            {
                TreeNode item = new TreeNode(file.Name);
                treeView.Nodes.Add(item);
            }
        }
    }
}