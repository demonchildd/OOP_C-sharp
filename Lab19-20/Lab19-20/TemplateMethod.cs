using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_20
{
    abstract class TouR
    {
        public void Period()
        {
            Order();
            Road();
            Rest();
            Impression();
        }
        public virtual void Order()
        {
            Console.WriteLine("Заказываем билеты");
        }
        public abstract void Road();
        public virtual void Rest()
        {
            Console.WriteLine("Отдыхаем");
        }
        public abstract void Impression();
    }

    class Afrika : TouR
    {
        

        public override void Road()
        {
            Console.WriteLine("Летим на самолете");
        }

        public override void Impression()
        {
            Console.WriteLine("Рассказываем всем как дрались с крокодилом");
        }
    }

    class Maldiv : TouR
    {

        public override void Road()
        {
            Console.WriteLine("Едем на автобусе");
            Console.WriteLine("Плывем на параходе");
        }


        public override void Impression()
        {
            Console.WriteLine("Видели самку кита");
        }
    }
}
