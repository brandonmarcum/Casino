using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Library.Games.ChickenFight
{
    class Fight
    {
        public string GameName = "Chicken Fight";
        Chicken chickenA;
        Chicken chickenB;

        public Fight()
        {
            chickenA = new Chicken();
            chickenB = new Chicken();
        }

        public void PlaceBetA()
        {
            chickenA.Betted = true;
        }

        public void PlaceBetB()
        {
            chickenB.Betted = true;
        }

        public string Engage()
        {

            while (chickenA.Standing && chickenB.Standing)
            {
                if(chickenA.Betted)
                {
                    ChickenBTurn();
                    ChickenATurn();
                }
                else if (chickenB.Betted)
                {
                    ChickenATurn();
                    ChickenATurn();
                }
            }

            return CheckWin();
        }

        private string CheckWin()
        {
            if (chickenA.Betted && !chickenA.Standing)
                return "lose";
            else if (chickenB.Betted && !chickenB.Standing)
                return "lose";
            else
                return "win";
        }

        private void ChickenATurn()
        {
            if (!chickenB.Evade() && chickenA.Standing)
                chickenB.DecreaseHealth(chickenA.Attack);
        }

        private void ChickenBTurn()
        {
            if (!chickenA.Evade())
                chickenA.DecreaseHealth(chickenB.Attack);
        }
    }
}
