using Synchronization.Model;
using Synchronization.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synchronization
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SynchronContext context = new SynchronContext();
            SynchronizationView view = new SynchronizationView();
            SynchronizationPresenter presenter = new SynchronizationPresenter(context, view);
            Application.Run(view);
        }
    }
}
