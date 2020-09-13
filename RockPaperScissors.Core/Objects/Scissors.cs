using RockPaperScissors.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Core.Objects
{
    public class Scissors : GameElementBase
    {
        public Scissors(string url) : base(url, typeof(Paper),  typeof(Rock))
        {

        }
    }
}
