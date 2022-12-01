using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17_18
{

    public abstract class Type
    {
        public abstract void Info();
    }
    public abstract class Movement
    {
        public abstract void Move();
    }

    public class Mount : Type
    {
        public override void Info()
        {
            Console.WriteLine("Спуститься с горы");
        }
    }
    // класс меч
    public class Water : Type
    {
        public override void Info()
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
    public abstract class TourFactory
    {
        public abstract Movement CreateMovement();
        public abstract Type CreateType();
    }
    // Фабрика создания летящего героя с арбалетом
    public class OneFactory : TourFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Type CreateType()
        {
            return new Mount();
        }
       
        
    }
    // Фабрика создания бегущего героя с мечом
    public class TwoFactory : TourFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Type CreateType()
        {
            return new Water();
        }
    }
    // клиент - сам супергерой
    public class Tour
    {
        private Type type;
        private Movement movement;
        public int total { get; set; }
        public Tour(TourFactory factory, int sum)
        {
            total = sum;
            type = factory.CreateType();
            movement = factory.CreateMovement();
        }
        public void Run()
        {
            movement.Move();
        }
        public void Info()
        {
            type.Info();
        }
    }
    
}
