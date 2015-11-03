using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synchronization.Model;

namespace Synchronization.Presenter.Synchronization
{
    class InsertFile
    {
        public void InsertFileIfNotInDbPhone(string fileNameAndFolderComp, string pathComp, string pathComInPhon)
        {
            var context = new SynchronContext();
            var namePhone = fileNameAndFolderComp;
            var createPhone = File.GetCreationTime(pathComp);
            var modificPhone = File.GetLastWriteTime(pathComp);
            var phone = new PhoneModel
            {
                Name = namePhone,
                CreateDate = createPhone,
                ModificationDate = modificPhone
            };
            context.PhoneModels.Add(phone);
            try { File.Copy(pathComp, pathComInPhon); }
            catch { }
            context.SaveChanges();
        }
        public void InsertFileIfNotInDbComp(string fileNameAndFolderPhone, string pathPhone, string pathPhInCom)
        {
            var db = new SynchronContext();
            var nameComp = fileNameAndFolderPhone;
            var createComp = File.GetCreationTime(pathPhone);
            var modificComp = File.GetLastWriteTime(pathPhone);
            var comp = new ComputerModel
            {
                Name = nameComp,
                CreateDate = createComp,
                ModificationDate = modificComp
            };
            db.ComputerModels.Add(comp);
            try { File.Copy(pathPhone, pathPhInCom); }
            catch { }
            db.SaveChanges();
        }
        public void InsertInDbPhone(string pathPhone, string fileNameAndFolderPhone)
        {
            var db = new SynchronContext();
            var namePhone = fileNameAndFolderPhone;
            var createPhone = File.GetCreationTime(pathPhone);
            var modificPhone = File.GetLastWriteTime(pathPhone);
            var phone = new PhoneModel
            {
                Name = namePhone,
                CreateDate = createPhone,
                ModificationDate = modificPhone
            };
            db.PhoneModels.Add(phone);
            db.SaveChanges();
        }
        public void InsertInDbComp(string pathComp, string fileNameAndFolderComp)
        {
            var db = new SynchronContext();
            var nameComp = fileNameAndFolderComp;
            var createComp = File.GetCreationTime(pathComp);
            var modificComp = File.GetLastWriteTime(pathComp);
            var comp = new ComputerModel
            {
                Name = nameComp,
                CreateDate = createComp,
                ModificationDate = modificComp
            };
            db.ComputerModels.Add(comp);
            db.SaveChanges();
        }
    }
}