using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    public class Info
    {
        static string path = "D:\\Курс2\\ООП\\Lab14\\Lab14\\log.txt";
        static Info()
        {
            using (StreamWriter sw = new StreamWriter(path, false)) ;
        }
        public static void AboutProcess()
        {
            
            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    bool check = process.Responding;
                    Console.WriteLine($"ID: {process.Id}\tName: {process.ProcessName}\t\tPriority: {process.BasePriority}");
                    Console.WriteLine($"Time start: {process.StartTime}\t\tТукущее состояние: {check}");
                    Console.WriteLine("--------------------------------");
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Message: {ex.Message}");
                }
            }
           
            
        }

        public static void AboutDomain()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine($"SetupInformation: {domain.SetupInformation}");
            Console.WriteLine();

            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);
            Console.WriteLine("--------------------------------");

        }

        public static void MakeNewDomain()
        {
            try
            {
                AppDomain newD = AppDomain.CreateDomain("ProfessorWebAppDomain");
                InfoDomainApp(newD);
                // Уничтожение домена приложения
                AppDomain.Unload(newD);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
            }
            Console.WriteLine("--------------------------------");
        }

        public static void InfoDomainApp(AppDomain defaultD)
        {
            Console.WriteLine("*** Информация о домене приложения ***\n");
            Console.WriteLine("-> Имя: {0}\n-> ID: {1}\n-> По умолчанию? {2}\n-> Путь: {3}\n",
                defaultD.FriendlyName, defaultD.Id, defaultD.IsDefaultAppDomain(), defaultD.BaseDirectory);

            Console.WriteLine("Загружаемые сборки: \n");
            // Извлекаем информацию о загружаемых сборках с помощью LINQ-запроса
            var infAsm = from asm in defaultD.GetAssemblies()
                         orderby asm.GetName().Name
                         select asm;
            foreach (var a in infAsm)
                Console.WriteLine("-> Имя: \t{0}\n-> Версия: \t{1}", a.GetName().Name, a.GetName().Version);
        }
        

        public static void Ex3()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                Console.Write($"{i} ");
                Logger($"{i} ");
                
                Thread.Sleep(300);
            }
            Console.WriteLine();
            Logger("\n");
        }


        static object locker = new();
        public static void Even(object? obj)
        {
            //lock (locker)
            {
                if (obj is int n)
                {
                    for (int i = 0; i <= n; i = i + 2)
                    {
                        lock (locker)
                        {
                            Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
                            Logger($"Четные: {i}\n");
                            Thread.Sleep(400);
                        }
                    }
                }
            }
        }

        public static void Odd(object? obj)
        {
            //lock (locker)
            {
                if (obj is int n)
                {
                    for (int i = 1; i <= n; i = i + 2)
                    {
                        lock (locker)
                        {
                            Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
                            Logger($"Нечетные: {i}\n");
                            Thread.Sleep(200);
                        }

                    }
                }
            }
        }




        public static void Count(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");
            }
        }
        public static void Logger<T>(T str)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(str);
            }
        }
    }
}
