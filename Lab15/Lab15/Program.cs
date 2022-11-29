using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lab15
{
    class MainClass
    {
        
        public static void Main()
        {
            #region 1
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Task task1 = new Task(() =>
            {
                Thread.Sleep(1000);
                int[,] a = { { 1, 2, 3 }, { 4, 4, 8 }, { 4, 4, 8 } };
                int[,] b = { { 1, 2, 3 }, { 4, 4, 8 }, { 4, 4, 8 } };
                if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
                int[,] r = new int[a.GetLength(0), b.GetLength(1)];
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < b.GetLength(1); j++)
                    {
                        for (int k = 0; k < b.GetLength(0); k++)
                        {
                            r[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }
                for (int i = 0; i < r.GetLength(0); i++)
                {
                    for (int j = 0; j < r.GetLength(1); j++)
                    {
                        Console.Write("{0} ", r[i, j]);
                    }
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
            });
            task1.Start();
            Console.WriteLine($"task1 Id: {task1.Id}");
            Console.WriteLine($"task1 is Completed: {task1.IsCompleted}");
            Console.WriteLine($"task1 Status: {task1.Status}");
            task1.Wait();
            
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Stopwatch stopWatch3 = new Stopwatch();
            stopWatch3.Start();
            void MulMatrix()
            {
                Thread.Sleep(1000);
                int[,] a = { { 1, 2, 3 }, { 4, 4, 8 }, { 4, 4, 8 } };
                int[,] b = { { 1, 2, 3 }, { 4, 4, 8 }, { 4, 4, 8 } };
                if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
                int[,] r = new int[a.GetLength(0), b.GetLength(1)];
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < b.GetLength(1); j++)
                    {
                        for (int k = 0; k < b.GetLength(0); k++)
                        {
                            r[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }
                for (int i = 0; i < r.GetLength(0); i++)
                {
                    for (int j = 0; j < r.GetLength(1); j++)
                    {
                        Console.Write("{0} ", r[i, j]);
                    }
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }

            }
            MulMatrix();
            stopWatch3.Stop();
            TimeSpan ts3 = stopWatch.Elapsed;
            string elapsedTime3 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts3.Hours, ts3.Minutes, ts3.Seconds,
                ts3.Milliseconds / 10);
            Console.WriteLine("RunTimeCommon " + elapsedTime3);
            #endregion
            #region 2
            //task2
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            Task task2 = new Task(() =>
            {
                Thread.Sleep(1000);
                int[,] a = { { 1, 2, 3 }, { 4, 4, 8 }, { 4, 4, 8 } };
                int[,] b = { { 1, 2, 3 }, { 4, 4, 8 }, { 4, 4, 8 } };
                if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
                int[,] r = new int[a.GetLength(0), b.GetLength(1)];
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < b.GetLength(1); j++)
                    {
                        for (int k = 0; k < b.GetLength(0); k++)
                        {
                            r[i, j] += a[i, k] * b[k, j];
                            
                        }
                    }
                }
                for (int i = 0; i < r.GetLength(0); i++)
                {
                    for (int j = 0; j < r.GetLength(1); j++)
                    {
                        Console.Write("{0} ", r[i, j]);

                    }                
                    Console.WriteLine();
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }
                    Thread.Sleep(1000);
                }
            });
            task2.Start();  // запускаем задачу
            Console.WriteLine($"task2 Id: {task2.Id}");
            Console.WriteLine($"task2 is Completed: {task2.IsCompleted}");
            Console.WriteLine($"task2 Status: {task2.Status}");
            Thread.Sleep(2000);
            cancelTokenSource.Cancel();
            Thread.Sleep(2000);
            
            Console.WriteLine($"task2 Status: {task2.Status}");
            cancelTokenSource.Dispose();

            #endregion
            Ex3.ex3();
            #region 4
            //TASK4
            //task4
            Task task3 = new Task(() => Console.WriteLine($"Current Task: {Task.CurrentId}"));

            // задача продолжения
            Task task4 = task3.ContinueWith(t =>
                Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"), TaskContinuationOptions.NotOnRanToCompletion);

            Task task5 = task4.ContinueWith(t =>
                Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));


            Task task6 = task5.ContinueWith(t =>
                Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));

            task3.Start();

            task6.Wait();   //  ждем завершения последней задачи



            Task<int> what = Task.Run(() => Enumerable.Range(1, 100000).Count(n => (n % 2 == 0)));
            // получаем объект продолжения 
            var awaiter = what.GetAwaiter();
            // что делать после окончания предшественника 
            awaiter.OnCompleted(() => {
                // получаем результат вычислений предшественника 
                int res = awaiter.GetResult();
                Console.WriteLine(res);
            });
            what.Wait();

            async Task<int> GetOneAsync()
            {
                await Task.Delay(1000);
                return 11111;
            }
            int one = GetOneAsync().GetAwaiter().GetResult();
            Console.WriteLine(one);

            #endregion
            #region 5
            //task5
            int[][] arr = new int[4][];
            arr[0] = new int[1_000_000];
            arr[1] = new int[1_000_000];
            arr[2] = new int[1_000_000];
            arr[3] = new int[1_000_000];

            
            Stopwatch stopWatch1 = new Stopwatch();
            stopWatch1.Start();
            Parallel.For(0, 4, n =>
            {
                Random random = new Random();
                for (int i = 0; i < 1_000_000; i++)
                {
                    arr[n][i] = random.Next(1, 100);
                }
            }
            );
            stopWatch1.Stop();

            TimeSpan ts1 = stopWatch1.Elapsed;
            string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts1.Hours, ts1.Minutes, ts1.Seconds,
                ts1.Milliseconds / 10);
            Console.WriteLine("RunTimeParallel " + elapsedTime1);

            
            Stopwatch stopWatch2 = new Stopwatch();
            Random random = new Random();
            stopWatch2.Start();
            for (int i = 0; i < 1_000_000; i++)
                arr[0][i] = random.Next(1, 1000);
            for (int i = 0; i < 1_000_000; i++)
                arr[1][i] = random.Next(1, 1000);
            for (int i = 0; i < 1_000_000; i++)
                arr[2][i] = random.Next(1, 1000);
            for (int i = 0; i < 1_000_000; i++)
                arr[3][i] = random.Next(1, 1000);
            stopWatch2.Stop();

            TimeSpan ts2 = stopWatch2.Elapsed;
            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts2.Hours, ts2.Minutes, ts2.Seconds,
                ts2.Milliseconds / 10);
            Console.WriteLine("RunTimeUsual " + elapsedTime2);
            #endregion
            #region 6 
            Parallel.Invoke( Print, () =>
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
            },
            () => Square(5));

            void Print()
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
            }
            // вычисляем квадрат числа
            void Square(int n)
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
                Console.WriteLine($"Результат {n * n}");
            }
            #endregion

            Ex8.ex8();
            Console.ReadLine();
            Ex7.BlockColl();
            
            Console.WriteLine("Main Ends");
        }
    }
}