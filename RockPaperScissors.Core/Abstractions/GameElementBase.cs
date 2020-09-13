using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Core.Abstractions
{
    public abstract class GameElementBase
    {
        private readonly string _imageUrl;

        // Note that we're assuming only three elements will ever be used at this point.
        public Type IsBeatenBy { get; private set; }
        public Type Beats { get; private set; }
        public Type DrawsWith { get; private set; }

        /// <summary>
        /// We use a  base class to identify the "rules" for a given element. E.g Rock beats scissors.
        /// </summary>
        /// <param name="beats"></param>
        /// <param name="drawers"></param>
        /// <param name="loses"></param>
        public GameElementBase(string imageUrl,Type beats, Type loses)
        {
            if (loses == beats) // Without this its possible to make an element with all values the same.
                throw new Exception("Invalid element criteria");
            Beats = beats;
            IsBeatenBy = loses;
            DrawsWith = this.GetType();
            _imageUrl = imageUrl;
        }

        /// <summary>
        /// Gets the results of something against the current object. Outcomes for this are determined in the 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public ResultEnum GetResult(GameElementBase element)
        {
            var currentType = this.GetType();
            var competingType = element.GetType();

            if (competingType == Beats) return ResultEnum.Win;
            else if (competingType == IsBeatenBy) return ResultEnum.Loss;
            else if (competingType == DrawsWith) return ResultEnum.Drawer;
            return ResultEnum.Invalid;

        }

        public string Name => this.GetType().Name;

        public string GetImagePath => _imageUrl;
    }


    public enum ResultEnum
    {
        Win,
        Loss,
        Drawer,
        Invalid
    }
}
