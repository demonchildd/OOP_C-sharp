using System;

namespace Lab17_18
{

    public class TravelAgency : ITravelAgency
    {
        public readonly string title;
        public Administrator Administrator { get; set; }
        List<Customer> CustomerList = new List<Customer>();
        public TravelAgency(string title, string AdministratorName)
        {
            this.title = title;
            Administrator = Administrator.getInstance(AdministratorName);
        }
        public void AddCustomer(Customer customer)
        {
            CustomerList.Add(customer);
        }
        public void GetCustomer()
        {
            if (CustomerList != null)
                foreach (Customer customer in CustomerList)
                    Console.WriteLine($"Имена заказчиков: {customer.name}");
            else
                Console.WriteLine("Нет заказчиков");
        }
        public ITravelAgency Clone()
        {
            return new TravelAgency(this.title, this.Administrator.Name);
        }
        public void GetInfo()
        {
            Console.WriteLine($"Название компании: {this.title}\tИмя администратора: {this.Administrator.Name}");
        }
    }

    class MainClass
    {
        public static void Main()
        {
            Hero qwe = new Hero(new ElfFactory(), 250);
            Hero asd = new Hero(new VoinFactory(), 500);
            TravelAgency travel = new TravelAgency("TravelBy", "Roman");
            Customer customer1 = new Customer(845, "Mars");
            travel.AddCustomer(customer1);
            customer1.AddService(qwe);
            customer1.UseServices();

            Customer customer2 = new Customer(456, "Pudge");
            travel.AddCustomer(customer2);
            customer2.AddService(asd);
            customer2.UseServices();

            travel.GetCustomer();
            travel.GetInfo();
            ITravelAgency travelAgency = travel.Clone();

            travelAgency.GetInfo();
            Console.ReadLine();
        }
    }
}
