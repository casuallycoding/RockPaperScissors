using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors.Core.Abstractions;
using RockPaperScissors.Core.Objects;

namespace RockPaperScissors.Core.Tests
{
    [TestClass]
    public class GameMechanicTests
    {

        Paper _paper;
        Rock _rock;
        Scissors _scissors;


        [TestInitialize]
        public void Setup()
        {
             _paper = new Paper("");
             _rock = new Rock("");
             _scissors = new Scissors("");
        }

        [TestMethod]
        public void CheckResult()
        {            
            //All the possible outcomes of rock, paper, scissors
            Assert.AreEqual(ResultEnum.Loss,  _paper.GetResult(_scissors));
            Assert.AreEqual(ResultEnum.Win, _paper.GetResult(_rock));
            Assert.AreEqual(ResultEnum.Drawer, _paper.GetResult(_paper));

            Assert.AreEqual(ResultEnum.Loss, _scissors.GetResult(_rock));
            Assert.AreEqual(ResultEnum.Win, _scissors.GetResult(_paper));
            Assert.AreEqual(ResultEnum.Drawer, _scissors.GetResult(_scissors));

            Assert.AreEqual(ResultEnum.Loss, _rock.GetResult(_paper));
            Assert.AreEqual(ResultEnum.Win, _rock.GetResult(_scissors));
            Assert.AreEqual(ResultEnum.Drawer, _rock.GetResult(_rock));
        }
    }
}
