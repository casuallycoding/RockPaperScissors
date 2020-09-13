using RockPaperScissors.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Core.Objects
{
    public class Paper : GameElementBase
    {
        public Paper(string url) : base(url,typeof(Rock), typeof(Scissors) )
        {
          
        }      
    }

}
  
   
