using System;
using System.Runtime.Serialization.Json;

namespace Lab8
{
    class Game
    {
        public delegate void Offensive(string message);
        public event Offensive Attack;
        public event Offensive Heal;

        int health;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Game(int health)
        {
            Health = health;
            Attack += DisplayMessage;
            Heal += DisplayMessage;
        }

        public void Kill(int attack)
        {
            if ((Health - attack)  <= 0)
            {
                Health = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Attack("Конец игры");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Health -= attack;
                Console.ForegroundColor = ConsoleColor.Red;
                Attack?.Invoke($"Вы нанесли урон равный: {attack}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Help(int heal)
        {
            Health += heal;
            Console.ForegroundColor = ConsoleColor.Green;
            Heal($"Вы пополнили здоровье на {heal}");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void Info()
        {
            
            Console.WriteLine($"Текущее здоровье {Health}");
        }

        public void DisplayMessage(string message) => Console.WriteLine(message);
    }
}