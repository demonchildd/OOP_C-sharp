using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_20
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Receiver - Получатель
    class Computer
    {
        public void On()
        {
            Console.WriteLine("Заказ попал в обработку");
        }

        public void Off()
        {
            Console.WriteLine("Заказ обработался");
        }
    }

    class ComputerOnCommand : ICommand
    {
        Computer comp;
        public ComputerOnCommand(Computer compSet)
        {
            comp = compSet;
        }
        public void Execute()
        {
            comp.On();
        }
        public void Undo()
        {
            comp.Off();
        }
    }

    // Invoker - инициатор
    class Pers
    {
        ICommand command;

        public Pers() { }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            command.Execute();
        }
        public void PressUndo()
        {
            command.Undo();
        }
    }
}
