using RockPaperScissors.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.App.Models
{
    public class GameViewModel
    {

        public int Players { get; set; }
        public GameElementBase PlayerPic { get; set; }
        public GameElementBase Ai1Pic { get; set; }
        public GameElementBase Ai2Pic { get; set; }

        public String Result { get; set; }
        public List<GameElementBase> MoveChoices { get; set; }



    }
}
