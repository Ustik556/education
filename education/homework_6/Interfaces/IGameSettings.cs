using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_6.Interfaces
{
    public interface IGameSettings
    {
        int MinNumber { get; }
        int MaxNumber { get; }
        int MaxAttempts { get; }
    }
}
