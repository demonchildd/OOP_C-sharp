using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    public class Ex7
    {
        public static async void BlockColl()
        {
            int x = 0;
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            BlockingCollection<string> blockcoll = new BlockingCollection<string>(5);
            List<string> list = new List<string>() { "Холодильник", "Морозильник", "Утюг", "Печь", "Телефон" };
            Task[] producers = new Task[5]
            {
                new Task(() =>
                {
                    while(true)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                        Thread.Sleep(450);
                        blockcoll.Add(list[0]);
                        Console.WriteLine($"Поставщик #1 привез {list[0]}");
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(600);
                        blockcoll.Add(list[4]);
                        Console.WriteLine($"Поставщик #2 привез {list[4]}");
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(500);
                        blockcoll.Add(list[1]);
                        Console.WriteLine($"Поставщик #3 привез {list[1]}");
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(700);
                        blockcoll.Add(list[2]);
                        Console.WriteLine($"Поставщик #4 привез {list[2]}");
                    }
                }),
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(800);
                        blockcoll.Add(list[3]);
                        Console.WriteLine($"Поставщик #5 привез {list[3]}");
                    }
                })
            };
            foreach (var t in producers)
                t.Start();
            Task[] consumers = new Task[10]
            {
                new Task(() =>
                {
                    while (true)
                    {
                        Console.WriteLine("Покупатель #1 взял: " + blockcoll.Take());
                        Thread.Sleep(80);
                        if (blockcoll.Count == 0)
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Покупатель #1 ушел");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Console.WriteLine("Покупатель #2 взял: " + blockcoll.Take());
                        Thread.Sleep(100);
                        if (blockcoll.Count == 0)
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Покупатель #2 ушел");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Console.WriteLine("Покупатель #3 взял: " + blockcoll.Take());
                        Thread.Sleep(120);
                        if (blockcoll.Count == 0)
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Покупатель #3 ушел");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Console.WriteLine("Покупатель #4 взял: " + blockcoll.Take());
                        Thread.Sleep(70);
                        if (blockcoll.Count == 0)
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Покупатель #4 ушел");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Console.WriteLine("Покупатель #5 взял: " + blockcoll.Take());
                        Thread.Sleep(50);
                        if (blockcoll.Count == 0)
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Покупатель #5 ушел");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Console.WriteLine("Покупатель #6 взял: " + blockcoll.Take());
                        Thread.Sleep(50);
                        if (blockcoll.Count == 0)
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Покупатель #6 ушел");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Console.WriteLine("Покупатель #7 взял: " + blockcoll.Take());
                        Thread.Sleep(95);
                        if (blockcoll.Count == 0)
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Покупатель #7 ушел");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Console.WriteLine("Покупатель #8 взял: " + blockcoll.Take());
                        Thread.Sleep(90);
                        if (blockcoll.Count == 0)
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Покупатель #8 ушел");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Console.WriteLine("Покупатель #9 взял: " + blockcoll.Take());
                        Thread.Sleep(45);
                        if (blockcoll.Count == 0)
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Покупатель #9 ушел");
                            Console.ResetColor();
                            break;
                        }
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Console.WriteLine("Покупатель #10 взял: " + blockcoll.Take());
                        Thread.Sleep(40);
                        if (blockcoll.Count == 0)
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Покупатель #10 ушел");
                            Console.ResetColor();
                            break;
                        }
                    }
                })
            };
            Thread.Sleep(2000);
            foreach(var t in consumers)
                t.Start();
            Task.WaitAll(consumers);
            
        }
    }
}
