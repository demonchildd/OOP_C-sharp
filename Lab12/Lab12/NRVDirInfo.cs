using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class NRVDirInfo
    {
        public static void AboutDir(string dirName)
        {
            DirectoryInfo directory = new DirectoryInfo(dirName);
            NRVLog.Logger($"Дата: {DateTime.Now}");

            NRVLog.Logger($"Информация о папке: {directory.Name}\n");
            if (directory.Exists)
            {

                
                DirectoryInfo[] dirs = directory.GetDirectories();
                Console.WriteLine($"Количество подкаталогов: {dirs.Length}");
                Console.WriteLine($"Время создания: {directory.CreationTime}");
                FileInfo[] files = directory.GetFiles();
                Console.WriteLine($"Количество файлов: {files.Length}");
                Console.WriteLine($"Родительские каталоги: {directory.Parent}");
                NRVLog.Logger($"Количество подкаталогов: {dirs.Length}\nВремя создания: {directory.CreationTime}\nКоличество файлов: {files.Length}\nРодительские каталоги: {directory.Parent}");
            }
            NRVLog.Logger("---------------------------------\n");
        }
    }
}
