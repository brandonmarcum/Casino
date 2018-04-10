using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Library.Games
{
    class RockPaperScissors
    {
        public string playerChoice { get; set; }
        public string cpuChoice { get; set; }
        public string status { get; set; }

        public RockPaperScissors(string choice)
        {
            Random rand = new Random();

            playerChoice = choice;
            cpuChoice = GetCpuChoice(rand.Next(0, 3));

            if (cpuChoice.Equals(playerChoice))
                status = "tie";
            else if (CheckWin())
                status = "win";
            else if (CheckLose())
                status = "lose";
            else
                throw new Exception("RockPaperScissors does not satisfy a status statement");

        }

        private string GetCpuChoice(int rand)
        {
            switch(rand)
            {
                case 0: return "rock";
                case 1: return "paper";
                case 2: return "scissors";
                default: throw new Exception("RPS failed @ GetCpuChoice, int rand = " + rand);
            }
        }

        private bool CheckWin()
        {
            if (playerChoice == "paper" && cpuChoice == "rock")
                return true;
            if (playerChoice == "rock" && cpuChoice == "scissors")
                return true;
            if (playerChoice == "scissors" && cpuChoice == "paper")
                return true;

            return false;
        }

        private bool CheckLose()
        {
            if (playerChoice == "rock" && cpuChoice == "paper")
                return true;
            if (playerChoice == "scissors" && cpuChoice == "rock")
                return true;
            if (playerChoice == "paper" && cpuChoice == "scissors")
                return true;

            return false;
        }

    }
}
