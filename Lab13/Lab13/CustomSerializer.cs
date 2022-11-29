using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab13
{
    public class CustomSerializer
    {
        public static void AllSerializer<T>(object obj)
        {
            Console.WriteLine("\n\n----------------CustomSerializer-------------------");
            BinaryFormatter formatter1 = new BinaryFormatter();
            using (FileStream fs = new FileStream("D:\\Курс2\\ООП\\Lab13\\Lab13\\obj.bin", FileMode.OpenOrCreate))
            {
                formatter1.Serialize(fs, obj);
                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("D:\\Курс2\\ООП\\Lab13\\Lab13\\obj.bin", FileMode.OpenOrCreate))
            {
                T newObj1 = (T)formatter1.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                newObj1.ToString();
            }
            Console.WriteLine("--------------------------------------------");


            SoapFormatter formatter2 = new SoapFormatter();

            using (FileStream fs = new FileStream("D:\\Курс2\\ООП\\Lab13\\Lab13\\oobj.soap", FileMode.OpenOrCreate))
            {
                formatter2.Serialize(fs, obj);
                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("D:\\Курс2\\ООП\\Lab13\\Lab13\\oobj.soap", FileMode.OpenOrCreate))
            {
                T newObj2 = (T)formatter2.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                newObj2.ToString();

            }
            Console.WriteLine("--------------------------------------------");


            string json = JsonSerializer.Serialize(obj);
            Console.WriteLine("Объект сериализован");
            Console.WriteLine(json);
            T newObj3 = JsonSerializer.Deserialize<T>(json);
            Console.WriteLine("Объект десериализован");
            newObj3.ToString();
            Console.WriteLine("--------------------------------------------");

            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream("D:\\Курс2\\ООП\\Lab13\\Lab13\\obj.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, obj);
                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("D:\\Курс2\\ООП\\Lab13\\Lab13\\obj.xml", FileMode.OpenOrCreate))
            {
                T newObj4 = (T)xmlSerializer.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                newObj4.ToString();
            }
            Console.WriteLine("----------------CustomSerializer-------------------");
        }
    }
}
