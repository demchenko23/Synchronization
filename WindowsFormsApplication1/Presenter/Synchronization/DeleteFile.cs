using Synchronization.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;


namespace Synchronization.Presenter.Synchronization
{
    class DeleteFile
    {
        public void Delete(string pathComp, string pathCompInPhone, ComputerModel findFileFromComp,PhoneModel findFileFromPhone)
        {
            var context = new SynchronContext();
            var modific = File.GetLastWriteTime(pathComp);
            if (modific > findFileFromComp.ModificationDate)
            {
                findFileFromComp.ModificationDate = modific;
                File.Copy(pathComp, pathCompInPhone);
                findFileFromPhone.ModificationDate = modific;
            }
            else if (modific < findFileFromComp.ModificationDate)
            {
                var com = new ComputerModel { IdComp = findFileFromComp.IdComp, };
                context.Entry(com).State = System.Data.Entity.EntityState.Deleted;

                var phon = new PhoneModel { IdPhone = findFileFromPhone.IdPhone };
                context.Entry(phon).State = System.Data.Entity.EntityState.Deleted;

                File.Delete(pathComp);
            }
            context.SaveChanges();
        }
    }
}