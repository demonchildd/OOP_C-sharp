using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace Lab9
{
    public class MainClass
    {
        public static void Main()
        {
            Computer computer1 = new Computer("Asus", "intel", 7000);
            Computer computer2 = new Computer("ASUS", "AMD", 4800);
            Computer computer3 = new Computer("Lenovo", "intel", 2500);
            MyCollection<Computer> test = new MyCollection<Computer>();
            test.Add(computer1);
            test.Add(computer2);
            test.Add(computer3);
            test.Print();
            test.Remove(computer1);
            test.Print();
            Console.WriteLine(test.Contains(computer2));
            

            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(6);
            int check = Convert.ToInt32(Console.ReadLine());
            check = check - 1;
            if (set.Count() < check)
            {
                Console.WriteLine("До связи");
            }
            else
            {
                int[] arr = new int[set.Count()];
                set.CopyTo(arr, 0);
                while (check != -1) 
                {
                    set.Remove(arr[check]);
                    check--;
                }
                int[] arr2 = new int[set.Count()];
                set.CopyTo(arr2, 0);
                for (int i = 0; i < arr2.Length; i++)
                {
                    Console.Write($"{ arr2[i]} ");
                }
            }
            Console.WriteLine();
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(6);
            list.Remove(6);
            list.RemoveAt(1);
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            
            Console.WriteLine(list.Contains(3));






            ObservableCollection<Computer> C = new ObservableCollection<Computer>();

            C.CollectionChanged += C_CollectionChanged;

            C.Add(computer1);
            C.Add(computer2);
            C.RemoveAt(1);
            C[0]= computer3;

            Console.WriteLine("\nСписок пользователей:");
            foreach (var item in C)
            {
                Console.WriteLine(item.ToString());
            }

            void C_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
                {
                    switch (e.Action)
                    {
                        case NotifyCollectionChangedAction.Add: // если добавление
                            if (e.NewItems?[0] is Computer newComputer)
                                Console.WriteLine($"Добавлен новый объект: {newComputer.Name}");
                            break;
                        case NotifyCollectionChangedAction.Remove: // если удаление
                            if (e.OldItems?[0] is Computer oldComputer)
                                Console.WriteLine($"Удален объект: {oldComputer.Name}");
                            break;
                        case NotifyCollectionChangedAction.Replace: // если замена
                            if ((e.NewItems?[0] is Computer replacingComputer) &&
                                (e.OldItems?[0] is Computer replacedComputer))
                                Console.WriteLine($"Объект {replacedComputer.Name} заменен объектом {replacingComputer.Name}");
                            break;
                    }
                }
            }

       
    }
}