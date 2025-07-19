using education.homework_6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_6
{
    public class Game
    {
        private readonly IGameLogic _gameLogic;
        private readonly IUserInput _userInput;
        private readonly IGameOutput _gameOutput;
        private readonly IGameSettings _gameSettings;

        public Game(
            IGameLogic gameLogic,
            IUserInput userInput,
            IGameOutput gameOutput,
            IGameSettings gameSettings)
        {
            _gameLogic = gameLogic;
            _userInput = userInput;
            _gameOutput = gameOutput;
            _gameSettings = gameSettings;
        }

        public void Start()
        {
            _gameOutput.WriteLine("Добро пожаловать в игру «Угадай число»!");
            _gameOutput.WriteLine($"Я загадал число от {_gameSettings.MinNumber} до {_gameSettings.MaxNumber}.");
            _gameOutput.WriteLine($"У вас {_gameSettings.MaxAttempts} попыток.");

            bool isGameOver = false;

            while (!isGameOver)
            {
                _gameOutput.WriteLine("Введите ваше число:");
                int guess = _userInput.GetInput();

                int result = _gameLogic.CheckGuess(guess);

                if (result == 0)
                {
                    _gameOutput.WriteLine("Поздравляем! Вы угадали число!");
                    break;
                }
                else if (result == -1)
                {
                    _gameOutput.WriteLine("Загаданное число больше.");
                }
                else
                {
                    _gameOutput.WriteLine("Загаданное число меньше.");
                }

                isGameOver = _gameLogic.IsGameOver();
            }

            if (isGameOver)
            {
                _gameOutput.WriteLine("Вы исчерпали все попытки. Игра окончена.");
            }
        }
    }
}
