using Synchronization;
using Synchronization.Presenter;
using Synchronization.Presenter.OpenDirectory;
using Synchronization.Presenter.Synchronization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synchronization
{
    public partial class SynchronizationView : Form
    {
        public SynchronizationPresenter Presenter { get; set; }
        public SynchronizationView()
        {
            InitializeComponent();
        }
        private void button_OpenComputer_Click(object sender, EventArgs e)
        {
            Presenter.OnOpenComputerClick(tboxComputerPath, treeViewComputer);
        }
        private void button_OpenPhone_Click(object sender, EventArgs e)
        {
            Presenter.OnOpenPhoneClick(tboxPhonePath, treeViewPhone);
        }
        private void treeViewPhone_AfterExpand(object sender, TreeViewEventArgs e)
        {
            Presenter.OnAfterExpand(e);
        }
        private void treeViewComputer_AfterExpand(object sender, TreeViewEventArgs e)
        {
            Presenter.OnAfterExpand(e);
        }
        private void treeViewPhone_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Presenter.OnAfterCheck(e);
        }
        private void treeViewComputer_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Presenter.OnAfterCheck(e);
        }       
        private void button_Synchronization_Click(object sender, EventArgs e)
        {
            if (radioBtn_All.Checked)
            {
                Presenter.OnSynchronizationClick_All(tboxPhonePath, tboxComputerPath, treeViewPhone, treeViewComputer);
                MessageBox.Show("Ok");
            }
            else if (radioBtn_PC.Checked)
            {
                Presenter.OnSynchronizationClick_PC(tboxPhonePath, tboxComputerPath, treeViewPhone, treeViewComputer);
                MessageBox.Show("Ok");
            }
            else if (radioBtn_CP.Checked)
            {
                Presenter.OnSynchronizationClick_CP(tboxPhonePath, tboxComputerPath, treeViewPhone, treeViewComputer);
                MessageBox.Show("Ok");
            }
            else
            {
                MessageBox.Show("Select synchronization.");
            }
        }        
    }
}
