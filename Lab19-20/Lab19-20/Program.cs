using Lab19_20;
using System;
using System.Reflection.PortableExecutable;
using System.Threading;

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
            Console.WriteLine("----------------------Adapter----------------------");
            Camel camel = new Camel();
            
            Auto auto = new Auto();

            IAnimal camelTransport = new TransportToCamelAdapter(auto);
            Tour water = new Tour(new OneFactory(), 250, camel);
            Tour mount = new Tour(new TwoFactory(), 500, camelTransport);
            water.DopInfo();
            mount.DopInfo();
            Console.WriteLine("----------------------Composite----------------------");
            Component country = new TourCreate("Турция");
          
            Component hotel = new TourCreate("Отель ПОНОС");
           
            Component one = new Ser("100 бассейнов");
            Component two = new Ser("Персонал дает");
           
            hotel.Add(one);
            hotel.Add(two);
            
            country.Add(hotel);
            
            country.Print();
            Console.WriteLine();
           
            Console.WriteLine("-------------------Command------------------------");
            Pers pers = new Pers();
            Computer computer = new Computer();
            pers.SetCommand(new ComputerOnCommand(computer));
            pers.PressButton();
            pers.PressUndo();

            Console.Read();
            Console.WriteLine("----------------TemplateMethod----------------------");
            Afrika afrika = new Afrika();
            Maldiv maldiv = new Maldiv();

            afrika.Period();
            Console.WriteLine();
            afrika.Period();
            Console.WriteLine("-----------------Iterator----------------------");
            Agency agency = new Agency();
            Persona reader = new Persona();
            reader.SeeTours(agency);
            Console.WriteLine("--------------------------------------------------");
            TravelAgency travel = new TravelAgency("TravelBy", "Roman");
            Agent agent = new Agent();

            CustomBuilder builder = new SeaCustomBuilder();

            Customer SeaCustom = agent.Create(builder, 456, "MAKS");
            

            builder = new NatureCustomBuilder();
            Customer NatureCustom = agent.Create(builder, 798, "DIMON");
            //Console.WriteLine(SeaCustom.ToString());
            //Console.WriteLine(NatureCustom.ToString());
            
            travel.AddCustomer(SeaCustom);
            SeaCustom.AddService(mount);
            SeaCustom.UseServices();

          
            travel.AddCustomer(NatureCustom);
            NatureCustom.AddService(water);
            NatureCustom.UseServices();

            travel.GetCustomer();
            Console.WriteLine("------------------------------------------");
            travel.GetInfo();
            ITravelAgency travelAgency = travel.Clone();

            travelAgency.GetInfo();
            Console.ReadLine();
           
        }
    }
}
