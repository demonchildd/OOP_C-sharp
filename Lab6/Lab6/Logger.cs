using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Logger
    {
        string logger;

        internal Logger(string logger)        {
            this.logger = logger;
            using (StreamWriter sw = new StreamWriter(logger, false))
            {
                sw.WriteLine("Протокол\nВыполнено " + DateTime.UtcNow.ToString());
            }
        }

        internal async void FileLogger(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter(logger, true))
            {
                await sw.WriteLineAsync($"Исключение: {ex.Message}");
                await sw.WriteLineAsync($"Метод: {ex.TargetSite}");
                await sw.WriteLineAsync($"Трассировка стека: {ex.StackTrace}");
                await sw.WriteLineAsync("______________________________________");
            }
        }


        internal void ConsoleLogger()
        {
            Console.WriteLine("ConsoleLogger\n");
        }
    }
}
