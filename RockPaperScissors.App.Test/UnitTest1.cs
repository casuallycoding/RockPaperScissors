using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissors.App.Controllers;
using RockPaperScissors.App.Models;
using RockPaperScissors.Core.Abstractions;
using RockPaperScissors.Core.Objects;
using System;
using System.Collections.Generic;

namespace RockPaperScissors.App.Test
{
    [TestClass]
    public class GameControllerTests
    {

        ILogger<GameController> _logger;
        Mock<IRockPaperScissorsGame> _game;
        GameController _controller;

        [TestInitialize]
        public void Setup()
        {
            _logger = new NullLoggerFactory().CreateLogger<GameController>();   
            _game = new Mock<IRockPaperScissorsGame>();


            List<GameElementBase> list = new List<GameElementBase>();
            list.Add(new Paper(""));
            list.Add(new Rock(""));
            list.Add(new Scissors(""));

            _game.Setup(p => p.GetChoices()).Returns(list);
            _game.Setup(p => p.GetRandomElement()).Returns(new Scissors(""));           

            _controller =  new GameController(_logger, _game.Object);

        }

        [TestMethod]
        public void PlayersTest()
        {
            var result = _controller.Players(1) as ViewResult;
            var gameView = (GameViewModel)result.ViewData.Model;
            Assert.AreEqual(3, gameView.MoveChoices.Count);
            Assert.AreEqual(1, gameView.Players);


        }

        [TestMethod]
        public void ResultsTest()
        {
            var result = _controller.Results("Rock") as ViewResult;
            var gameView = (GameViewModel)result.ViewData.Model;
            Assert.IsNotNull(gameView.Result);
            Assert.AreEqual(gameView.Result, ResultEnum.Win.ToString());

        }
    }
}
