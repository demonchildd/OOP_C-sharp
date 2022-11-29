    
using System;
using System.Text;

namespace Lab11
{
    class MainClass
    {
        public static void Main()
        {
            
            Reflector.GetName(typeof(int));
            Console.WriteLine("---------------------------------------");
            Reflector.GetName(typeof(Computer));
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(Reflector.PubCtor(typeof(Computer)));
            Console.WriteLine("---------------------------------------");
            IEnumerable<string> list1 = Reflector.PubMet(typeof(Computer));
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------------");
            IEnumerable<string> list2 = Reflector.Fields(typeof(Computer));
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------------");
            IEnumerable<string> list3 = Reflector.E(typeof(Computer));
            foreach (var item in list3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------------");
            Computer computer = new Computer("asd", "qwe", 120);
            var call = typeof(Computer).GetMethod("Test");
            Random rand = new Random();

            int stringlen = rand.Next(4, 10);
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {
                randValue = rand.Next(0, 26);
                letter = Convert.ToChar(randValue + 65);
                str = str + letter;
            }
            
            call.Invoke(computer, new object[] { stringlen, str });
            // чтение из файла
            using (FileStream fstream = File.OpenRead("D:\\Курс2\\ООП\\Lab11\\Lab11\\b.txt"))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                fstream.Read(buffer, 0, buffer.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(buffer);
                string[] prmtrs = textFromFile.Split(" ");
                int fisrtParam = Convert.ToInt32(prmtrs[0]);
                string secondParam = prmtrs[1];
              
                call?.Invoke(computer, new object[] { fisrtParam, secondParam });
            }
            
            
            Console.WriteLine("---------------------------------------");
            try
            {
                var number = Reflector.Create<int>(new object[] { 2 });
                Console.WriteLine($"{number}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            try
            {
                
                var comp = Reflector.Create<Computer>(new object[] { "Со****", "Америка", 15 });
                Console.WriteLine(comp.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }

            var dt = Reflector.Create<DateTime>(new object[] { 2020, 12, 15 });
            Console.WriteLine($"{dt}");



        }
        
    }
}