using System;
using System.Collections.Generic;
using System.Text;
using RockPaperScissors.Core.Abstractions;

namespace RockPaperScissors.Core.Objects
{


    public class CustomElement : GameElementBase
    {

        public CustomElement(string url,Type beats, Type wins ) : base(url,beats,  wins) {}
    }

}
