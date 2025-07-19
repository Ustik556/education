using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_6.Interfaces
{
    public interface IGameLogic
    {
        int CheckGuess(int guess);
        bool IsGameOver();
    }
}
