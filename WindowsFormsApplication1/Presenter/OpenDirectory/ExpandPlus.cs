using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synchronization.Presenter.OpenDirectory
{
    public class ExpandPlus
    {
        public void AfterExpand(TreeViewEventArgs e)
        {
            TreeNode item = e.Node as TreeNode;
            Nodes n = new Nodes();
            if ((item.Nodes.Count == 1) && (item.FirstNode.Text == "Loading..."))
            {
                item.Nodes.Clear();
                DirectoryInfo expandedDir = null;
                if (item.Tag is DriveInfo)
                    expandedDir = (item.Tag as DriveInfo).RootDirectory;
                if (item.Tag is DirectoryInfo)
                    expandedDir = (item.Tag as DirectoryInfo);
                try
                {
                    foreach (DirectoryInfo subDir in expandedDir.GetDirectories())
                        item.Nodes.Add(n.CreateTreeItem(subDir));
                    foreach (FileInfo file in expandedDir.GetFiles())
                        item.Nodes.Add(file.Name);
                }
                catch { }
            }
        }
    }
}