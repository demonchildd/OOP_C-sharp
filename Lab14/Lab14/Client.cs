using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    public class Client
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;
        int count = 3;// счетчик чтения

        public Client(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Клиент {i}";
            myThread.Start();
        }

        public void Read()
        {
            while (count > 0)
            {
                sem.WaitOne();  // ожидаем, когда освободиться место

                Console.WriteLine($"{Thread.CurrentThread.Name} получает доступ");

                Console.WriteLine($"{Thread.CurrentThread.Name} использует канал");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} закрыввает канал");

                sem.Release();  // освобождаем место

                count--;
                Thread.Sleep(1000);
            }
        }
    }
}
