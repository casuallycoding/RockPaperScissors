using RockPaperScissors.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Core.Objects
{
    public class Rock : GameElementBase
    {
        public Rock(string url) : base(url,typeof(Scissors),  typeof(Paper))
        {

        }
    }
}
