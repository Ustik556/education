using education.homework_6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_6.Services
{
    public class GameSettings : IGameSettings
    {
        public int MinNumber { get; set; } = 1;
        public int MaxNumber { get; set; } = 100;
        public int MaxAttempts { get; set; } = 10;
    }
}
