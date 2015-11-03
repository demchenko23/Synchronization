using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Synchronization;
using Synchronization.Model;
namespace Synchronization.Presenter.Synchronization
{
    public class FromCompToPhone
    {
        public void Synchronization(List<String> chekedNames, string textboxPhone, string textboxComp)
        {
            var context = new SynchronContext();
            var delete = new DeleteFile();
            var update = new UpdateFile();
            var insert = new InsertFile();
            string[] filesPhone = Directory.GetFiles(textboxPhone, "*.*", SearchOption.AllDirectories);
            //для выбранных файлов с компьютера
            foreach (var fileComp in chekedNames)
            {
                string pathPhInCom = textboxComp + "\\" + fileComp;
                string pathComInPhon = textboxPhone + "\\" + fileComp;
                string pathComp = textboxComp + "\\" + fileComp;
                string fileNameAndFolder = pathComp.Replace(textboxComp, "");
                var findFileFromPhone = context.PhoneModels.FirstOrDefault(file => file.Name == fileComp);
                var findFileFromComp = context.ComputerModels.FirstOrDefault(file => file.Name == fileComp);
                //если файла нет в папке телефона
                if (Array.IndexOf(filesPhone, pathComInPhon) == -1)
                {
                    //если файла нет в бд телефона
                    if (findFileFromPhone == null)
                    {
                        insert.InsertFileIfNotInDbPhone(fileComp, pathComp, pathComInPhon);
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
                        update.UpdateIfNotInDbPhone(fileComp, pathComp, pathComInPhon);
                    }
                    //если файл есть в бд телефона
                    else
                    {
                        update.UpdateIfInDbPhone(fileComp, pathComp, pathComInPhon,
                                                findFileFromPhone, findFileFromComp);
                    }
                }
            }
        }
    }
}