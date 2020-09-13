using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Core.Abstractions
{
    public interface IRockPaperScissorsGame
    {
        GameElementBase GetRandomElement();
        IEnumerable<GameElementBase> GetChoices();

    }
}
