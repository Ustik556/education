using education.homework_6.Interfaces;
using education.homework_6.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Настройки игры
            var settings = new GameSettings
            {
                MinNumber = 1,
                MaxNumber = 100,
                MaxAttempts = 10
            };

            // Создание зависимостей
            IGameLogic gameLogic = new GameLogic(settings);
            IUserInput userInput = new ConsoleInput();
            IGameOutput gameOutput = new ConsoleOutput();

            // Запуск игры
            var game = new Game(gameLogic, userInput, gameOutput, settings);
            game.Start();
        }
    }
}
