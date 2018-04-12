using System;
using Xunit;
using Casino.Library.Games;

namespace Casino.Test
{
    public class RockPaperScissorsTest
    {

        [Fact]
        public void TRPS01ThrowRock()
        {
            RockPaperScissors rps = new RockPaperScissors("rock");
        }

        [Fact]
        public void TRPS02ThrowPaper()
        {
            RockPaperScissors rps = new RockPaperScissors("paper");
        }

        [Fact]
        public void TRPS03ThrowScissors()
        {
            RockPaperScissors rps = new RockPaperScissors("scissors");
        }

        [Fact]
        public void TRPS04TestCPUChoices()
        {
            RockPaperScissors rps = new RockPaperScissors("paper");

            for (int i = 0; i < 500; i++)
            {
                string x = rps.GetCpuChoice();
                Assert.True(x == "rock" || x == "paper" || x == "scissors");
            }
        }

        [Fact]
        public void TRPS05PRockCScissors()
        {
            RockPaperScissors rps = new RockPaperScissors("rock");
            rps.cpuChoice = "scissors";
            Assert.True(rps.GetResult() == "win");
        }

        [Fact]
        public void TRPS06PRockCRock()
        {
            RockPaperScissors rps = new RockPaperScissors("rock");
            rps.cpuChoice = "rock";
            Assert.True(rps.GetResult() == "tie");
        }

        [Fact]
        public void TRPS07PRockCPaper()
        {
            RockPaperScissors rps = new RockPaperScissors("rock");
            rps.cpuChoice = "paper";
            Assert.True(rps.GetResult() == "lose");
        }

        [Fact]
        public void TRPS08PPaperCRock()
        {
            RockPaperScissors rps = new RockPaperScissors("paper");
            rps.cpuChoice = "rock";
            Assert.True(rps.GetResult() == "win");
        }

        [Fact]
        public void TRPS09PPaperCPaper()
        {
            RockPaperScissors rps = new RockPaperScissors("paper");
            rps.cpuChoice = "paper";
            Assert.True(rps.GetResult() == "tie");
        }

        [Fact]
        public void TRPS10PPaperCScissors()
        {
            RockPaperScissors rps = new RockPaperScissors("paper");
            rps.cpuChoice = "scissors";
            Assert.True(rps.GetResult() == "lose");
        }

        [Fact]
        public void TRPS11PScissorsCRock()
        {
            RockPaperScissors rps = new RockPaperScissors("scissors");
            rps.cpuChoice = "rock";
            Assert.True(rps.GetResult() == "lose");
        }

        [Fact]
        public void TRPS12ScissorsCPaper()
        {
            RockPaperScissors rps = new RockPaperScissors("scissors");
            rps.cpuChoice = "paper";
            Assert.True(rps.GetResult() == "win");
        }

        [Fact]
        public void TRPS13PScissorsCScissors()
        {
            RockPaperScissors rps = new RockPaperScissors("scissors");
            rps.cpuChoice = "scissors";
            Assert.True(rps.GetResult() == "tie");
        }

        [Fact]
        public void TRPS14GoldenTest()
        {
            RockPaperScissors rps = new RockPaperScissors("scissors");
            for (int i = 0; i < 500; i++)
            {
                string playerInput = rps.GetCpuChoice();
                RockPaperScissors trueRPS = new RockPaperScissors(playerInput);
                string s = trueRPS.status;
                Assert.True(s == "win" || s == "lose" || s =="tie");
            }
            
        }
    }
}
