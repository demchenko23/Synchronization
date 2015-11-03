using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synchronization.Model;


namespace Synchronization.Presenter.Synchronization
{
    public class SynchronAll
    {
        public void Synhronization(string textboxPhone, string textboxComp)
        {
            var context = new SynchronContext();
            var delete = new DeleteFile();
            var update = new UpdateFile();
            var insert = new InsertFile();
            var folder = new SynchronizationFolder();
            folder.SynchronFolder(textboxPhone, textboxComp);
            string[] filesPhone = Directory.GetFiles(textboxPhone, "*.*", SearchOption.AllDirectories);
            string[] filesComp = Directory.GetFiles(textboxComp, "*.*", SearchOption.AllDirectories);
            //для файлов с телефона
            foreach (var filePhon in filesPhone)
            {
                string fileNameAndFolderPhone = filePhon.Replace(textboxPhone, "");
                string pathPhInCom = textboxComp + fileNameAndFolderPhone;
                string pathComInPhon = textboxPhone + fileNameAndFolderPhone;
                string pathPhone = filePhon;
                var findFileFromPhone = context.PhoneModels.FirstOrDefault(file => file.Name == fileNameAndFolderPhone);
                var findPhoneFileFromComp = context.ComputerModels.FirstOrDefault(file => file.Name == fileNameAndFolderPhone);

                //если файла нет в бд телефона
                if (findFileFromPhone == null)
                {
                    insert.InsertInDbPhone(pathPhone, fileNameAndFolderPhone);
                }
                //если файла нет в папке компьютера
                if (Array.IndexOf(filesComp, pathPhInCom) == -1)
                {
                    //если файла нет в бд компьютера
                    if (findPhoneFileFromComp == null)
                    {
                        insert.InsertFileIfNotInDbComp(fileNameAndFolderPhone, pathPhone, pathPhInCom);
                    }
                    //файл есть в бд компьютера
                    else
                    {
                        delete.Delete(pathPhone, pathPhInCom, findPhoneFileFromComp, findFileFromPhone);
                    }
                }
                //файл есть в папке компьютера
                else
                {
                    //если файла нет в бд компьютера
                    if (findPhoneFileFromComp == null)
                    {
                        update.UpdateIfNotInDbComp(fileNameAndFolderPhone, pathPhone, pathPhInCom);
                    }
                    //файл есть в бд компьютера
                    else
                    {
                        update.UpdateIfInDbComp(fileNameAndFolderPhone, pathPhone, pathPhInCom,
                                            findPhoneFileFromComp, findFileFromPhone);
                    }
                }
            }
            //для файлов с компьютера
            foreach (var fileComp in filesComp)
            {
                string fileNameAndFolderComp = fileComp.Replace(textboxComp, "");
                string pathPhInCom = textboxComp + fileNameAndFolderComp;
                string pathComInPhon = textboxPhone + fileNameAndFolderComp;
                string pathComp = fileComp;
                var findFileFromPhone = context.PhoneModels.FirstOrDefault(file => file.Name == fileNameAndFolderComp);
                var findFileFromComp = context.ComputerModels.FirstOrDefault(file => file.Name == fileNameAndFolderComp);
                //если файла нет в бд компьютера
                if (findFileFromComp == null)
                {
                    insert.InsertInDbComp(pathComp, fileNameAndFolderComp);
                }
                //если файла нет в папке телефона
                if (Array.IndexOf(filesPhone, pathComInPhon) == -1)
                {
                    //если файла нет в бд телефона
                    if (findFileFromPhone == null)
                    {
                        insert.InsertFileIfNotInDbPhone(fileNameAndFolderComp, pathComp, pathComInPhon);
                    }
                    //если файл есть в бд телефона
                    else
                    {
                        delete.Delete(pathComp, pathComInPhon, findFileFromComp, findFileFromPhone);
                    }
                }
                //если файл есть в папке телефона
                else
                {
                    //если файла нет в бд телефона
                    if (findFileFromPhone == null)
                    {
                        update.UpdateIfNotInDbPhone(fileNameAndFolderComp, pathComp, pathComInPhon);
                    }
                    //если файл есть в бд телефона
                    else
                    {
                        update.UpdateIfInDbPhone(fileNameAndFolderComp, pathComp, pathComInPhon,
                                                findFileFromPhone, findFileFromComp);
                    }
                }
            }
        }
    }
}