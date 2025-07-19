using education.homework_6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_6.Services
{
    public class ConsoleOutput : IGameOutput
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
