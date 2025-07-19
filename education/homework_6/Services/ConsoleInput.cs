using education.homework_6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_6.Services
{
    public class ConsoleInput : IUserInput
    {
        public int GetInput()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                Console.WriteLine("Пожалуйста, введите корректное число.");
            }
        }
    }
}
