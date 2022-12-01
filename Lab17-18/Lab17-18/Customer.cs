using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{
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
    }
}
