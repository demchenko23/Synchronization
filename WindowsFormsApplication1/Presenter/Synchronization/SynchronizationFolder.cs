using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synchronization.Presenter.Synchronization
{
    public class SynchronizationFolder
    {
        public DirectoryInfo[] ReturnAllFolders(string textBoxPath)
        {
            DirectoryInfo directory = new DirectoryInfo(textBoxPath);
            DirectoryInfo[] diArray = directory.GetDirectories();
            return diArray;
        }
        public void SynchronFolder(string textBoxPhone, string textBoxComputer)
        {
            DirectoryInfo[] directoryPhone = ReturnAllFolders(textBoxPhone);
            DirectoryInfo[] directoryComputer = ReturnAllFolders(textBoxComputer);
            foreach (var folder in directoryPhone)
            {
                string folderPathInComp = textBoxComputer + "\\" + folder.Name;
                if (!Directory.Exists(folderPathInComp))
                {
                    Directory.CreateDirectory(folderPathInComp);
                }
            }
            foreach (var folder in directoryComputer)
            {
                string folderPathInPhone = textBoxPhone + "\\" + folder.Name;
                if (!Directory.Exists(folderPathInPhone))
                {
                    Directory.CreateDirectory(folderPathInPhone);
                }
            }
        }
        public void SynchronFolder(List<String> nodes, string textBoxTo)
        {
            foreach (var node in nodes)
            {
                string folderPathTo = textBoxTo + "\\" + node;
                if (!Directory.Exists(folderPathTo))
                {
                    Directory.CreateDirectory(folderPathTo);
                }
            }
        }
    }
}