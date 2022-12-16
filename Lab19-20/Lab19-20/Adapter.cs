using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_20
{
    public interface IAnimal
    {
        void Run();
    }

    public class Camel : IAnimal
    {
        public void Run()
        {
            Console.WriteLine("Покататься на вердлюде");
        }
    }
    public class Person
    {
        public void Travel(IAnimal animal)
        {
            animal.Run();
        }
    }

    public interface ITransport
    {
        void Move();
    }
    // класс верблюда
    public class Auto : ITransport
    {
        public void Move()
        {
            Console.WriteLine("Кататься на ламбе");
        }
    }
    // Адаптер от Camel к ITransport
    public class TransportToCamelAdapter : IAnimal
    {
        Auto auto;
        public TransportToCamelAdapter(Auto a)
        {
            auto = a;
        }

        public void Run()
        {
            auto.Move();
        }
    }
}
