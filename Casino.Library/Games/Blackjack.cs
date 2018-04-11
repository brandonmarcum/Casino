using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Library.Games
{
    public class Blackjack
    {
        public int playerTotal;
        public int dealerTotal;
        public string status;

        public Blackjack()
        {
            playerTotal = 0;
            dealerTotal = 0;
            status = "playing";
        }

        public void NextTurn()
        {
            status = PlayerHit();
            if(status == "playing")
                status = DealerHit();
        }

        public string PlayerHit()
        {
            Random rand = new Random();
            int random = rand.Next(1, 14);
            if (random > 10)
                random = 10;
            if (random == 1)
            {
                if(playerTotal == 10)
                    return "win";
                if (playerTotal < 10)
                    random = 1;
            }


            playerTotal += random;


            if (playerTotal > 21)
                return "lose";
            if (playerTotal == 21)
                return "win";
            return "playing";
        }

        public string DealerHit()
        {
            Random rand = new Random();
            int random = rand.Next(1, 14);
            if (random > 10)
                random = 10;
            if (random == 1)
            {
                if (dealerTotal == 10)
                    return "lose";
                if (dealerTotal < 10)
                    random = 1;
            }


            dealerTotal += random;


            if (dealerTotal > 21)
                return "win";
            if (dealerTotal == 21)
                return "lose";
            return "playing";
        }


    }
}
