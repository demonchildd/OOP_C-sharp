using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_20
{
    public abstract class Component
    {
        public string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual void Print()
        {
            Console.WriteLine(name);
        }
    }

    public class TourCreate : Component
    {
        public List<Component> components = new List<Component>();

        public TourCreate(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }

        public override void Print()
        {
            Console.WriteLine(name);
            Console.WriteLine();
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Print();
            }
        }
    }

    public class Ser : Component
    {
        public Ser(string name)
                : base(name)
        { }
    }
}
