using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synchronization.Model;

namespace Synchronization.Presenter.Synchronization
{
    public class FromPhoneToComp
    {
        public void Synchronization(List<String> chekedNames, string textboxPhone, string textboxComp)
        {
            var context = new SynchronContext();
            var delete = new DeleteFile();
            var update = new UpdateFile();
            var insert = new InsertFile();
            string[] filesComp = Directory.GetFiles(textboxComp, "*.*", SearchOption.AllDirectories);
            //для выбранных файлов с телефона
            foreach (var filePhon in chekedNames)
            {
                string pathPhInCom = textboxComp + "\\" + filePhon;
                string pathComInPhon = textboxPhone + "\\" + filePhon;
                string pathPhone = textboxPhone + "\\" + filePhon;
                string fileNameAndFolder = pathPhone.Replace(textboxPhone, "");
                var findFileFromPhone = context.PhoneModels.FirstOrDefault(file => file.Name == fileNameAndFolder);
                var findFileFromComp = context.ComputerModels.FirstOrDefault(file => file.Name == fileNameAndFolder);
                //если файла нет в папке компьютера
                if (Array.IndexOf(filesComp, pathPhInCom) == -1)
                {
                    //если файла нет в бд компьютера
                    if (findFileFromComp == null)
                    {
                        insert.InsertFileIfNotInDbComp(filePhon, pathPhone, pathPhInCom);
                    }
                    //если файл есть в бд компьютера
                    else
                    {
                        delete.Delete(pathPhone, pathPhInCom, findFileFromComp, findFileFromPhone);
                    }
                }
                //если файл есть в папке компьютера
                else
                {
                    //если файла нет в бд компьютера
                    if (findFileFromComp == null)
                    {
                        update.UpdateIfNotInDbComp(filePhon, pathPhone, pathComInPhon);
                    }
                    //если файл есть в бд компьютера
                    else
                    {
                        update.UpdateIfInDbComp(filePhon, pathPhone, pathComInPhon,
                                            findFileFromComp, findFileFromPhone);
                    }
                }
            }
        }
    }
}