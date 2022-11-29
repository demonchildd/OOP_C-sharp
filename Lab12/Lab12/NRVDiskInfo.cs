using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class NRVDiskInfo
    {
        public static void AboutDisk()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            NRVLog.Logger($"Дата: {DateTime.Now}");
            
            NRVLog.Logger("Информация о дисках!!!\n");
            
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                NRVLog.Logger($"Название: {drive.Name}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка диска: {drive.VolumeLabel}");
                    Console.WriteLine($"Файловая система: {drive.DriveFormat}");
                    NRVLog.Logger($"Объем диска: {drive.TotalSize}\nСвободное пространство: {drive.TotalFreeSpace}\nМетка диска: {drive.VolumeLabel}\nФайловая система: {drive.DriveFormat}");
                }
                Console.WriteLine();
                
            }
            NRVLog.Logger("---------------------------------\n");
        }
    }
}
