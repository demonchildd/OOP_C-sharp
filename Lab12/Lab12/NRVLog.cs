using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class NRVLog
    {
        
        public static void Logger(string str)
        {
            using (StreamWriter sw = new StreamWriter("D:\\Курс2\\ООП\\Lab12\\Lab12\\nrvlogfile.txt", true))
            {
                sw.WriteLine(str);
            }
        }

        public static void Count()
        {
            using (StreamReader reader = new StreamReader("D:\\Курс2\\ООП\\Lab12\\Lab12\\nrvlogfile.txt"))
            {
                string? line;
                int count = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "---------------------------------")
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Число записей: {count}");
            }
        }

        public static void Search(string str)
        {
            using (StreamReader reader = new StreamReader("D:\\Курс2\\ООП\\Lab12\\Lab12\\nrvlogfile.txt"))
            {
                string? line;
                string strOut = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(str))
                    {
                        strOut = strOut + line + "\n";
                        while ((line = reader.ReadLine()) != "---------------------------------")
                        {
                            strOut = strOut + line + "\n";
                        }
                    }
                }
                Console.WriteLine(strOut);
            }
        }

        public static void Interval()
        {
            using (StreamReader reader = new StreamReader("D:\\Курс2\\ООП\\Lab12\\Lab12\\nrvlogfile.txt"))
            {
                DateTime time1 = DateTime.Now;
                time1 = time1.AddHours(-2);
                DateTime time2 = DateTime.Now;
                time2 = time2.AddHours(-1);
                string? line;
                string strOut = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("Дата:"))
                    {
                        string pr = line.Remove(0, 5);
                        DateTime check = Convert.ToDateTime(pr);
                        if (check > time1 && check < time2)
                        {
                            strOut = strOut + line + "\n";
                            while ((line = reader.ReadLine()) != "---------------------------------")
                            {
                                strOut = strOut + line + "\n";
                            }
                        }
                    }
                }
                Console.WriteLine(strOut);
            }
        }
        public static void Delete()
        {
            
            using (StreamReader reader = new StreamReader("D:\\Курс2\\ООП\\Lab12\\Lab12\\nrvlogfile.txt"))
            {
                DateTime time = DateTime.Now;
                time = time.AddHours(-1);
                string? line;
                string strOut = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("Дата:"))
                    {
                        string pr = line.Remove(0, 5);
                        DateTime check = Convert.ToDateTime(pr);
                        if (check > time)
                        {
                            strOut = strOut + line + "\n";
                            while ((line = reader.ReadLine()) != "---------------------------------")
                            {
                                strOut = strOut + line + "\n";
                            }
                        }
                    }
                }
                Console.WriteLine(strOut);
            }
        }


    }
}
