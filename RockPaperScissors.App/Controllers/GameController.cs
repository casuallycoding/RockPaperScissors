using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RockPaperScissors.App.Models;
using RockPaperScissors.Core.Abstractions;

namespace RockPaperScissors.App.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly IRockPaperScissorsGame _game;
        private GameViewModel model = new GameViewModel();

        public GameController(ILogger<GameController> logger, IRockPaperScissorsGame game)
        {
            _logger = logger;
            _game = game;
        }

        public ActionResult Index()
        {                   
            return View();
        }

        /// <summary>
        /// This is called when the number of players is assigned. If there are 0 (e.g. all AI) it runs both as AI immediately.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Players(int id)
        {
            try
            {
                if (id > 0)
                {
                    model.MoveChoices = _game.GetChoices().ToList();
                    model.Players = id;
                }
                else
                {
                    model.MoveChoices = new List<GameElementBase>();
                    model.Players = 0;
                    return RedirectToAction("Results");
                }
            }catch(Exception ex)
            {
                _logger.LogError("Error in playing.", ex);
            }
            return View(model);
        }

        /// <summary>
        /// By passing through the choice the player (or AI) has made, a new one is then picked to play against it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Results(string id)
        {
            try
            {
                var playerPick = _game.GetChoices().Where(p => p.Name == id).FirstOrDefault();
                var autoPick = playerPick ?? _game.GetRandomElement();//fall back to two AI's playing
                var aiPick = _game.GetRandomElement();
                var res = autoPick.GetResult( aiPick);               

                model.Ai1Pic = aiPick;
                model.PlayerPic = playerPick;
                model.Ai2Pic = autoPick;
                model.Result = res.ToString();
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in playing.", ex);
            }
            return View(model);
        }


    }
}
