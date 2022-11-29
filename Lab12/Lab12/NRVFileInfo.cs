using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class NRVFileInfo
    {
        public static void AboutFile(string path)
        {
            NRVLog.Logger($"Дата: {DateTime.Now}");

            
            
            FileInfo fileInfo = new FileInfo(path);
            NRVLog.Logger($"Информация о файле: {fileInfo.Name}\n");
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Полный путь: {fileInfo.DirectoryName}");
                Console.WriteLine($"Имя: {fileInfo.FullName}");
                Console.WriteLine($"Размер: {fileInfo.Length}");
                Console.WriteLine($"Расширение: {fileInfo.Extension}");
                Console.WriteLine($"Дата создания: {fileInfo.CreationTime}");
                NRVLog.Logger($"Полный путь: {fileInfo.DirectoryName}\nИмя: {fileInfo.FullName}\nРазмер: {fileInfo.Length}\nРасширение: {fileInfo.Extension}\nДата создания: {fileInfo.CreationTime}");
            }
            else
            {
                Console.WriteLine("Файл не существует");
                NRVLog.Logger("Файл не существует");
            }
            NRVLog.Logger("---------------------------------\n");
        }
    }
}
