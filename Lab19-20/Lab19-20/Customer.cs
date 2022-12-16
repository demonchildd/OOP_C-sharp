using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab17_18
{
    

    public class Wish
    {
        public string wish { get; set; }
    }
   
    public class Sea
    { }

    public class Additives
    {
        public string type { get; set; }
    }

    public class Customer
    {
        public List<Tour> services = new List<Tour>();
        public Bill bill;
        public string name;
        public int _id;
        public Customer(int id, string name)
        {
            this.name = name;
            bill = new Bill();
            bill.summa = 0;
            _id = id;
        }
        public void AddService(Tour service)
        {
            services.Add(service);
            bill.summa += service.total;
        }
        public int GetBill()
        {
            return bill.summa;
        }
        public void UseServices()
        {
            Console.WriteLine($"Заказчик {name}:");
            if (services != null)
                foreach (Tour service in services)
                {
                    service.Run();
                    service.Info();
                }
            else
                Console.WriteLine("Туры не выбраны");
        }
        public Wish Wish { get; set; }
      
        public Sea Sea { get; set; }
       
        public Additives Additives { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Wish != null)
                sb.Append(Wish.wish+ "\n");
            if (Sea != null)
                sb.Append("Хочу море \n");
            if (Additives != null)
                sb.Append(Additives.type + " \n");
            return sb.ToString();
        }
    }
    abstract class CustomBuilder
    {
        public Customer Custom { get; private set; }
        public void CreateCustom(int id, string name)
        {
            Custom = new Customer(id, name);
        }
        public abstract void SetWish();
        public abstract void SetSea();
        public abstract void SetAdditives();
    }
    class Agent
    {
        public Customer Create(CustomBuilder customBuilder, int id, string name)
        {
            customBuilder.CreateCustom(id, name);
            customBuilder.SetWish();
            customBuilder.SetSea();
            customBuilder.SetAdditives();
            return customBuilder.Custom;
        }
    }
    class SeaCustomBuilder : CustomBuilder
    {
        public override void SetWish()
        {
            this.Custom.Wish = new Wish { wish = "Песчаный пляж" };
        }

        public override void SetSea()
        {
            this.Custom.Sea = new Sea();
        }

        public override void SetAdditives()
        {
            // не используется
        }
    }
   
    class NatureCustomBuilder : CustomBuilder
    {
        public override void SetWish()
        {
            this.Custom.Wish = new Wish { wish = "Горный рельеф" };
        }

        public override void SetSea()
        {
            
        }

        public override void SetAdditives()
        {
            this.Custom.Additives = new Additives { type = "Запах леса" };
        }
    }
}
