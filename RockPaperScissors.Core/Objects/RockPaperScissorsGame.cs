using RockPaperScissors.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Core.Objects
{
    public class RockPaperScissorsGame : IRockPaperScissorsGame
    {
        private List<GameElementBase> _options;
       
        /// <summary>
        /// This is where the elements of the game are established. It would be possible to pick three other elements (or custom elements) as a different game.
        /// This is so the application can be further expanded if desired.
        /// </summary>
        public RockPaperScissorsGame()
        {
            List<GameElementBase> options = new List<GameElementBase>();
            options.Add(new Rock("https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Logan_Rock_Treen_closeup.jpg/1200px-Logan_Rock_Treen_closeup.jpg"));
            options.Add(new Paper("https://upload.wikimedia.org/wikipedia/commons/c/c4/Coloured%2C_textured_craft_card.jpg"));
            options.Add(new Scissors("https://upload.wikimedia.org/wikipedia/commons/thumb/7/76/Pair_of_scissors_with_black_handle%2C_2015-06-07.jpg/1200px-Pair_of_scissors_with_black_handle%2C_2015-06-07.jpg"));
            _options = options;
        }

        /// <summary>
        /// Returns a random element from the list of elements defined in the constructor. This is the "AI" element of the game.
        /// </summary>
        /// <returns></returns>
        public GameElementBase GetRandomElement()
        {
            Random rnd = new Random();
            var randomIndex = rnd.Next(_options.Count);
            return _options[randomIndex];
        }

        /// <summary>
        /// Returns the elements that have been dedfined in the Game.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GameElementBase> GetChoices()
        {
            return _options;
        }



    }
}
