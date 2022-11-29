using System;
using System.Drawing;
using static Lab8.Game;

namespace Lab8
{
    class MainClass
    {
       
        public static void Main()
        {
            int check;
            Game game = new Game(150);
            while (game.Health != 0)
            {
                Console.WriteLine("1 - Нанести урон\n2 - Вылечить\n3 - Информация");
                check = Convert.ToInt32(Console.ReadLine());
                switch (check)
                {
                    case 1:
                        Console.WriteLine("Введите количество урона");
                        check = Convert.ToInt32(Console.ReadLine());
                        game.Kill(check);
                        break;
                    case 2:
                        Console.WriteLine("Введите количество пополнения здоровья");
                        check = Convert.ToInt32(Console.ReadLine());
                        game.Help(check);
                        break;
                    case 3:
                        game.Info();
                        break;
                    default:
                        break;
                }
            }
            string s = "AD  SAS  AD.asd  da.ASD";
            StringWorker stringWorker = new StringWorker(s);
            Action worker = stringWorker.Information;
            Func<string, string> func = stringWorker.Add;
            func += stringWorker.Low;
            func += stringWorker.Up;
            func += stringWorker.Delete;
            func += stringWorker.DeleteSpace;
            Predicate<string> predicate = stringWorker.Check;
            worker();
            Console.WriteLine(func(s));
            if (predicate(s))
            {
                Console.WriteLine("Строка длинная");
            }
            else
            {
                Console.WriteLine("Строка короткая");
            }

        }    
    }
}