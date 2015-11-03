using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synchronization.Model;
using Synchronization;
using Synchronization.Presenter.OpenDirectory;
using System.Windows.Forms;
using Synchronization.Presenter.Synchronization;

namespace Synchronization.Presenter
{
    public class SynchronizationPresenter
    {
        private SynchronContext _context;
        private SynchronizationView _view;
        public SynchronizationPresenter(SynchronContext context, SynchronizationView view)
        {
            this._context = context;
            this._view = view;
            view.Presenter = this;
        }
        public void OnOpenComputerClick(TextBox tboxComputerPath, TreeView treeViewComputer)
        {
            treeViewComputer.Nodes.Clear();
            Open od = new Open();
            Loading load = new Loading();
            string path = od.OpenDirectory(tboxComputerPath);
            load.LazyLoading(treeViewComputer, path);
        }
        public void OnOpenPhoneClick(TextBox tboxPhonePath, TreeView treeViewPhone)
        {
            treeViewPhone.Nodes.Clear();
            Open od = new Open();
            Loading load = new Loading();
            string path = od.OpenDirectory(tboxPhonePath);
            load.LazyLoading(treeViewPhone, path);
        }
        public void OnAfterExpand(TreeViewEventArgs e)
        {
            ExpandPlus exp = new ExpandPlus();
            exp.AfterExpand(e);
        }
        public void OnAfterCheck(TreeViewEventArgs e)
        {
            CheckedNodes chek = new CheckedNodes();
            chek.CheckedFolder(e);
        }
        public void OnSynchronizationClick_All(TextBox tboxPhonePath, TextBox tboxComputerPath,TreeView treeViewPhone, TreeView treeViewComputer)
        {
            SynchronAll synAll = new SynchronAll();
            synAll.Synhronization(tboxPhonePath.Text, tboxComputerPath.Text);
            treeViewPhone.EndUpdate();
            treeViewComputer.EndUpdate();
        }
        public void OnSynchronizationClick_PC(TextBox tboxPhonePath, TextBox tboxComputerPath, TreeView treeViewPhone, TreeView treeViewComputer)
        {
            CheckedNodes check = new CheckedNodes();
            FromPhoneToComp synPhonComp = new FromPhoneToComp();
            SynchronizationFolder synFolder = new SynchronizationFolder();
            synFolder.SynchronFolder(check.CheckedFolder(treeViewPhone.Nodes), tboxComputerPath.Text);
            synPhonComp.Synchronization(check.CheckedFiles(treeViewPhone.Nodes), tboxPhonePath.Text, tboxComputerPath.Text);
            treeViewPhone.EndUpdate();
            treeViewComputer.EndUpdate();
        }
        public void OnSynchronizationClick_CP(TextBox tboxPhonePath, TextBox tboxComputerPath, TreeView treeViewPhone, TreeView treeViewComputer)
        {
            CheckedNodes check = new CheckedNodes();
            FromCompToPhone synComPhon = new FromCompToPhone();
            SynchronizationFolder synFolder = new SynchronizationFolder();
            synFolder.SynchronFolder(check.CheckedFolder(treeViewComputer.Nodes), tboxPhonePath.Text);
            synComPhon.Synchronization(check.CheckedFiles(treeViewComputer.Nodes), tboxPhonePath.Text, tboxComputerPath.Text);
            treeViewPhone.EndUpdate();
            treeViewComputer.EndUpdate();
        }
    }
}
