using System;
namespace Lab12;

class MainClass
{
    public static void Main()
    {
        //NRVDiskInfo.AboutDisk();
        //Console.WriteLine("----------------------------------------------");
        //NRVFileInfo.AboutFile("D:\\Курс2\\ООП\\Лабы\\1_ОсновыNET_Массивы_кортежи_строки.pdf");
        //Console.WriteLine("----------------------------------------------");
        //NRVDirInfo.AboutDir("D:\\Курс1_2\\Курсовая");
        //Console.WriteLine("----------------------------------------------");
        //NRVFileManager.A("C:\\");
        ////NRVFileManager.DelFile("D:\\Курс2\\ООП\\Lab12\\NRVInspect\\nrvdirinfo.txt");
        //Console.WriteLine("----------------------------------------------");
        //NRVFileManager.B("*.js", "D:\\Курс2\\ООП\\Lab12\\Test");
        //Console.WriteLine("----------------------------------------------");
        NRVFileManager.C();
        Console.WriteLine("----------------------------------------------");
        //NRVLog.Count();
        //NRVLog.Search("26.10.2022");
        NRVLog.Delete();
        //NRVLog.Interval();
        string path1 = @"c:\temp\MyTest.txt";
        string path2 = @"c:\temp\MyTest";
        string path3 = @"temp";
        
        if (Path.HasExtension(path1))
        {
            Console.WriteLine("{0} has an extension.", path1);
        }

        if (!Path.HasExtension(path2))
        {
            Console.WriteLine("{0} has no extension.", path2);
        }

        if (!Path.IsPathRooted(path3))
        {
            Console.WriteLine("The string {0} contains no root information.", path3);
        }

        Console.WriteLine("The full path of {0} is {1}.", path3, Path.GetFullPath(path3));
        Console.WriteLine("{0} is the location for temporary files.", Path.GetTempPath());
        Console.WriteLine("{0} is a file available for use.", Path.GetTempFileName());
    }
}