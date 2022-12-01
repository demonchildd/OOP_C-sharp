using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{

    public abstract class Weapon
    {
        public abstract void Hit();
    }
    // абстрактный класс движение
    public abstract class Movement
    {
        public abstract void Move();
    }

    // класс арбалет
    public class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Спуститься с горы");
        }
    }
    // класс меч
    public class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Погрузиться под воду");
        }
    }
    // движение полета
    public class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Полет на самолете");
        }
    }
    // движение - бег
    public class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Поезда на автобусе");
        }
    }
    // класс абстрактной фабрики
    public abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }
    // Фабрика создания летящего героя с арбалетом
    public class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }
    // Фабрика создания бегущего героя с мечом
    public class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
    // клиент - сам супергерой
    public class Hero
    {
        private Weapon weapon;
        private Movement movement;
        public int total { get; set; }
        public Hero(HeroFactory factory, int sum)
        {
            total = sum;
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }
        public void Run()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }
    }
    
}
