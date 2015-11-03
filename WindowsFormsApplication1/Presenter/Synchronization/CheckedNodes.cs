using Synchronization.Presenter.OpenDirectory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synchronization.Presenter.Synchronization
{
    public class CheckedNodes
    {
        public void CheckedFolder(TreeViewEventArgs e)
        {
            ExpandPlus exp = new ExpandPlus();
            exp.AfterExpand(e);
            TreeNode node = e.Node;
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode nod in node.Nodes)
                {
                    nod.Checked = true;
                }
            }
        }
        public List<String> CheckedFolder(TreeNodeCollection nodes)
        {
            List<String> result = new List<String>();
            foreach (TreeNode node in nodes)
            {
                if (node.Checked && node.Nodes.Count >= 0)
                {
                    result.Add(node.FullPath);
                    node.Checked = false;
                }
            }
            return result;
        }
        public List<String> CheckedFiles(TreeNodeCollection nodes)
        {
            List<String> result = new List<String>();
            if (nodes != null)
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Checked)
                    {
                        result.Add(Path.Combine(node.FullPath));
                    }
                    result.AddRange(CheckedFiles(node.Nodes));
                }
            }
            return result;
        }
    }
}