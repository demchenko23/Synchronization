using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Synchronization.Presenter.OpenDirectory
{
    class Nodes
    {
        public TreeNode CreateTreeItem(object direct)
        {
            TreeNode item = new TreeNode();
            item.Text = direct.ToString();
            item.Tag = direct;
            item.Nodes.Add("Loading...");
            return item;
        }
    }
}