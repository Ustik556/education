using education.homework_6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_6.Services
{
    public class GameLogic : IGameLogic
    {
        private readonly IGameSettings _settings;
        private readonly Random _random = new Random();
        private int _targetNumber;
        private int _attempts;

        public GameLogic(IGameSettings settings)
        {
            _settings = settings;
            _targetNumber = _random.Next(_settings.MinNumber, _settings.MaxNumber + 1);
        }

        public int CheckGuess(int guess)
        {
            _attempts++;

            if (guess < _targetNumber)
                return -1; // Загаданное число больше
            else if (guess > _targetNumber)
                return 1; // Загаданное число меньше
            return 0; // Угадано
        }

        public bool IsGameOver()
        {
            return _attempts >= _settings.MaxAttempts;
        }
    }
}
