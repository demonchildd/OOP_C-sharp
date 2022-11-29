using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class NRVFileManager
    {
        public static void A(string dirName)
        {
            NRVLog.Logger($"Дата: {DateTime.Now}");

            NRVLog.Logger($"Информация о дискe: {dirName}\n");
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                NRVLog.Logger("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {

                    Console.WriteLine(s);
                    NRVLog.Logger(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                NRVLog.Logger("\nФайлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                    NRVLog.Logger(s);
                }
            }
            else
            {
                Console.WriteLine("Диск не существует");
                NRVLog.Logger("Диск не существует");
            }
            
            string pathDir = @"D:\\Курс2\\ООП\\Lab12\\NRVInspect";
            if (!Directory.Exists(pathDir))
            {
                Directory.CreateDirectory(pathDir);
                NRVLog.Logger($"\nСоздали папку: {pathDir}");
            }

            string pathFile = @"D:\\Курс2\\ООП\\Lab12\\NRVInspect\\nrvdirinfo.txt";
            if (!File.Exists(pathFile))
            {
                File.Create(pathFile);
                NRVLog.Logger($"Создали файл: {pathDir}");
            }
            try
            {
                string newPathFile = @"D:\\Курс2\\ООП\\Lab12\\NRVInspect\\NEWnrvdirinfo.txt";
                if (!File.Exists(newPathFile))
                {
                    File.Copy(pathFile, newPathFile, true);
                    NRVLog.Logger($"Скопировали в новый файл: {newPathFile}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Сообщение: {ex.Message}");
            }
            
            NRVLog.Logger("---------------------------------\n");


        }

        public static void DelFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
        public static void B(string Exten, string path)
        {
            NRVLog.Logger($"Дата: {DateTime.Now}");

            NRVLog.Logger($"Различные операции\n");
            string pathDir = @"D:\\Курс2\\ООП\\Lab12\\NRVFiles";
            if (!Directory.Exists(pathDir))
            {
                Directory.CreateDirectory(pathDir);
                NRVLog.Logger($"Создали файл: {pathDir}");
            }
            DirectoryInfo directory = new DirectoryInfo(path);
            if(directory.Exists)
            {
                
                FileInfo[] files = directory.GetFiles(Exten);
                
                foreach (FileInfo item in files)
                {
                    NRVLog.Logger($"Копируем файл {item.Name} в NRVFiles");
                    string buff = pathDir + "\\" + item.Name;
                    item.CopyTo(buff, true);
                }
            }
            if (!Directory.Exists("D:\\Курс2\\ООП\\Lab12\\NRVInspect\\NRVFiles"))
            {
                Directory.Move(pathDir, "D:\\Курс2\\ООП\\Lab12\\NRVInspect\\NRVFiles");
                NRVLog.Logger($"Перемещаем каталог NRVFiles в NRVInspect");
            }

            NRVLog.Logger("---------------------------------\n");
        }

        public static void C()
        {
            string sourceFolder = "D:\\Курс2\\ООП\\Lab12\\NRVInspect\\NRVFiles"; // исходная папка
            string zipFile = "D:\\Курс2\\ООП\\Lab12\\test.zip"; // сжатый файл
            string targetFolder = "D:\\Курс2\\ООП\\Lab12\\NRVZipNew"; // папка, куда распаковывается файл

            NRVLog.Logger($"Дата: {DateTime.Now}");

            NRVLog.Logger($"Архивирование\n");
            if (!File.Exists("D:\\Курс2\\ООП\\Lab12\\test.zip"))
            {
                ZipFile.CreateFromDirectory(sourceFolder, zipFile);
                NRVLog.Logger($"Создаем архив test.zip");
                ZipFile.ExtractToDirectory(zipFile, targetFolder);
                NRVLog.Logger($"Выполняем разпаковку архива test.zip в каталог NRVZipNew");
            }
            NRVLog.Logger("---------------------------------\n");

        }
        
    }
}
