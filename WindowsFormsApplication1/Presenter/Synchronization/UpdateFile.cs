using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synchronization.Model;

namespace Synchronization.Presenter.Synchronization
{
    class UpdateFile
    {
        //если файл есть в папке телефона и есть в бд
        public void UpdateIfInDbPhone(string fileComp, string pathComp, string pathComInPhon,
                                        PhoneModel findFileFromPhone,
                                            ComputerModel findFileFromComp)
        {
            var context = new SynchronContext();
            var nameComp = fileComp;
            var createComp = File.GetCreationTime(pathComp);
            var modificComp = File.GetLastWriteTime(pathComp);
            var namePhone = fileComp;
            var createPhone = File.GetCreationTime(pathComInPhon);
            var modificPhone = File.GetLastWriteTime(pathComInPhon);
            if (modificComp > modificPhone)
            {
                File.Delete(pathComInPhon);
                File.Copy(pathComp, pathComInPhon);
                findFileFromPhone.ModificationDate = modificComp;
            }
            else if (modificPhone > modificComp)
            {
                File.Delete(pathComp);
                File.Copy(pathComInPhon, pathComp);

                findFileFromComp.ModificationDate = modificPhone;

            }
            context.SaveChanges();
        }
        //если файл есть в папке телефона, но нет в бд
        public void UpdateIfNotInDbPhone(string fileComp, string pathComp, string pathComInPhon)
        {
            var context = new SynchronContext();
            var nameComp = fileComp;
            var createComp = File.GetCreationTime(pathComp);
            var modificComp = File.GetLastWriteTime(pathComp);
            var namePhone = fileComp;
            var createPhone = File.GetCreationTime(pathComInPhon);
            var modificPhone = File.GetLastWriteTime(pathComInPhon);
            if (modificComp > modificPhone)
            {
                var phone = new PhoneModel
                {
                    Name = namePhone,
                    CreateDate = createPhone,
                    ModificationDate = modificComp
                };
                context.PhoneModels.Add(phone);
                File.Delete(pathComInPhon);
                File.Copy(pathComp, pathComInPhon);
            }
            else if (modificPhone > modificComp)
            {
                var phone = new PhoneModel
                {
                    Name = namePhone,
                    CreateDate = createPhone,
                    ModificationDate = modificPhone
                };
                context.PhoneModels.Add(phone);
            }
            context.SaveChanges();
        }
        //если файл есть в папке компьютера и есть в бд
        public void UpdateIfInDbComp(string filePhon, string pathPhone, string pathPhInCom,
                                     ComputerModel findFileFromComp,
                                        PhoneModel findFileFromPhone)
        {
            var context = new SynchronContext();
            var namePhone = filePhon;
            var createPhone = File.GetCreationTime(pathPhone);
            var modificPhone = File.GetLastWriteTime(pathPhone);
            var nameComp = filePhon;
            var createComp = File.GetCreationTime(pathPhInCom);
            var modificComp = File.GetLastWriteTime(pathPhInCom);
            if (modificPhone > modificComp)
            {
                File.Delete(pathPhInCom);
                File.Copy(pathPhone, pathPhInCom);
                findFileFromComp.ModificationDate = modificPhone;

            }
            else if (modificComp > modificPhone)
            {
                File.Delete(pathPhone);
                File.Copy(pathPhInCom, pathPhone);
                findFileFromPhone.ModificationDate = modificComp;
            }
            context.SaveChanges();
        }
        //если файл есть в папке компьютера, но нет в бд
        public void UpdateIfNotInDbComp(string filePhon, string pathPhone, string pathPhInCom)
        {
            var context = new SynchronContext();
            var namePhone = filePhon;
            var createPhone = File.GetCreationTime(pathPhone);
            var modificPhone = File.GetLastWriteTime(pathPhone);
            var nameComp = filePhon;
            var createComp = File.GetCreationTime(pathPhInCom);
            var modificComp = File.GetLastWriteTime(pathPhInCom);
            if (modificPhone > modificComp)
            {
                var comp = new ComputerModel
                {
                    Name = nameComp,
                    CreateDate = createComp,
                    ModificationDate = modificPhone
                };
                context.ComputerModels.Add(comp);
                File.Delete(pathPhInCom);
                File.Copy(pathPhone, pathPhInCom);
            }
            else if (modificComp > modificPhone)
            {
                var comp = new ComputerModel
                {
                    Name = nameComp,
                    CreateDate = createComp,
                    ModificationDate = modificComp
                };
                context.ComputerModels.Add(comp);
            }
            context.SaveChanges();
        }
    }
}