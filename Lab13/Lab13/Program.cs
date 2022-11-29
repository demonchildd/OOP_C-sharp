using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Lab13
{
    class MainClass
    {
        public static void Main()
        {
            Book book = new Book("C#", 29, 50, "proga");
            Book book2 = new Book("C++", 85, 65, "PROGA");
            Book[] books = {book2, book};
            book.Print();
            Console.WriteLine("--------------------------------------------");


            BinaryFormatter formatter1 = new BinaryFormatter();
            using (FileStream fs = new FileStream("D:\\Курс2\\ООП\\Lab13\\Lab13\\book.bin", FileMode.OpenOrCreate))
            {
                formatter1.Serialize(fs, book);
                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("D:\\Курс2\\ООП\\Lab13\\Lab13\\book.bin", FileMode.OpenOrCreate))
            {
                Book newBook1 = (Book)formatter1.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                //Console.WriteLine($"Имя: {newBook1.Name} --- Цена: {newBook1.Cost} --- Количество страниц: {newBook1.CountPage} --- Жанр: {newBook1.genre}");
                newBook1.ToString();
            }
            Console.WriteLine("--------------------------------------------");


            SoapFormatter formatter2 = new SoapFormatter();

            using (FileStream fs = new FileStream("D:\\Курс2\\ООП\\Lab13\\Lab13\\boook.soap", FileMode.OpenOrCreate))
            {
                formatter2.Serialize(fs, books);
                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("D:\\Курс2\\ООП\\Lab13\\Lab13\\boook.soap", FileMode.OpenOrCreate))
            {
                Book[] newBook2 = (Book[])formatter2.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                foreach (Book item in newBook2)
                {
                    item.ToString();
                }
                

            }
            Console.WriteLine("--------------------------------------------");


            string json = JsonSerializer.Serialize(book);
            Console.WriteLine("Объект сериализован");
            Console.WriteLine(json);

            Book newBook3 = JsonSerializer.Deserialize<Book>(json);
            Console.WriteLine("Объект десериализован");
            newBook3.ToString();


            Console.WriteLine("--------------------------------------------");


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Book[]));

            using (FileStream fs = new FileStream("D:\\Курс2\\ООП\\Lab13\\Lab13\\book.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, books);
                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("D:\\Курс2\\ООП\\Lab13\\Lab13\\book.xml", FileMode.OpenOrCreate))
            {
                Book[] newBook4 = (Book[])xmlSerializer.Deserialize(fs);

                Console.WriteLine("Объект десериализован");

                foreach (Book item in newBook4)
                {
                    item.ToString();
                }
            }
            Console.WriteLine("--------------------------------------------");

            Book book1 = new Book("C", 999, 999, "proga");
            CustomSerializer.AllSerializer<Book>(book1);



            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D:\\Курс2\\ООП\\Lab13\\Lab13\\book.xml");
            XmlElement? xRoot = xDoc.DocumentElement;

            
            XmlNodeList? nodes = xRoot?.SelectNodes("//Book/Cost");
            if (nodes is not null)
            {
                foreach (XmlNode node in nodes)
                    Console.WriteLine(node.OuterXml);
            }

            XmlNodeList? nodess = xRoot?.SelectNodes("*");
            if (nodes is not null)
            {
                foreach (XmlNode node in nodess)
                    Console.WriteLine(node.OuterXml);
            }





            XDocument xdoc = new XDocument();
            // создаем первый элемент person
            XElement tom = new XElement("person");
            // создаем атрибут name
            XAttribute tomNameAttr = new XAttribute("name", "Tom");
            // создаем два элемента company и age 
            XElement tomCompanyElem = new XElement("company", "Microsoft");
            XElement tomAgeElem = new XElement("age", 37);
            // добавляем атрибут и элементы в первый элемент person
            tom.Add(tomNameAttr);
            tom.Add(tomCompanyElem);
            tom.Add(tomAgeElem);

            // создаем второй элемент person
            XElement bob = new XElement("person");
            // создаем для него атрибут name
            XAttribute bobNameAttr = new XAttribute("name", "Bob");
            // и два элемента - company и age
            XElement bobCompanyElem = new XElement("company", "Google");
            XElement bobAgeElem = new XElement("age", 41);

            bob.Add(bobNameAttr);
            bob.Add(bobCompanyElem);
            bob.Add(bobAgeElem);
           
            // создаем корневой элемент
            XElement people = new XElement("people");
            // добавляем два элемента person в корневой элемент

            people.Add(tom);
            people.Add(bob);
            // добавляем корневой элемент в документ
            xdoc.Add(people);
            //сохраняем документ
            xdoc.Save("D:\\Курс2\\ООП\\Lab13\\Lab13\\people.xml");

            
            
            Console.WriteLine("Data saved");

            XDocument xdocLINQ = XDocument.Load("D:\\Курс2\\ООП\\Lab13\\Lab13\\people.xml");

            var microsoft = xdoc.Element("people")?   // получаем корневой узел people
                .Elements("person")             // получаем все элементы person
                                                // получаем все person, у которого company = Microsoft
                .Where(p => p.Element("company")?.Value == "Microsoft")
                .Select(p => new        // для каждого объекта создаем анонимный объект
                {
                    name = p.Attribute("name")?.Value,
                    age = p.Element("age")?.Value,
                    company = p.Element("company")?.Value
                });

            if (microsoft is not null)
            {
                foreach (var person in microsoft)
                {
                    Console.WriteLine($"Name: {person.name}  Age: {person.age}");
                }
            }

            XDocument xdoc2 = XDocument.Load("D:\\Курс2\\ООП\\Lab13\\Lab13\\people.xml");

            var tom1 = xdoc.Element("people")?   // получаем корневой узел people
                .Elements("person")             // получаем все элементы person
                .FirstOrDefault(p => p.Attribute("name")?.Value == "Bob");

            var name = tom1?.Attribute("name")?.Value;
            var age = tom1?.Element("age")?.Value;
            var company = tom1?.Element("company")?.Value;

            Console.WriteLine($"Name: {name}  Age: {age}  Company: {company}");


        }


    }
    
}