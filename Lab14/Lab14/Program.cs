using System;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace Lab14
{
    class MainClass
    {
        public static void Main()
        {
            //Info.AboutProcess();
            //Info.AboutDomain();
            //Info.MakeNewDomain();

            //Thread myThread1 = new Thread(Info.Ex3);
            //int check = Convert.ToInt32(Console.ReadLine());
            
            //if (check == 1)
            //{
            //    Console.WriteLine("Запустили поток");
            //    Info.Logger("Запустили поток\n");
            //    myThread1.Start();
                
            //}
            //if (myThread1.IsAlive)
            //{
            //    myThread1.Name = "myThread1";
            //    Console.WriteLine($"Имя: {myThread1.Name}");
            //    Console.WriteLine($"Числовой идентификатор: {myThread1.ManagedThreadId}");
            //    Console.WriteLine($"Приоритет: {myThread1.Priority}");
            //    Info.Logger($"Имя: {myThread1.Name}\nЧисловой идентификатор: {myThread1.ManagedThreadId}\nПриоритет: {myThread1.Priority}\n");
            //}

            int check2 = Convert.ToInt32(Console.ReadLine());
            Thread myThread2 = new Thread(Info.Even);
            Thread myThread3 = new Thread(Info.Odd);
            myThread2.Name= "Even";
            myThread3.Name = "Odd";
            //myThread2.Priority = ThreadPriority.Highest;
            myThread2.Start(check2);
            myThread3.Start(check2);

            
            Console.ReadLine();
            for (int i = 1; i < 6; i++)
            {
                Client reader = new Client(i);
            }
            Console.ReadLine();
            int num = 0;
            // устанавливаем метод обратного вызова

            TimerCallback tm = new TimerCallback(Info.Count);
            // создаем таймер
            Timer timer = new Timer(tm, num, 0, 200);
            Console.ReadLine();

        }
        
    }
}